# Description

This model uses the Reinforcement Learning tool to choose actions for a picker in a warehouse.
Every time an order drops, the items for that order appear on racks arranged in five aisles.
The picker must visit each of the aisles with items to pick to collect the items for the order.
The picker will unload items at the queue when they have reached capacity, when the order
is complete, or when chosen by the RL tool.

## High Priority and Bonus Items
By random chance, some items are marked as High Priority items. When the order drops, a timer
starts. If the picker picks a High Priority item before the timer expires, the item is then
counted as a bonus item.

# Observation Space
The model contains a Global Table called Observations. This table provides a list of possible
observations to include. If the `Include` Column is set to `1`, the observation will be used.
This table also contains `Min` and `Max` columns. These values are used to normalize the
observation. Any value at or lower than `Min` will be mapped to `-1`, and any value 
at or higher than `Max` will be mapped to 1.

# Action Space
There is a single action which indicates the picker's next choice. There are six options.
Options 1-5 indicate that the picker should travel to the corresponding aisle in the warehouse.
Option 6 indicates that the picker should drop off items early.

# Shaping the Reward Function

This model provides five user commands:

| User Command | Timing |
|---|---|
| onPickStart | Called when the picker picks an item. |
| onPickComplete | Called when the picker drops off an item. |
| onOrderComplete | Called when the picker drops off the last item in the order. |
| onUnloadError | Called when the picker chooses to unload and is not carrying any items. |
| onDoubleAisleError | Called when the picker chooses the same aisle as the previous action. |

The user commands are found in the toolbox.

Within each user command, you can adjust the Reward value with code like the following:

```
Reward += 0.1;
```

If desired, you can also reduce reward when mistakes are made:
```
Reward -= 0.1;
```

In addition, you can also set Done to true, which will end the episode:
```
if (/*some condition*/) {
  Done = 1;
}
```

Exiting early like this can be viewed as a penalty, as no further reward can be gained.

The return value of the onUnloadError and onDoubleAisleError commands determines
how much clock time the operator will stand idle after committing an error.
This is a form of penalty, as this time cannot be used to gain reward.

Shaping your reward function requires some positive reward. Any other reward choice,
such as giving a negative reward, exiting early, or consuming clock time, is left
to your best judgement.