<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="8000000442" dt="2"><name>slotAssignment</name><data>Storage.Object current = ownerobject(c);
Object item = param(1);
Storage.Item storageItem = Storage.Item(item);
/**Random Bay, Level, and Slot*/
int bayNum = duniform(1, current.bays.length);
Storage.Bay bay = current.bays[bayNum];
int levelNum = duniform(1, bay.levels.length);
Storage.Level level = bay.levels[levelNum];
int slotNum = duniform(1, level.slots.length);
Storage.Slot slot = level.slots[slotNum];
if (slot.isStorable)
	storageItem.assignedSlot = slot;
else {
	for (int i = 0; i &lt;= current.bays.length; i++) {
		if (i == bayNum)
			continue;
		Storage.Bay bay = (i == 0 ? current.bays[bayNum] : current.bays[i]);
		for (int j = 0; j &lt;= bay.levels.length; j++) {
			if (j == 0 &amp;&amp; i != 0)
				continue;
			Storage.Level level = (j == 0 ? bay.levels[levelNum] : bay.levels[j]);
			for (int k = 0; k &lt;= level.slots.length; k++) {
				if (k == 0 &amp;&amp; j != 0)
					continue;
				Storage.Slot slot = (k == 0 ? level.slots[slotNum] : level.slots[k]);
				if (slot.isStorable) {
					storageItem.assignedSlot = slot;
					return 0;
				}
			}
		}
	}
}
</data></node></flexsim-tree>
