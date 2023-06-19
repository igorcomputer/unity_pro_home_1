using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameSystem
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("wall")) 
            {
                gameManager.FinishGame();  
                Debug.Log("Game Over!"); 
            }
        }
    }
}