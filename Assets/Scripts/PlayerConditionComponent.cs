using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class PlayerConditionComponent : MonoBehaviour
    {
        private bool isImmortal;
        private Vector3 _startPoint;

        public int _health = 3;

        private SpriteRenderer _renderer;

        [SerializeField]
        private GameObject GO_UIpanel;

        public Animator _animator;
       
        [SerializeField]
        private float _immortalTime = 3f;
        [SerializeField]
        private float _immortalSwitch = 0.2f;
        [SerializeField]
        private int _playerScore;

        public int Lives
        {
            get { return _health; } 
            set 
            {
                if (value < 3) _health = value;
                healthBar.RefreshHealthHearts();
            }
        }

        private HealthBar healthBar;

        private void Start()
        {
          
            _startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
            GO_UIpanel.SetActive(false);
        }

        public void SetDamage(int damage)
        {
            if (isImmortal) return;

            Lives -= damage;
            transform.position = _startPoint;
            
            StartCoroutine(OnImmortal());

            Debug.Log("Player is shot");

            if (_health <= 0)
            {
                _animator.SetFloat("death", 1f);

                Destroy(gameObject);

                Debug.Log("Tank is destroyed");

                GO_UIpanel.SetActive(true);
                Time.timeScale = 0;
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

        private void Awake()
        {
            healthBar = FindObjectOfType<HealthBar>();
        }

    }
}
