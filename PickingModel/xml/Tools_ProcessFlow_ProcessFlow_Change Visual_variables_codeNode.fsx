<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);
{ //************* PickOption Start *************\\
/***popup:SetObjectColor*/
/**Set Object Color*/
Variant object = /** \nObject: *//***tag:object*//**/token.Item/**/;
Color colorVal = /** \nColor: *//***tag:color*/ /**/token.Item.HighPriority ? Color.lime : Color.blue/**/;
if(object.is(Token)) {
	object.as(Token).color = colorVal;
}
else {
	object.as(Object).color = colorVal;
}
} //******* PickOption End *******\\
</data></node></flexsim-tree>
