<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>coldlinkx</name><data>treenode view = c;
treenode dbNode = view.find("&gt;objectfocus+");

if (eventcode == APPLY_LINKS_ON_OPEN) {
	setviewtext(view, string.fromNum(Done || Model.time &gt;= Model.parameters.DoneTime, 0));
}</data></node></flexsim-tree>
