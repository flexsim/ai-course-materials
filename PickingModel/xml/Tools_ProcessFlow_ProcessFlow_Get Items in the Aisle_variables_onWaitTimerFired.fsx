<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>onWaitTimerFired</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode involved = param(4);
treenode processFlow = ownerobject(activity);

{ //************* PickOption Start *************\\
/***popup:ReleaseToken*/
/**Release Token*/
Token tokenToRelease = /**\nToken: *//***tag:token*//**/token/**list:getchildtoken(token, 1)~getparenttoken(token)~gettoken(current, getactivity(processFlow, "Acquire"), 1)*/;
Variant connector = /**\nConnector: *//***tag:connector*//**/2/**/;
tokenToRelease.release(connector);
} //******* PickOption End *******\\
</data></node></flexsim-tree>
