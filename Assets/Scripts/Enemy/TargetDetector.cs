using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;
        private int _speed;
        private EnemyMove _enemy;
        public Vector2 _size;
        public float _angle;
        private Collider2D _collider;
        private void Start()
        {
            _enemy = GetComponent<EnemyMove>();
        }

        private void FixedUpdate()
        {
            Detect();
        }
        public void Detect()    
        {
            _collider = Physics2D.OverlapBox(transform.position, _size, _angle, _layerMask);
            transform.position = Vector2.MoveTowards(transform.position, _collider.transform.position, _enemy._speed * Time.deltaTime);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _size);
        }
    }
}