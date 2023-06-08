<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>Table observations = Table("Observations");
int numRows = observations.numRows;
int usedCount = 0;
Array result = Array(numRows);

for (int i = 1; i &lt;= numRows; i++) {
	var row = observations[i];
	if (!row[2]) {
		continue;
	}
	
	usedCount++;
	
	double value = row[1];
	double min = row[3];
	double max = row[4];
	
	if (max &lt;= min) {
		continue;
	}
	
	if (value &lt;= min) {
		result[usedCount] = -1;
	} else if (value &gt;= max) {
		result[usedCount] = 1;
	} else {
		double value = (value - min) / (max - min) * 2 - 1;
		result[usedCount] = value;
	}
}

result.length = usedCount;
return result;</data></node></flexsim-tree>
