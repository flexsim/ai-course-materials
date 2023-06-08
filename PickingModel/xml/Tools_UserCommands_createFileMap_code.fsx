<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>Array codeNodes;
Array toCheck = [model()];

while (toCheck.length) {
	treenode curNode = toCheck.pop();
	if (switch_flexscript(curNode)) {
		codeNodes.push(curNode);
	}
	
	toCheck.append(curNode.subnodes.toArray());
	
	if (curNode.dataType == DATATYPE_OBJECT) {
		treenode attr = curNode.find("&gt;1");
		while (attr) {
			toCheck.push(attr);
			attr = attr.next;
		}
	}
}

XML.Document doc;
doc.createDeclaration();
var root = doc.createElement("flexsim-file-map");
root.attrs.version = 1;

for (int i = 1; i &lt;= codeNodes.length; i++) {
	treenode codeNode = codeNodes[i];
	var mapNode = root.createElement("map-node");
	string path = codeNode.getPath(model());
	path = path.substr(2, path.length - 1);
	mapNode.attrs.path = path;
	mapNode.attrs.file = "xml/" + path.replace(/[\\\/&gt;]/g, "_") + ".fsx";
	mapNode.attrs.set("file-map-method", "single-node");
}

var wsNode = root.createElement("map-node");
wsNode.attrs.path = "Tools/Workspace";
wsNode.attrs.file = "xml/Workspace.fsx";
wsNode.attrs.set("file-map-method", "single-node");

doc.saveAs(modeldir() + "PickingModel.ffm");</data></node></flexsim-tree>
