<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="distributed">
<node f="442" dt="2"><name>valueNode</name><data>treenode reference = param(1);
treenode extraData = param(2);
treenode repData = param(3);

/***popup:PFMStatByObject*/
/**Statistic by individual object*/
int Output = 1;
int Input = 2;
int MinimumContent = 3;
int MaximumContent = 4;
int AverageContent = 5;
int MinimumStaytime = 6;
int MaximumStaytime = 7;
int AverageStaytime = 8;
int TotalTravelDistance = 9;

Object current = reference;
int stat = /** \nStatistic: *//***tag:stat*//**/9/**list:Output~Input~MinimumContent~MaximumContent~AverageContent~MinimumStaytime~MaximumStaytime~AverageStaytime~TotalTravelDistance*/;

double value = 0;
if (stat == Output) value = getoutput(current);
else if (stat == Input) value = getinput(current);
else if (stat == MinimumContent) value = getstat(current, "Content", STAT_MIN);
else if (stat == MaximumContent) value = getstat(current, "Content", STAT_MAX);
else if (stat == AverageContent) value = getstat(current, "Content", STAT_AVERAGE);
else if (stat == MinimumStaytime) value = getstat(current, "Staytime", STAT_MIN);
else if (stat == MaximumStaytime) value = getstat(current, "Staytime", STAT_MAX);
else if (stat == AverageStaytime) value = getstat(current, "Staytime", STAT_AVERAGE);
else if (stat == TotalTravelDistance) value = getvarnum(current, "totaltraveldist");

return value;
</data></node></flexsim-tree>
