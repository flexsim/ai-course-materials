<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>quantity</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
Variant destination = param(4); //This may be a Sub Flow object or Start activity (treenode), connector name (string) or connector index (int)
treenode processFlow = ownerobject(activity);
return /**/content(token.Operator)/**direct*/;</data></node></flexsim-tree>
