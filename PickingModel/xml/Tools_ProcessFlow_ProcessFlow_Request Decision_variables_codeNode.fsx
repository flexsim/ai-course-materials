<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>codeNode</name><data>Object current = param(1);
treenode activity = param(2);
Token token = param(3);
treenode processFlow = ownerobject(activity);


{ //************* PickOption Start *************\\
/***popup:SendMessage*/
/**Send Message*/
int NoDelay = -1;
double delaytime = /** \nDelay Time: *//***tag:delaytime*//**/0/**list:NoDelay~0~10~current.messagedelay*/;
treenode toobject = /** \nTo: *//***tag:to*//**/Queue/**/;
treenode fromobject = /** \nFrom: *//***tag:from*//**/current/**/;
double param1 = /** \nParam1: *//***tag:par1*//**/0/**/;
double param2 = /** \nParam2: *//***tag:par2*//**/0/**/;
double param3 = /** \nParam3: *//***tag:par3*//**/0/**/;
/**\n\nDelay Time:\nNoDelay: message sent immediately within trigger context\n0: delayed message sent in 0 time*/
if (/** \nCondition: *//***tag:condition*//**/true/**/) {
	if (delaytime == NoDelay)
		sendmessage(toobject,fromobject,param1,param2,param3);
	else senddelayedmessage(toobject, max(0,delaytime), fromobject,param1,param2,param3);
}

} //******* PickOption End *******\\
</data></node></flexsim-tree>
