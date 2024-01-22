import os

flexsim = os.path.abspath("C:/Program Files/FlexSim 2024/program/flexsim.exe")
model = os.path.join(os.path.dirname(__file__), "Elevator.fsm")
tensorboard = os.path.join(os.path.dirname(__file__), "tensorboard")
agent = os.path.join(os.path.dirname(__file__), "HelloWorld.zip")

if __name__=="__main__":
    print("FlexSim path:", flexsim)
    if os.path.exists(flexsim):
        print("FlexSim found")
    else:
        print("ERROR: FlexSim not found")
    
    print("Model path:", model)
    if os.path.exists(model):
        print("Model found!")
        
    else:
        print("ERROR: Model not found")

    print(tensorboard)
    print(agent)