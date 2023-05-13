using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tanks
{
    public class EnemyMove : MonoBehaviour
    {
        private float timer;
        public float patrolTime;
        public int _speed;
        private DirectionType _type;
        private FireComponent _fire;

        void Start()
        {
            timer = 0;
            _type = DirectionType.Up;
            _fire = GetComponent<FireComponent>();
        }

        void Update()
        {
            
            if (timer > patrolTime) 
            {
                _type = ChangeDirection();
                timer = 0;
            }
            Move(_type);
            timer += Time.deltaTime;
            _fire.OnFire();
        }
        
        private void Move(DirectionType type)
        {
            transform.position = transform.position + Extensions.ConvertTypeFromDirection(type) * (Time.deltaTime * _speed);

        }
        private DirectionType ChangeDirection()
        { 
            int index = Random.Range(0, Extensions._directions.Count);
            DirectionType key = Extensions._directions.Keys.ElementAt(index);
            Vector3 value = Extensions._rotations[key];
            transform.rotation = Quaternion.Euler(value);
            return key;
        }
    }
}