<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>treenode rl = Model.find("/Tools/ReinforcementLearning/AisleChooser");
Table observations = Table("Observations");

int sum = 0;
for (int i = 1; i &lt;= observations.numRows; i++) {
	sum += observations[i][2];
}

setvarstr(rl, "customObservationSpace", "{\"count\": " + sum + "}");</data></node></flexsim-tree>
