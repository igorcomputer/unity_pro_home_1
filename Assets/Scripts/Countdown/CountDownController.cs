using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Assets.Scripts.GameSystem
{

    public class CountDownController : MonoBehaviour
    {
        public Action OnEndCountdown;
        public Action<int> OnChangeCountdown;

        [SerializeField] private int _countdownTimeDefault = 5;

        [SerializeField] private int _countdownTime = 0;

        [SerializeField] private GameManager _gameManager;

        public void PauseGame() 
        {
            ResetCountdown();
            _gameManager.PauseGame(); 
        }

        public void StartCountDown()
        {
            ResetCountdown(); 
            StartCoroutine("Countdown"); 
        }

        IEnumerator Countdown()
        {
            while (_countdownTime > 0)
            {
                //this.onChangeCountdown?.Invoke(countdownTime);
                yield return new WaitForSeconds(1f);
                _countdownTime--;
                if (_countdownTime == 0)
                {
                    _gameManager.StartGame();
                }
                this.OnChangeCountdown?.Invoke(_countdownTime); 
            }
        }

        private void ResetCountdown()
        {
            this._countdownTime = _countdownTimeDefault;
            this.OnChangeCountdown?.Invoke(_countdownTimeDefault);
        }

    }

}
