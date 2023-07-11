using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameSystem
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] private float _speed = 2.5f;

        public void Move(Vector3 offset)
        {
            this.transform.position += offset * _speed;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }
    }

}
