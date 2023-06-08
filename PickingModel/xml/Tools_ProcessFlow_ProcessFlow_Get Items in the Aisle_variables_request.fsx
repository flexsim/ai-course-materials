<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>request</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode list = param(4);
Variant partition = param(5); //Could be a treenode, string, number
treenode processFlow = ownerobject(activity);
return /**/token.MaxItems - content(token.Operator)/**direct*/;</data></node></flexsim-tree>
