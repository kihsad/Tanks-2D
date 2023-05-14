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
        [SerializeField]
        private LayerMask _layerMask;
        public Vector2 _size;
        public float _angle;
        private float timer;
        public float patrolTime;
        public int _speed;
        private DirectionType _type;
        private FireComponent _fire;
        private Collider2D _collider;
        void Start()
        {
            timer = 0;
            _type = DirectionType.Up;
            _fire = GetComponent<FireComponent>();
            _collider = null;
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
            _collider = Physics2D.OverlapBox(transform.position, _size, _angle, _layerMask);
            if (_collider == null)
                transform.position = transform.position + Extensions.ConvertTypeFromDirection(type) * (Time.deltaTime * _speed);
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _collider.transform.position, _speed * Time.deltaTime);
            }
        }
        private DirectionType ChangeDirection()
        { 
            int index = Random.Range(0, Extensions._directions.Count);
            DirectionType key = Extensions._directions.Keys.ElementAt(index);
            Vector3 value = Extensions._rotations[key];
            transform.rotation = Quaternion.Euler(value);
            return key;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _size);
        }
    }
}