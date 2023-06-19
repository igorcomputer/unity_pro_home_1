using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Assets.Scripts.GameSystem
{

    public class CountDown : MonoBehaviour
    {
        public Action onEndCountdown;
        public Action<int> onChangeCountdown;

        [SerializeField]
        private int countdownTimeDefault = 5;

        [SerializeField]
        private int countdownTime = 0; // current value 

        public void StartCountDown()
        {
            ResetCountdown(); 
            StartCoroutine("Countdown"); 
        }

        IEnumerator Countdown()
        {
            while (countdownTime > 0)
            {
                //this.onChangeCountdown?.Invoke(countdownTime);
                yield return new WaitForSeconds(1f);
                countdownTime--;
                if (countdownTime == 0)
                {
                    this.onEndCountdown?.Invoke(); 
                }
                this.onChangeCountdown?.Invoke(countdownTime);
            }
        }

        private void ResetCountdown()
        {
            this.countdownTime = countdownTimeDefault;
            this.onChangeCountdown?.Invoke(countdownTimeDefault);
        }

    }

}
