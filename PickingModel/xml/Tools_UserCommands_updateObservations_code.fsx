<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>double orderStartTime = param(1);
double orderStartDistance = param(2);
double prevAisle = param(3);

Table observations = Table("Observations");

int aisleCount = 5;

Object operator = Operator;

Array itemCountByAisle = Array(aisleCount).fill(0);
Array priorityItemCountByAisle = Array(aisleCount).fill(0);
Array itemDistancesByAisle = Array(aisleCount);

int slotCount = Slots.length;

for (int i = 1; i &lt;= slotCount; i++) {
	Storage.Slot slot = Slots[i];
	var slotItems = slot.slotItems;
	var slotItemCount = slotItems.length;
	for (int j = 1; j &lt;= slotItemCount; j++) {
		int aisle = slot.Aisle;
		itemCountByAisle[aisle]++;
		Object item = slotItems[j].item;
		if (item.HighPriority?) {
			priorityItemCountByAisle[aisle]++;
		}
		
		Vec3 itemLoc = item.location.project(item.up, model());
		double distToOp = (operator.location - itemLoc).magnitude;
		itemDistancesByAisle[aisle].push(distToOp);
	}
}

int curRow = 1;
for (int i = 1; i &lt;= aisleCount; i++) {
	observations[curRow++][1] = itemCountByAisle[i];
	observations[curRow++][1] = priorityItemCountByAisle[i];
	
	double minDist = 1000;
	double maxDist = 1000;
	double avgDist = 1000;
	
	if (itemCountByAisle[i]) {
		Array itemDists = itemDistancesByAisle[i];
		double sum = 0;
		for (int j = 1; j &lt;= itemDists.length; j++) {
			double dist = itemDists[j];
			if (j == 1) {
				minDist = dist;
				maxDist = dist;
			} else {
				minDist = Math.min(dist, minDist);
				maxDist = Math.max(dist, maxDist);
			}
			sum += dist;
		}
		avgDist = sum / itemDists.length;
	}
	
	observations[curRow++][1] = minDist;
	observations[curRow++][1] = maxDist;
	observations[curRow++][1] = avgDist;
}

// Distance to the queue
observations[curRow++][1] = (operator.location - Queue.as(Object).location).magnitude;

// How many items the operator is carrying
var carryItems = operator.subnodes;
observations[curRow++][1] = carryItems.length;

// How many priority items the operator is carrying
int priorityCarryCount = 0;
for (int i = 1; i &lt;= carryItems.length; i++) {
	priorityCarryCount += carryItems[i].HighPriority?;
}
observations[curRow++][1] = priorityCarryCount;

// How old the order is
double orderAge = Model.time - orderStartTime;
observations[curRow++][1] = Model.time - orderStartTime;

// How long is left in the priority window
double priorityWindow = Model.parameters.PriorityWindow;
double windowRemaining = priorityWindow - Math.min(priorityWindow, orderAge);
observations[curRow++][1] = windowRemaining;

// How far the operator has travelled for the order so far
observations[curRow++][1] = operator.stats.totalTravelDistance - orderStartDistance;

// The next set deal with whether ceratin actions are valid

// Can they unload
observations[curRow++][1] = content(operator) &gt; 1 ? 1 : 0;

// Did they just barely do the previous aisle
for (int i = 1; i &lt;= aisleCount; i++) {
	observations[curRow++][1] = prevAisle != i ? 1 : 0;
}

// The model time is next
observations[curRow++][1] = Model.time;











// for scrolling</data></node></flexsim-tree>
