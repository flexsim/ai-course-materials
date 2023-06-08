<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name></name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
Object item = param(4);
Variant assignTo = item;
int createdrank = param(5);
string labelName = param(6);
treenode processFlow = ownerobject(activity);
return /**/bernoulli(30, 1, 0, getstream(activity))/**direct*/;</data></node></flexsim-tree>
