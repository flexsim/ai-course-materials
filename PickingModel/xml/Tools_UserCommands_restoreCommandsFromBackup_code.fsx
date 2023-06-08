<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>string path = modeldir() + "user_commands.sqlite";
treenode dbNode = Model.find("Tools/userCommandDB");
setsdtvalue(dbNode, "dbString", path);
Database.Connection db = dbNode;

if (!db.connect()) {
	return 0;
}

string stmtText = "SELECT name, current FROM user_commands";
var stmt = db.prepareStatement(stmtText);
if (stmt) {
	treenode commandList = Model.find("Tools/UserCommands");
	var result = stmt.execute();
	while (result.fetchNext()) {
		string name = result[1];
		treenode codeNode = node(name + "/code", commandList);
		sets(codeNode, result[2]);
	}
}
db.disconnect();</data></node></flexsim-tree>
