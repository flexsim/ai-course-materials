<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

var row = Table(token.RouteTable)[token.Row];
Array partition = Array(2);
partition[1] = row[1];
partition[2] = row[2];

token.Partition = partition;
token.Value = row[3];

</data></node></flexsim-tree>
