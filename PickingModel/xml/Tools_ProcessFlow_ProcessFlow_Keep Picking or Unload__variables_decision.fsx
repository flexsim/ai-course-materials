<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>decision</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);
/***popup:Conditional*/
/**Conditional Decide*/
/** \nIf some condition is true (equal to 1), send to a given connection/activity. Otherwise, send to a different connection/activity.*/

if (/** \nCondition: *//***tag:expression*//**/token.Aisle/**/)
	return /** \nIf Condition is true: *//***tag:true*//**/1/**/;

return /** \nIf Condition is false: *//***tag:false*//**/2/**/;
</data></node></flexsim-tree>
