using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameSystem
{

    public class GameLauncher : MonoBehaviour
    {

        [SerializeField] private GameManager gameManager; 

        [SerializeField] private CountDown countdown;

        private void OnEnable()
        {
            this.countdown.onEndCountdown += onEndCountdown; 
        }

        private void OnDisable()
        {
            this.countdown.onEndCountdown -= onEndCountdown;
        }

        private void onEndCountdown()
        {
            gameManager.StartGame(); 
        } 


    }

}
