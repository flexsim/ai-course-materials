<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="8000000442" dt="2"><name>slotAssignment</name><data>Storage.Object current = ownerobject(c);
Object item = param(1);
Storage.Item storageItem = Storage.Item(item);
/***popup:SlotByCondition*/
/**First Slot with Space*/
for (int i = 1; i &lt;= current.bays.length; i++) {
	Storage.Bay bay = current.bays[i];
	for (int j = 1; j &lt;= bay.levels.length; j++) {
		Storage.Level level = bay.levels[j];
		for (int k = 1; k &lt;= level.slots.length; k++) {
			Storage.Slot slot = level.slots[k];
			int mustHaveSpace = /**\r\nMust Have Space: *//***tag:mustHaveSpace*//**/1/**/;
			if (mustHaveSpace &amp;&amp; !slot.hasSpace(item))
				continue;
			int condition = /**\r\nCondition: *//***tag:condition*//**/true/**/;
			if (condition) {
				storageItem.assignedSlot = slot;
				return 0;
			}
		}
	}
}
</data></node></flexsim-tree>
