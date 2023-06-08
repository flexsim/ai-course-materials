<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>OnDraw</name><data>treenode view = c;

Array observations = getObservations();
treenode palette = getvarnode(view, "palette").value;

double w = spatialsx(view).value;
double h = spatialsy(view).value;

double rowHeight = h / observations.length;
double y = 0;

for (int i = 1; i &lt;= observations.length; i++) {
	Variant value = observations[i];
	Color c;
	if (value.type == VAR_TYPE_NULL || value &lt; -1 || value &gt; 1) {
		c = Color.red;
	} else {
		c = Color.fromPalette(value, palette);
	}
	
	drawrect(view, 0, y, 0, w, y + rowHeight, 0, c.r, c.g, c.b);
	y += rowHeight;
}</data></node></flexsim-tree>
