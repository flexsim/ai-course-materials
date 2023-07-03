<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>decision</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);
return /**/content(token.Operator) ? 1 : 2/**direct*/;</data></node></flexsim-tree>
