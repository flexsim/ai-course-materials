import gym
from flexsim_env import FSEE
from stable_baselines3 import PPO
from stable_baselines3.common.env_util import make_vec_env
from stable_baselines3.common.callbacks import EvalCallback

def main():
    print("Initializing FlexSim environment...")

    # Create a FlexSim OpenAI Gym Environment
    env = FSEE()
   
    # Training a baselines3 PPO model in the environment
    model = PPO("MlpPolicy", env, verbose=1, tensorboard_log="./tensorboard/")
    print("Training model...")

    # add an evalCallback, which will save the model from time to time
    evalCallback = EvalCallback(env, best_model_save_path="./best_models/", eval_freq=10000)

    model.learn(total_timesteps=100000, callback=evalCallback)
    
    # save the model
    print("Saving model...")
    model.save("MyTrainedModel")

    # Run test episodes using the trained model
    # input("Waiting for input to do some test runs...")
    # for i in range(2):
    #     env.seed(i)
    #     observation = env.reset()
    #     env.render()
    #     done = False
    #     rewards = []
    #     while not done:
    #         action, _states = model.predict(observation)
    #         observation, reward, done, info = env.step(action)
    #         env.render()
    #         rewards.append(reward)
    #         if done:
    #             cumulative_reward = sum(rewards)
    #             print("Reward: ", cumulative_reward, "\n")
    # env._release_flexsim()
    # input("Waiting for input to close FlexSim...")
    # env.close()


if __name__ == "__main__":
    main()