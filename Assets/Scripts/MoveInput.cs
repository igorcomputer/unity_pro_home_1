using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.GameSystem
{

    public class MoveInput : MonoBehaviour, IGameUpdateListener
    {
        public Action OnMove;

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
             this.Move();  
        }

        private void Move()
        {
            this.OnMove.Invoke();
        }
    }

}
