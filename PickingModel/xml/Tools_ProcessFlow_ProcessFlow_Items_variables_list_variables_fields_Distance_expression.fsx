<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>expression</name><data>Variant value = param(1);
Variant puller = param(2);
treenode entry = param(3);
double pushTime = param(4);

if (!objectexists(puller))
	return -1;
updatelocations(puller);
updatelocations(up(value));
/**Straight-Line Distance From Item to Puller*/
double x1 = vectorprojectx(value, 0.5 * xsize(value), -0.5 * ysize(value), 0, model());
double y1 = vectorprojecty(value, 0.5 * xsize(value), -0.5 * ysize(value), 0, model());
double z1 = vectorprojectz(value, 0.5 * xsize(value), -0.5 * ysize(value), 0, model());
double x2 = vectorprojectx(puller, 0.5 * xsize(puller), -0.5 * ysize(puller), 0, model());
double y2 = vectorprojecty(puller, 0.5 * xsize(puller), -0.5 * ysize(puller), 0, model());
double z2 = vectorprojectz(puller, 0.5 * xsize(puller), -0.5 * ysize(puller), 0, model());

return sqrt(sqr(x1 - x2) + sqr(y1 - y2) + sqr(z1 - z2));
</data></node></flexsim-tree>
