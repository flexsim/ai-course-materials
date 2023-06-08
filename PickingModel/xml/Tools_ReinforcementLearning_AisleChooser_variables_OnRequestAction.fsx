<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>OnRequestAction</name><data>Object current = ownerobject(c);
Variant observation = param(1);
double reward = param(2);
int done = param(3);


{ // ************* PickOption Start ************* //
/***popup:CodeSnippet*/
/***tag:description*//**Go to the aisle with the most items the operator can carry*/
if (Model.parameters.DecisionMode == 4) {
	chooseAisle();
	return 0;
}
} // ******* PickOption End ******* //

{ // ************* PickOption Start ************* //
/***popup:QueryInferenceServer*/
/***tag:description*//**Query a server for a predicted action from a trained model*/
if (/** \nCondition: *//***tag:expression*//**/Model.parameters.DecisionMode == 2/**/) {
	Http.Request request;
	request.host = /** Host: */
	/***tag:host*//**/"127.0.0.1"/**/;
	request.port = /** Port: */
	/***tag:port*//**/8000/**/;
	request.method = Http.Method.Post;
	request.data = "observation=" + JSON.stringify(observation);
	Http.Response response = request.sendAndWait();

	if (response.statusCode == 200) {
		string action = response.value;
		function_s(current, "takeAction", action);
		return 0;
	} else {
		msg(current.name + " Server Unavailable", "Connection to server " + request.host + ":" + request.port + " timed out. \n\nStopping model.");
		stop();
	}
}
} // ******* PickOption End ******* //
{ // ************* PickOption Start ************* //
/***tag:description*//**Take a random action by setting each action space parameter to a random value within its constraints*/
treenode actionParams = getvarnode(current, "actionParams");
for (int r = 1; r &lt;= actionParams.subnodes.length; r++) {
	treenode actionParam = actionParams.subnodes[r].value;
	actionParam.as(ConstrainedVariable).value = actionParam.as(ConstrainedVariable).randomValue();
}
} // ******* PickOption End ******* //
</data></node></flexsim-tree>
