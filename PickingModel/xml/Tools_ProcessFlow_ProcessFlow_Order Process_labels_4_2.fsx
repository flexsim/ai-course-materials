<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name></name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
int rowNumber = param(4); //The arrival entry row number
int repeatCount = param(5); //The number of times the arrivals table has repeated (first iteration repeatCount = 0) 
int tokenIndex = param(6); //The index of the created token within the arrival entry
string labelName = param(7);
treenode processFlow = ownerobject(activity);
return /**/Model.parameters.DecisionMode == 3/**direct*/;</data></node></flexsim-tree>
