using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class PlayerConditionComponent : ConditionComponent
    {
        private bool isImmortal;
        private Vector3 _startPoint;

        private SpriteRenderer _renderer;

        [SerializeField]
        private float _immortalTime = 3f;
        [SerializeField]
        private float _immortalSwitch = 0.2f;

        private void Start()
        {
            _startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
        }

        public override void SetDamage(int damage)
        {
            if (isImmortal) return;

            _health -= damage;
            transform.position = _startPoint;
            StartCoroutine(OnImmortal());
                     

            if (_health <= 0)
            {
                 Destroy(gameObject);
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
