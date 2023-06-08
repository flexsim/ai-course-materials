<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="8000000442" dt="2"><name>pullrequirement</name><data>Storage.Object current = ownerobject(c);
Object item = param(1);
int port =  param(2);
int isOnExitEvent = param(3);

/**Pull Items Successfully Assigned to Slots*/
if (!isOnExitEvent) {
	if (current.assignSlot(item) != 0) {
		return 1;
	} else {
		treenode exitListener = c.subnodes["exitListener"];
		if (!exitListener) {
			exitListener = c.subnodes.assert("exitListener");
			switch_destroyonreset(exitListener, 1);
			exitListener.value = eventlisten(current, "OnExit", c, 0, item, port, 1);
		}
	}
} else {
	if (isOnExitEvent == 1) {
		delayednodefunction(c, 0, item, port, 2);
	} else {
		if (inputopen(current))
			openinput(current);
	}
}
return 0;
</data></node></flexsim-tree>
