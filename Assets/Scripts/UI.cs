using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameSystem
{

    public class UI : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonPause;
        [SerializeField] private CountDownController _countDownController;

        private void Awake()
        {
            _buttonStart.onClick.AddListener(OnButtonStartClicked);
            _buttonPause.onClick.AddListener(OnButtonPauseClicked);
        }

        private void OnButtonPauseClicked()
        {
            _countDownController.PauseGame();
        }

        private void OnButtonStartClicked()
        {
            _countDownController.StartCountDown();
        }
    }

}
