<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="10000442" dt="2"><name>Truck</name><data>Object item = i;
Object current = c;
Object lastitem = item.prev;
/**Truck Packing Method*/

// Check to see if the flowitem is the first one in
if (current.subnodes.length == 1) {	
	Object trailer = current.find("&gt;visual/drawsurrogate/SemiCab/Trailer");
	item.location = Vec3(trailer.location.x + trailer.size.x, trailer.location.y, trailer.location.z).project(trailer.up, current);
	item.location.x -= item.size.x + 0.021 * current.size.x;
	item.location.y -= 0.001 * current.size.x;
	item.location.z = 0.29 * current.size.z;
	return 0;
}

// Check if there is not space to the right of the last item
if (current.size.y - ( -lastitem.location.y + lastitem.size.y) &lt;= item.size.y) {	
	item.setLocation(lastitem.location.x, current.first.as(Object).location.y, lastitem.location.z + item.size.z);
	//Check if we're going to hit the top 
	if (item.location.z + item.size.z &gt;= 0.98 * current.size.z) {		
		item.location.x = lastitem.location.x - lastitem.size.x;
		item.location.z = current.first.as(Object).location.z;	
	}
	return 0;
}

// Place the new item to the right
item.setLocation(lastitem.location.x, lastitem.location.y - lastitem.size.y, lastitem.location.z);
</data></node></flexsim-tree>
