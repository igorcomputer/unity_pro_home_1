using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Assets.Scripts.GameSystem
{

    public class CountDownView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _countdownText;

        [SerializeField]
        private CountDownController _countDownController;

        private void OnEnable()
        {
            this._countDownController.OnChangeCountdown += OnChangeCountdown;
        }

        private void OnDisable()
        {
            this._countDownController.OnChangeCountdown -= OnChangeCountdown;
        }

        private void OnChangeCountdown(int value)
        {
            _countdownText.text = value.ToString();
        }


    }

}