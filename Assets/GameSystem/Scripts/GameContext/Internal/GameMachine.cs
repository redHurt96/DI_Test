using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public enum GameState
    {
        OFF = 0,
        PLAY = 1,
        PAUSE = 2,
        FINISH = 3,
    }

    public interface IGameMachine
    {
        GameState GameState { get; }

        void StartGame();

        void PauseGame();

        void ResumeGame();

        void FinishGame();

        void AddListener(object listener);

        void AddListeners(IEnumerable<object> listeners);

        void RemoveListener(object listener);
    }

    internal sealed class GameMachine : IGameMachine
    {
        public GameState GameState
        {
            get { return this.gameState; }
        }

        private readonly List<object> listeners = new();

        private GameState gameState = GameState.OFF;

        public void StartGame()
        {
            if (this.gameState != GameState.OFF)
            {
                Debug.LogWarning($"You can start game only from {GameState.OFF} state!");
                return;
            }

            this.gameState = GameState.PLAY;

            foreach (var listener in this.listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
        }

        public void PauseGame()
        {
            if (this.gameState != GameState.PLAY)
            {
                Debug.LogWarning($"You can pause game only from {GameState.PLAY} state!");
                return;
            }

            this.gameState = GameState.PAUSE;

            foreach (var listener in this.listeners)
            {
                if (listener is IPauseGameListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (this.gameState != GameState.PAUSE)
            {
                Debug.LogWarning($"You can resume game only from {GameState.PAUSE} state!");
                return;
            }

            this.gameState = GameState.PLAY;

            foreach (var listener in this.listeners)
            {
                if (listener is IResumeGameListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (this.gameState != GameState.PLAY)
            {
                Debug.LogWarning($"You can finish game only from {GameState.PLAY} state!");
                return;
            }

            this.gameState = GameState.FINISH;

            foreach (var listener in this.listeners)
            {
                if (listener is IFinishGameListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
        }
        
        public void AddListeners(IEnumerable<object> listeners)
        {
            this.listeners.AddRange(listeners);
        }

        public void AddListener(object listener)
        {
            this.listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            this.listeners.Remove(listener);
        }
    }
}