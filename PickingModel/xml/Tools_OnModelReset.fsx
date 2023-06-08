<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>OnModelReset</name><data>if (currentfile().endsWith(".fsx")) {
	createFileMap();
}

Slots = Storage.system.querySlots("WHERE Usable");

SlotLocs = Array(Slots.length);
for (int i = 1; i &lt;= Slots.length; i++) {
	var slot = Slots[i].as(Storage.Slot);
	Vec3 loc = slot.getLocation(0.5, 0.5, 0.0);
	SlotLocs[i] = loc.project(slot.storageObject, model());
}

Table observations = Table("Observations");
int numRows = observations.numRows;
for (int i = 1; i &lt;= numRows; i++) {
	observations[i][1] = 0;
}

updateObservationSpace();</data></node></flexsim-tree>
