using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameSystem
{
    public class WallCreator : MonoBehaviour, IGameUpdateListener
    {
        public GameObject objectToCreate;
        public float timeInterval = 1f;
        private float timer = 0f;
        private Vector3Int randomPosition;
        private int[] roadsCoordsX = { 0, 3, 6 };

        public void OnUpdate(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= timeInterval)
            {
                int randomZ = Random.Range(1, 26);
                int randomXIndex = Random.Range(0, 3);

                randomPosition = new Vector3Int(roadsCoordsX[randomXIndex], 1, randomZ);

                Debug.Log(randomPosition);

                Instantiate(objectToCreate, randomPosition, Quaternion.identity);
                timer = 0f;
            }
        }

    }
}
