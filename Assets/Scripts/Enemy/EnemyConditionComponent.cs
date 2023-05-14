using System.Collections;
using System.Collections.Generic;
using Tanks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Tanks
{

    [RequireComponent(typeof(SpriteRenderer))]

    public class EnemyConditionComponent : ConditionComponent
    {
        private int _enemyHealth = 2;
        private bool isImmortal;
        private SpriteRenderer _renderer;

        [SerializeField]
        private float _immortalTime = 3f;
        [SerializeField]
        private float _immortalSwitch = 0.2f;
        private SpawnManager _spawnManager;

        private void Start()
        {
            _spawnManager = FindObjectOfType<SpawnManager>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void SetDamageToEnemy(int damage)
        {
            if (isImmortal) return;

            _enemyHealth -= damage;
            Debug.Log("Enemy is shot");

            StartCoroutine(OnImmortal());

            if (_enemyHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("EnemyTank is destroyed");
                _spawnManager._currentEnemies--;
            }

        }

        private IEnumerator OnImmortal()
        {
            isImmortal = true;
            var time = _immortalTime;
            while (time > 0f)
            {
                _renderer.enabled = !_renderer.enabled;
                time -= Time.deltaTime;
                yield return new WaitForSeconds(_immortalSwitch);
            }
            isImmortal = false;
            _renderer.enabled = true;
        }


    }
}

