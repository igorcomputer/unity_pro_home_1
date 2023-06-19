using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.GameSystem
{

    public sealed class KeyboardInput : MonoBehaviour, IGameUpdateListener
    {
        public Action<Vector2> onSideMove; 

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
            HandleKeyboard(); 
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.SideMove(Vector2.left); 
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.SideMove(Vector2.right); 
            }
        } 

        private void SideMove(Vector2 direction)
        {
            this.onSideMove?.Invoke(direction); 
        }

    }

}



