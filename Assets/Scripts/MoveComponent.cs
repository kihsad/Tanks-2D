using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private Animator _animator;

        public void OnMove(DirectionType type)


        {
            _animator.SetBool("isMoving", true);
            
            transform.position = transform.position + Extensions.ConvertTypeFromDirection(type) * (Time.deltaTime * _speed);
            transform.eulerAngles = Extensions.ConvertTypeFromRotation(type);
        }

    }
}
