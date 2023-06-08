<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>/**Custom Code*/
Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);

double pickDuration = Model.time - token.Item.PickStartTime;
double pickDistance = token.Operator.stats.totalTravelDistance - token.Item.PickStartDistance;
double orderDuration = Model.time - token.OrderStartTime;

double isBonus = token.Item.HighPriority &amp;&amp; orderDuration &gt; Model.parameters.PriorityWindow;
token.Item.isBonus = isBonus;

TrackedVariable("TotalPicks").value += 1;
if (token.Item.HighPriority) {
	TrackedVariable("HighPriorityPicks").value += 1;
	if (isBonus) {
		TrackedVariable("BonusPicks").value += 1;
	}
}

onPickComplete(pickDuration, pickDistance, token.Item.HighPriority, isBonus);</data></node></flexsim-tree>
