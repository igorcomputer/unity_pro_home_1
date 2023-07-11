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
            get { return this._state; }
        }

        [ShowInInspector, ReadOnly]
        private GameState _state;

        private readonly List<IGameListener> _listeners = new();
        private readonly List<IGameUpdateListener> _updateListeners = new();

        private void Update()
        {
            if (this._state != GameState.PLAYING)
                return;

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                var listener = this._updateListeners[i];
                listener.OnUpdate(deltaTime); 
            }
        }

        public void AddListener(IGameListener listener)
        {
            if(listener == null)
            {
                return;
            }

            this._listeners.Add(listener);

            if(listener is IGameUpdateListener updateListener) 
            {
                this._updateListeners.Add(updateListener); 
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in this._listeners)
            {
                if(listener is IGameStartListener startListener){
                    startListener.OnStartGame();
                }
            }

            this._state = GameState.PLAYING;
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in this._listeners)
            {
                if (listener is IGamePauseListener pausetListener)
                {
                    pausetListener.OnPauseGame();
                }
            }

            this._state = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in this._listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            this._state = GameState.PLAYING;

        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in this._listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }

            this._state = GameState.FINISHED; 
        }
    }
}
