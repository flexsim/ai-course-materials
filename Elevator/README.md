# The Elevator Model

The elevator model simulates a simplified version of an Elevator. People appear in
line on various floors and request a ride to some other floor. The AI's job is to
operate the elevator in an efficient way.

For simplicity, the following assumptions apply:
* There are no stairs. People wait in line indefinitely for the elevator.
* There is no emergency exit from the elevator. People wait indefinitely in the elevator until the doors open on their requested floor.
* People that get in line anywhere other than the first floor get off on the first floor.
* People that get in line on the first floor have an equal chance to go to any other floor.
* The elevator operates in two modes: loading/unloading passengers or moving to a new floor. It isn't capable of idling on a floor.
* The simulation limits the total number of people in the system to 100 by default. This limit prevents excessive resource consumption for poorly-performing policies.

## Observations
All observations are found in the Parameter Table called Observations.

### General Observations
* **Floor** - The Elevator's current floor number.
* **TotalInLine** - The total number of people waiting to enter the elevator across all floors.
* **TotalInElevator** - The total number of people currently in the elevator cabin.
* **TotalAngry** - The total number of people currently in the system who crossed the anger threshold, either in line or in the cabin.
* **RidesCompleted** - The number of people who have exited the cabin since the previous action.
* **ModelTime** - The number of seconds that have elapsed in the simulation

### Per-floor Observations
The following observations are each an array with one value per floor.
* **EmbarkCount** - The number of people in line on each floor.
* **EmbarkTotalWait** - The total number of minutes accumulated by the current queue on each floor.
* **EmbarkMaxWait** - The maximum wait time in the current queue on each floor, in minutes.
* **EmbarkAvgWait** - The average time for the current queue on each floor, in minutes.
* **EmbarkAngryCount** - The number of people in the current queue on each floor who have waited in line longer than the "anger" threshold.
* **DisembarkCount** - The number of people on the elevator travelling to each floor.
* **DisembarkTotalWait** - The total wait time for people on the elevator travelling to each floor.
* **DisembarkMaxWait** - The maximum wait time for people on the elevator travelling to each floor.
* **DisembarkAvgWait** - The average wait time for people on the elevator travelling to each floor.
* **DisembarkAngryCount** - The number of people on the elevator travelling to each floor who have waited on the elevator longer than the "anger" threshold.

### Action Masking

The parameter called **ActionMask** is designed to be used as an action mask. It is an array
with three values, one for each possible action:

```
[Up, Down, OpenDoors]
```
The action mask is governed by these rules:
* The elevator can always go up unless it is at the highest floor.
* The elevator can always go down unless it is at the lowest floor.
* The elevator can only open its doors if one of the following conditions is met:
  * The elevator isn't full and someone is in line on the current floor, or
  * Someone wants to exit the elevator on the current floor.

## Actions

There is a single action, **Action**, in the Parameter Table called Actions. The action has three possible values:
* **Up** - The elevator will travel up to the next floor. No riders will enter or exit.
* **Down** - The elevator will travel down to the next floor. No riders will enter or exit.
* **OpenDoors** - The elevator will open its doors. All riders that want to exit on that floor will get off. Anyone in line on that floor will enter the elevator, up to the maximum capacity.

## Other Model Parameters

There are some additional model parameters that control the simulation behavior found
in the Parameter Table called ModelSettings. If you train an AI and then change these
settings, do not expect the trained AI to be competent with the new settings.

* **NumFloors** - The total number of floors in the system. By default, this value is 5, but can be increased up to 10. **Changing this value changes the shape of the Observation Space.**
* **Cycle Time** - The simulation cycles sinusoidally in two ways. First, the number of riders fluctuates between a low arrival rate and a high arrival rate during the cycle. In addition, the direction of traffic cycles from very likely inbound to very likely outbound during the cycle.
* **InterArrivalMin** - The average arrival rate at the low point in the cycle.
* **InterArrivalMax** - The average arrival rate at the high point in the cycle.
* **MaxOccupancy** - The number of people that can fit on the elevator.
* **MaxWaitTime** - If someone waits in line for longer than this amount of time, they count in the EmbarkAngryCount observation for that floor, and in the TotalAngry observation.
* **MaxRideTime** - If someone waits on the elevator for longer than this amount of time, they count in the DisembarkAngryCount observation for that floor, and in the TotalAngry observation.
* **MaxRidersInSystem** - More people will not be generated unless the total number of people currently in the simulation is less than this value.
* **DoAnimations** - If set to Yes, people will be drawn with detailed human shapes. If set to No, people will be drawn as rectangular prisms and cylinders. Yes looks more realistic but requires more resources. No is recommended for training.