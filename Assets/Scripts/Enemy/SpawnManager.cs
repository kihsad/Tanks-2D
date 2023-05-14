using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _enemy;
        [SerializeField]
        private Transform[] _spawn;

        public float _startSpawnerInterval;
        private float _spawnerInterval;

        public int _numberOfEnemies;
        public int _currentEnemies;

        private int _randEnemy;
        private int _randPoint;

        private void Start()
        {
            _spawnerInterval = _startSpawnerInterval;
        }

        private void Update()
        {
            if (_spawnerInterval <= 0 && _currentEnemies < _numberOfEnemies)
            {
                _randEnemy = Random.Range(0, _enemy.Length);
                _randPoint = Random.Range(0, _spawn.Length);

                Instantiate(_enemy[_randEnemy], _spawn[_randPoint].transform.position, Quaternion.identity);

                _spawnerInterval = _startSpawnerInterval;
                _currentEnemies++;

            }
            else
            {
                _spawnerInterval -= Time.deltaTime;
            }

         
        }
    }
}