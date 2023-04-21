using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameContext : MonoBehaviour, IGameLocator, IGameMachine
    {
        private readonly GameMachine gameMachine = new();

        private readonly GameLocator serviceLocator = new();

        private readonly List<IUpdateGameListener> updateListeners = new();

        public GameState GameState
        {
            get { return this.gameMachine.GameState; }
        }

        public GameContext()
        {
            this.serviceLocator.AddService(this.gameMachine);
        }

        private void Awake()
        {
            this.enabled = false;
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }

        public void StartGame()
        {
            this.gameMachine.StartGame();
            this.enabled = true;
        }

        public void PauseGame()
        {
            this.gameMachine.PauseGame();
            this.enabled = false;
        }

        public void ResumeGame()
        {
            this.gameMachine.ResumeGame();
            this.enabled = true;
        }

        public void FinishGame()
        {
            this.gameMachine.FinishGame();
            this.enabled = false;
        }

        public void AddListener(object listener)
        {
            this.gameMachine.AddListener(listener);

            if (listener is IUpdateGameListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }
        }

        public void RemoveListener(object listener)
        {
            this.gameMachine.RemoveListener(listener);

            if (listener is IUpdateGameListener updateListener)
            {
                this.updateListeners.Remove(updateListener);
            }
        }

        public void AddListeners(IEnumerable<object> listeners)
        {
            foreach (var listener in listeners)
            {
                this.AddListener(listener);
            }
        }

        public void AddService(object service)
        {
            this.serviceLocator.AddService(service);
        }

        public void AddServices(IEnumerable<object> services)
        {
            this.serviceLocator.AddServices(services);
        }

        public void RemoveService(object service)
        {
            this.serviceLocator.RemoveService(service);
        }

        public T GetService<T>()
        {
            return this.serviceLocator.GetService<T>();
        }
    }
}