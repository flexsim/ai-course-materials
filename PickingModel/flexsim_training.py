import gymnasium as gym
from flexsim_env import FlexSimEnv
from stable_baselines3 import PPO
import paths

def main():
    print("Initializing FlexSim environment...")

    # Create a FlexSim OpenAI Gym Environment
    env = FlexSimEnv(
        flexsimPath = paths.flexsim,
        modelPath = paths.model,
        verbose = False,
        visible = False
        )

    # Training a baselines3 PPO model in the environment
    model = PPO("MlpPolicy", env, verbose=1, tensorboard_log=paths.tensorboard)
    print("Training model...")
    model.learn(total_timesteps=100000)
    
    # save the model
    print("Saving model...")
    model.save(paths.agent)

    input("Waiting for input to do some test runs...")

    # Run test episodes using the trained model
    for i in range(2):
        env.seed(i)
        observation, info = env.reset()
        env.render()
        done = False
        rewards = []
        while not done:
            action, _states = model.predict(observation)
            observation, reward, done, truncated, _ = env.step(action)
            env.render()
            rewards.append(reward)
            if done:
                cumulative_reward = sum(rewards)
                print("Reward: ", cumulative_reward, "\n")
    env._release_flexsim()
    input("Waiting for input to close FlexSim...")
    env.close()


if __name__ == "__main__":
    main()