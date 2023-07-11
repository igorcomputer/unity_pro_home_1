using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameSystem
{
    public class CollisionObserver : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("wall")) 
            {
                _gameManager.FinishGame();  
                Debug.Log("Game Over!"); 
            }
        }
    }
}