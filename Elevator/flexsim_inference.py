import json
from sb3_contrib import MaskablePPO
from http.server import BaseHTTPRequestHandler, HTTPServer
from urllib.parse import urlparse, parse_qs
import numpy as np
import paths

class FlexSimInferenceServer(BaseHTTPRequestHandler):

    def do_GET(self):
        params = parse_qs(urlparse(self.path).query)
        self._handle_reply(params)

    def do_POST(self):
        content_length = int(self.headers['Content-Length'])
        body = self.rfile.read(content_length)
        params = parse_qs(body)
        self._handle_reply(params)

    def _ensure_nparray(self, v):
        if isinstance(v, list):
            return np.array(v)
        return v

    def _handle_reply(self, params):
        if len(params):
            raw_observation = {}
            if b'observation' in params.keys():
                observationBytes = params[b'observation'][0]
                rawBytes = json.loads(observationBytes)
                raw_observation = json.loads(rawBytes)

            observation = {k: self._ensure_nparray(v) for k, v in raw_observation.items()}

            mask = [True, True, False]
            max_floor = FlexSimInferenceServer.model.observation_space.spaces['Floor'].n - 1
            floor = observation['Floor']
            if floor == max_floor:
                mask[0] = False
            
            if floor == 0:
                mask[1] = False

            is_max_capacity = observation['TotalOnElevator'] >= 20
            getting_off = observation['DisembarkCount'][floor]
            getting_on = observation['EmbarkCount'][floor]
            if getting_off > 0 or (not is_max_capacity and getting_on > 0):
                mask[2] = True

            action, _states = FlexSimInferenceServer.model.predict(observation, action_masks=mask)
            self.send_response(200)
            self.send_header("Content-type", "application/json")
            self.end_headers()
            body = json.dumps(action, cls=NumpyEncoder)
            self.wfile.write(bytes(body, "utf-8"))
            return
      
        self.send_response(200)
        self.send_header("Content-type", "text/html")
        self.end_headers()
        self.wfile.write(bytes("", "utf-8"))


class NumpyEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, np.integer):
            return int(obj)
        elif isinstance(obj, np.floating):
            return float(obj)
        elif isinstance(obj, np.ndarray):
            return obj.tolist()
        return json.JSONEncoder.default(self, obj)


def main():
    print("Loading model...")
    model = MaskablePPO.load(paths.agent)
    FlexSimInferenceServer.model = model
   
    # Create server object
    print("Starting server...")
    hostName = "localhost"
    serverPort = 8000
    webServer = HTTPServer((hostName, serverPort), FlexSimInferenceServer)
    print("Server started http://%s:%s" % (hostName, serverPort))

    # Start the web server
    try:
        webServer.serve_forever()
    except KeyboardInterrupt:
        pass

    webServer.server_close()
    print("Server stopped.")


if __name__ == "__main__":
    main()