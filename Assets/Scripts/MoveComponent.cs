using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;

        private InputComponent _inputComponent;

        
        public void OnMove(DirectionType type)


        {
            //_inputComponent._animator.SetFloat("speed", 1f);
            Debug.Log("Tank is moving");

            
            transform.position = transform.position + Extensions.ConvertTypeFromDirection(type) * (Time.deltaTime * _speed);
            transform.eulerAngles = Extensions.ConvertTypeFromRotation(type);

            
        }

        private void Start()
        {
            _inputComponent = GetComponent<InputComponent>();
            
        }

    }
}
