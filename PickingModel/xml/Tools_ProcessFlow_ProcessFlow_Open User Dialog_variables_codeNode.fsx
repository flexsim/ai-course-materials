<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

string focusPath = token.as(treenode).getPath();
token.Operator.message(1);
applicationcommand("stop");
createview("MODEL:/Tools/ModelGUIs/ManualModeUI", focusPath, focusPath);
</data></node></flexsim-tree>
