using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameSystem
{
    public class MoveController : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private PlayerController _playerController;

        [SerializeField] private KeyboardInput _keyboardInput;

        [SerializeField] private MoveInput _inputMove;

        private float gutterWidth = 3f;
        private int[] roads = new int[] { 0, 1, 2 };

        private int _roadIndex = 1;

        void IGameStartListener.OnStartGame()
        {
            this._inputMove.OnMove += this.onMove; 
            this._keyboardInput.OnSideMove += this.onSideMove; 
        }

        void IGameFinishListener.OnFinishGame()
        {
            this._inputMove.OnMove += this.onMove; 
            this._keyboardInput.OnSideMove -= this.onSideMove; 
        }

        private void onSideMove(Vector2 direction)
        {
            this.SideMove(direction);
        }

        private void onMove()
        {
            var offset = Vector3.forward * Time.deltaTime; 
            this._playerController.Move(offset); 
        }

        private void SideMove(Vector2 direction)
        {
            var playerPosition = this._playerController.GetPosition();
            var targetPosition = new Vector3();
            targetPosition.y = playerPosition.y;
            targetPosition.z = playerPosition.z;

            if (direction == Vector2.left && _roadIndex > 0)
                _roadIndex--;

            if (direction == Vector2.right && _roadIndex < roads.Length - 1)
                _roadIndex++; 
            
            targetPosition.x += _roadIndex * gutterWidth;
            _playerController.SetPosition(targetPosition);

        }

    }

}