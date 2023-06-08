<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="10000442" dt="2"><name>Default</name><data>Object item = i;
Object current = c;
Object lastitem = item.prev;
/**Default Packing Method*/

// Check to see if the flowitem is the first one in
if (current.subnodes.length == 1) {
	item.setLocation(0, 0, current.size.z);
	return 0;
}

// Check if there is space to the right of the last item
if (current.size.x - (lastitem.location.x + lastitem.size.x) &gt;= item.size.x) {
	item.setLocation(lastitem.location.x + lastitem.size.x, lastitem.location.y, lastitem.location.z);
	return 0;
}

// Check below the last item -the math is weird because the position is less than 0
if (current.size.y - (lastitem.size.y - lastitem.location.y) &gt;= item.size.y) {
	item.setLocation(0, -1 * (lastitem.size.y - lastitem.location.y), lastitem.location.z);
	return 0;
}

// Place the new item above the last one
item.setLocation(0, 0, lastitem.location.z + lastitem.size.z);
</data></node></flexsim-tree>
