<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

double orderDuration = Model.time - token.OrderStartTime;
double orderDistance = Model.time - token.OrderStartDistance;
int totalItems = token.OrderSize;

int priorityItems = 0;
int bonusItems = 0;
var items = Queue.subnodes;
for (int i = 1; i &lt;= items.length; i++) {
	if (items[i].HighPriority) {
		priorityItems += 1;
		if (items[i].isBonus?) {
			bonusItems += 1;
		}
	}
}

TrackedVariable("TotalOrders").value += 1;
onOrderComplete(orderDuration, orderDistance, totalItems, priorityItems, bonusItems);</data></node></flexsim-tree>
