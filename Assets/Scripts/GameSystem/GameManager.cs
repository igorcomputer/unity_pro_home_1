using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Assets.Scripts.GameSystem
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public sealed class GameManager : MonoBehaviour
    {
        private GameState State
        {
            get { return this.state; }
        }

        [ShowInInspector, ReadOnly]
        private GameState state;

        private readonly List<IGameListener> listeners = new();
        private readonly List<IGameUpdateListener> updateListeners = new();

        private void Update()
        {
            if (this.state != GameState.PLAYING)
                return;

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < updateListeners.Count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime); 
            }
        }

        public void AddListener(IGameListener listener)
        {
            if(listener == null)
            {
                return;
            }

            this.listeners.Add(listener);

            if(listener is IGameUpdateListener updateListener) 
            {
                this.updateListeners.Add(updateListener); 
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in this.listeners)
            {
                if(listener is IGameStartListener startListener){
                    startListener.OnStartGame();
                }
            }

            this.state = GameState.PLAYING;
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGamePauseListener pausetListener)
                {
                    pausetListener.OnPauseGame();
                }
            }

            this.state = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            this.state = GameState.PLAYING;

        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }

            this.state = GameState.FINISHED; 
        }
    }
}
