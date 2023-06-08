<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="8000000442" dt="2"><name>RewardFunction</name><data>Object current = ownerobject(c);

/***popup:RewardFunction*/
/***tag:description*//**Reward Function*/
/***tag:snippet*//**/double reward = Reward;
Reward = 0;
int done = Done || Model.time &gt;= Model.parameters.DoneTime || OrderActionCount &gt;= 100;

return [reward, done];/**/
</data></node></flexsim-tree>
