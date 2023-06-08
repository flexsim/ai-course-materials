<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>/**Custom Code*/
Table observations = Table("Observations");

int carriedItems = observations[27][1];
int totalCapacity = Model.parameters.OperatorCapacity;

// If the operator is already full, unload
if (carriedItems == totalCapacity) {
	Model.parameters.NextAisle = 0;
	return 0;
}

Array actions = [1, 2, 3, 4, 5];
Array itemCount = [
	  observations[1][1]
	, observations[6][1]
	, observations[11][1]
	, observations[16][1]
	, observations[21][1]
];

Array distances = [
	  observations[3][1]
	, observations[8][1]
	, observations[13][1]
	, observations[18][1]
	, observations[23][1]
];

int remainingCapacity = totalCapacity - carriedItems;

Table result = Table.query("SELECT $2 FROM $1 WHERE $3 AND $4 ORDER BY $4 DESC, $5 ASC LIMIT 1", 
	  actions.length
	, actions[$iter(1)]
	, itemCount[$iter(1)] &lt;= remainingCapacity
	, itemCount[$iter(1)]
	, distances[$iter(1)]
);

// If there are no aisles that can be completely included
if (result.numRows == 0) {
	// If I'm carrying something, unload it
	if (carriedItems) {
		Model.parameters.NextAisle = 0;
		return 0;
	} else {
		// Pick the aisle with the most on it
		result = Table.query("SELECT $2 FROM $1 WHERE 1 AND $4 ORDER BY $4 DESC, $5 ASC LIMIT 1", 
			  actions.length
			, actions[$iter(1)]
			, itemCount[$iter(1)] &lt;= remainingCapacity
			, itemCount[$iter(1)]
			, distances[$iter(1)]
		);
		
		if (result.numRows == 0) {
		
			// This should only happen on reset
			if (Model.time &gt; 0) {
				mpt("error - operator told to choose aisle, but no items are available"); mpr();
			}
			return 0;
		}
	}
}

// Otherwise, go to the aisle with the most items that the operator can carry
int action = result[1][1];
Model.parameters.NextAisle = action;
return 0;
</data></node></flexsim-tree>
