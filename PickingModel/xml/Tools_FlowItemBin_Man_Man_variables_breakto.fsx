<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>breakto</name><data>TaskSequence activeTaskSequence = param(1);
TaskExecuter current = ownerobject(c);
/***popup:BreakToSame*/
/**New Tasksequences Only*/
/** Only break to task sequences that have not been started already.*/
/** Object queueing the tasksequences: */
Dispatcher theObject = /***tag:dispatcher*//**/current/**/;

TaskSequence returnts = NULL;
for (int index = 1; index &lt;= theObject.taskSequences.length &amp;&amp; ! returnts; index++) {
	TaskSequence curts = theObject.taskSequences[index];
	if (gettotalnroftasks(curts) == getnroftasks(curts))
		returnts = curts;
}
return returnts;</data></node></flexsim-tree>
