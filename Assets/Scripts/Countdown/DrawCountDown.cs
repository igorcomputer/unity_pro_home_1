using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Assets.Scripts.GameSystem
{

    public class DrawCountDown : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI CountdownText;

        [SerializeField]
        private CountDown countdown;

        private void OnEnable()
        {
            this.countdown.onChangeCountdown += onChangeCountdown;
        }

        private void OnDisable()
        {
            this.countdown.onChangeCountdown -= onChangeCountdown;
        }

        private void onChangeCountdown(int value)
        {
            CountdownText.text = value.ToString();
        }


    }

}