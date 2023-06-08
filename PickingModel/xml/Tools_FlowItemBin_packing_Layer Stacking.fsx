<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>Layer Stacking</name><data>Object item = i;
Object current = c;
Object lastitem = item.prev;
/***popup:LayerStacking*/
/**Layer Stacking By Item Size*/
/**\nThis packing method will stack items by layer with same sized items. Differently sized items will create a new layer.*/
double zBaseLayer = 0;
double numBelowBase = 0;
if(current.subnodes.length == 1) {
	current.zBaseLayer = 0;
	current.numBelowBase = 0;
} else {
	//check the size matches - if not then create new layer.
	zBaseLayer = current.zBaseLayer;
	numBelowBase = current.numBelowBase;
	
	/**\nWhich sizes must be different in order to create a new layer.*/
	int differentXSize =/** \nDifferent X Size: *//***tag:differentX*//**/0/**/;
	int differentYSize =/** \nDifferent Y Size: *//***tag:differentY*//**/0/**/;
	int differentZSize =/** \nDifferent Z Size: *//***tag:differentZ*//**/1/**/;
	
	int matchedX = item.size.x == lastitem.size.x;
	int matchedY = item.size.y == lastitem.size.y;
	int matchedZ = item.size.z == lastitem.size.z;
	
	if (((differentXSize &amp;&amp; !matchedX) || !differentXSize) &amp;&amp; ((differentYSize &amp;&amp; !matchedY) || !differentYSize) &amp;&amp; ((differentZSize &amp;&amp; !matchedZ) || !differentZSize)) {
		zBaseLayer = lastitem.location.z + lastitem.size.z - current.size.z;
		current.zBaseLayer = zBaseLayer;
		numBelowBase = current.subnodes.length - 1;
		current.numBelowBase = numBelowBase;
	}
}
int x = maxof(1, current.size.x/item.size.x);
int y = maxof(1, current.size.y/item.size.y);
double xStart = current.size.x/2.0 - x/2.0*item.size.x;
double yStart = -current.size.y/2.0 + y/2.0*item.size.y;
int numLayer = x*y;
int num = current.subnodes.length - numBelowBase;
int thisLayer = (num - 1)/numLayer + 1;
double z = zBaseLayer + current.size.z + item.size.z*(thisLayer - 1);
int layerrank = fmod(num - 1, numLayer);
int yNum = layerrank/x;
int xNum = fmod(layerrank, x);
item.setLocation(xStart + xNum * item.size.x, yStart - yNum * item.size.y, z);
</data></node></flexsim-tree>
