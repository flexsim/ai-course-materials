<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>entryOrientation</name><data>Object current = ownerobject(c);
Conveyor conveyor = param(1);
Object item = param(2);
Conveyor.Item conveyorItem = conveyor.itemData[item];

/***popup:Conveyor_FixedOrientation*/
/***tag:description*//**Forward: X+, Up: Z+*/
/** \nForward: *//***tag:forwardAxis*//**X+*/
/** \nUp: *//***tag:upAxis*//**Z+*/
return /** \nOrientation: *//***tag:orientation*//**/CONV_ITEM_X_BY_Y/**/;
</data></node></flexsim-tree>
