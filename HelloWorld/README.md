# HelloWorld

This project trains an AI to place boxes in the correct queue. Its purpose is to make sure your environment is correct.

## Installing Software
1. Install [FlexSim](account.flexsim.com/downloads) version 2024 or later
    * Activate a license. RL requires an active license.
1. Install [python](https://www.python.org/downloads/release/python-3117/) version 3.11. The link is at the bottom of the page.
    * Make sure the box to add python.exe to your path is checked
    * Make sure the box to install pip is checked
    * Verify your python version in a command prompt: `python --version`
1. Install [Visual Studio Code](https://code.visualstudio.com/)
1. Launch Visual Studio Code. Choose `File->Open Folder...` and choose the `HelloWorld` folder.
    1. Open the Extensions window: `View->Extensions`
    1. Search for and install the **Tensorboard** extension from Microsoft.
    1. Open the command palette: `View->Command Pallete...`
    1. In the Command Palette, type `Python: Select Interpreter` and choose that option. Then choose the python version you just installed.
    1. Open a new terminal: `Terminal->New Terminal`
    1. Run this command: `pip install stable-baselines3[extra]`

## Run the FlexSim Model

The FlexSim model is a simulator for a mini factory. Its purpose is to behave as the real system would behave, whether the decisions are good or bad.

* Open HelloWorld.fsm in FlexSim.
    * Verify that you have a license.
    * Investigate the Model Logic and RL Tool.
    * Run the model. Note that most boxes go to the "Incorrect" queue.
    * Verify that there is no stop time.
    * Close the model.

## Run flexsim_env.py

flexsim_env.py is a translator between stable-baselines3 (the training algorithm) and FlexSim. The training algorithm will make decisions. flexsim_env.py passes those decisions to FlexSim and then returns the reward and new observations.

* In Visual Studio Code, the HelloWorld folder
* Run flexsim_env.py to verify that the environment works

## Run flexsim_training.py

flexsim_training.py uses stable-baselines3 to train an agent using Reinforcement Leraning. The training algorithm tries random decisions at first and watches the reward value. The algorithm produces an agent that encodes what the algorithm learned.

The result of running htis script is a zip file, HelloWorld.zip. The zip file is the agent produced by training.

* Run flexsim_training.py
* While it's running, launch Tensorboard from the Command Palette: `Python: Launch Tensorboard`
* Watch the agent get more and more reward as training progresses.

## Run flexsim_inference.py

flexsim_inference.py creates an HTTP server. The server loads the agent. This means that you can send an obersvation to the server. The server will ask the agent for the best action given the observation and send that action as a response. In this case, we want to have the agent guide FlexSim's actions to see how good the agent is.

* Run flexsim_inference.py
* Open HelloWorld.fsm in FlexSim
* Change the ActionMode parameter from **Random** to **Server**
* Reset and run the model. Note that nearly all boxes go to the "Correct" queue
