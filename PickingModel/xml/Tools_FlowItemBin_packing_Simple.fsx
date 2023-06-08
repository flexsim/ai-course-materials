<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="10000442" dt="2"><name>Simple</name><data>Object item = i;
Object current = c;
Object lastitem = item.prev;
/***popup:SimplePacking*/
/**Simple Packing Method*/

/**Combine flowitems into any container.  Choose a buffer for the X, Y, and Z 
directions so the flowitems will not overlap with the container's edges.*/

double xBuffer = /** \nX Buffer: *//***tag:nx*//**/.025/**/;
double yBuffer = -/** \nY Buffer: *//***tag:ny*//**/.025/**/;
double zBuffer = /** \nZ Buffer: *//***tag:nz*//**/.08/**/;

double containerSX = current.size.x - xBuffer;
double containerSY = current.size.y + yBuffer;

if(current.subnodes.length == 1) {
	item.setLocation(xBuffer, yBuffer, zBuffer);
} else if(containerSX - (lastitem.location.x + lastitem.size.x) &gt;= item.size.x){
	item.setLocation(lastitem.location.x + lastitem.size.x, lastitem.location.y, lastitem.location.z);
} else if(containerSY - (lastitem.size.y - lastitem.location.y) &gt;= item.size.y){
	item.setLocation(xBuffer, -1 * (lastitem.size.y - lastitem.location.y), lastitem.location.z);
} else {
	item.setLocation(xBuffer, yBuffer, lastitem.location.z + lastitem.size.z);
}
</data></node></flexsim-tree>
