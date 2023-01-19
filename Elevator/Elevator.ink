inkling "2.0"
using Goal

# This struct defines the set of values Bonsai will use to learn. It should contain
# all your observations except for ActionMask and ModelTime.
type LearningState {
    # TODO: Add your chosen obersvations (except for ActionMask) to this section
    # NOTE: You must include ActionMask in your observations in FlexSim, but not in this struct
    # This is also true for ModelTime (include in FlexSim but not here)

    # These are included as an example
    # [people] Current number of people on the elevator
    TotalInElevator: number,

    # [people] Current number of people in line in the system
    TotalInLine: number,
}

# This struct allows us to include the ActionMask in our observations, but not to use
# it during training
type SimState extends LearningState {
    # NextJobMask is an array that tells Bonsai which jobs it can start
    ActionMask: number<0, 1, >[3],

    # [seconds] The number of model seconds that have elapsed
    ModelTime: number,
}

# This type tells Bonsai what it's allowed to do in response to the observation
type SimAction {
    Action: number<Up = 1, Down = 2, OpenDoors = 3>,
}

# This section tells Bonsai to use a simulator for training
simulator FlexSimSimulator(action: SimAction): SimState {
    # If there is nothing here, you will choose a simulator when you click "Train"
}

# This function essentially removes the ActionMask before giving the rest of the observations
# to Bonsai for training
function ApplyJobMask(s: SimState) {
    return constraint SimAction {
        Action: number<mask s.ActionMask>
    }
}

graph (input: SimState) {

    # The RemoveMask concept removes the data it doesn't need for learning.
    # You need to build this concept to make it work
    concept RemoveMask(input): LearningState {
        programmed function (s: SimState): LearningState {
            return LearningState(s)
        }
    }

    # Once the ActionMask and ModelTime are removed
    output concept MinimizeBlockTime(RemoveMask): SimAction {
        curriculum {

            source FlexSimSimulator
            mask ApplyJobMask

            training {
                EpisodeIterationLimit: 1000,
                NoProgressIterationLimit: 1000000,
            }

            goal (State: SimState) {
                # TODO: Add your goals here
                # Minimize or maximize something

                # This is a terrible goal that you should replace
                KeepElevatorEmpty:
                    minimize State.TotalInElevator
                    in Goal.RangeBelow(0)

                # This is also a terrible goal that you should remove or replace
                MakeLinesLong:
                    maximize State.TotalInLine
                    in Goal.RangeAbove(5)

                do (KeepElevatorEmpty and MakeLinesLong) until State.ModelTime > 3000
            }
        }
    }
}