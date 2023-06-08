<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>/**Custom Code*/
// Save off whatever the user commands are at the moment

// Use a regular connection to create the file
string path = modeldir() + "user_commands.sqlite";
treenode dbNode = Model.find("Tools/userCommandDBCreate");
setsdtvalue(dbNode, "dbString", path);
Database.Connection db = dbNode;
db.connect();
db.disconnect();

// Use the SQLite connection to run this nifty query
dbNode = Model.find("Tools/userCommandDB");
setsdtvalue(dbNode, "dbString", path);
db = dbNode;
db.connect();
db.query("CREATE TABLE IF NOT EXISTS user_commands (name TEXT PRIMARY KEY, original TEXT, current TEXT)");

string stmtText = "INSERT INTO user_commands (name, original, current) VALUES (:1, :2, :2)";
stmtText += " ON CONFLICT DO UPDATE SET current = :2";

var stmt = db.prepareStatement(stmtText);
if (stmt) {
	treenode commandList = Model.find("Tools/UserCommands");
	Array userCommands = savedUserCommands();
	for (int i = 1; i &lt;= userCommands.length; i++) {
		string cmd = userCommands[i];
		string code = gets(node(cmd + "/code", commandList));
		stmt.bindParam(1, cmd, Database.DataType.VarChar);
		stmt.bindParam(2, code, Database.DataType.VarChar);
		stmt.execute();
	}
}

db.disconnect();</data></node></flexsim-tree>
