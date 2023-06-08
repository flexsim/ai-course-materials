<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>code</name><data>/**Custom Code*/
double pickDuration = param(1); // the number of seconds the operator carried the item
double pickDistance = param(2); // how far the operator carried the item
int isPriority = param(4);
int isBonus = param(3); // whether the item was picked fast enough to qualify for the bonus

// Possibly adjust Reward/Done
// Reward can optionally be based on whether the item was a bonus item
// Could also be more reward for faster pick time, or less pick distance

/*
if (isPriority &amp;&amp; isBonus) {
	
} else {
	
}
*/</data></node></flexsim-tree>
