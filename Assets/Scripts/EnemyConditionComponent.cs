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
        private int _enemyHealth = 5;

        private bool isImmortal;
        //private Vector3 _startPoint;

        private SpriteRenderer _renderer;



        [SerializeField]
        private float _immortalTime = 3f;
        [SerializeField]
        private float _immortalSwitch = 0.2f;

        private void Start()
        {

            //_startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void SetDamageToEnemy(int damage)
        {
            if (isImmortal) return;

            _enemyHealth -= damage;
            //transform.position = _startPoint;

            Debug.Log("Enemy is shot");

            StartCoroutine(OnImmortal());


            if (_enemyHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("EnemyTank is destroyed");
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

