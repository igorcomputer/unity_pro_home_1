using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameSystem
{
    public class WallCreator : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private GameObject _objectToCreate;
        [SerializeField] private float _timeInterval = 1f;

        private float _timer = 0f;
        private Vector3Int _randomPosition;
        private int[] _roadsCoordsX = { 0, 3, 6 };

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;
            if (_timer >= _timeInterval)
            {
                int randomZ = Random.Range(1, 26);
                int randomXIndex = Random.Range(0, 3);

                _randomPosition = new Vector3Int(_roadsCoordsX[randomXIndex], 1, randomZ);

                Debug.Log(_randomPosition);

                Instantiate(_objectToCreate, _randomPosition, Quaternion.identity);
                _timer = 0f;
            }
        }

    }
}
