

using UnityEngine;

namespace Tanks
{

    [RequireComponent(typeof(MoveComponent))]
    public class ProjectileComponent : MonoBehaviour

    {
        private FireComponent _fire;

        public float _attackRange = 1f;

        [SerializeField]
        public AudioSource _brickSound;

        [SerializeField]
        public AudioSource _steelSound;

        [SerializeField]
        public AudioSource _tankSound;

        private SideType _side;
              
        private DirectionType _direction;
               
        private MoveComponent _moveComp;

        [SerializeField]
        private int _damage = 1;

        [SerializeField]
        private float _lifetime = 3f;

        [SerializeField]
        private float _speed = 50f;

       
       
        public UI_Manager _uiManager;


        public Rigidbody2D rb_bullet;


        public GameObject bulletPrefab;


        private void Start()
        {
            _fire = GetComponent<FireComponent>();
            _moveComp = GetComponent<MoveComponent>();
            Destroy (gameObject, _lifetime);
            _uiManager = FindObjectOfType<UI_Manager>();
        }

        private void Update() => rb_bullet.velocity = transform.up * _speed;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            var fire = collision.GetComponent<EnemyConditionComponent>();//бьет врага
            if (fire != null)
            {
                _tankSound.Play();
                var condition = fire.GetComponent<EnemyConditionComponent>();
                condition.SetDamageToEnemy(_damage);
                Debug.Log("Score+1");
                _uiManager.AddScore();
                Destroy(gameObject, 0.2f);
                return;
            }

            var fireEnemy = collision.GetComponent<PlayerConditionComponent>();//бьет игрока
            if (fireEnemy != null) 
            {
                _tankSound.Play();
                var condition = fireEnemy.GetComponent<PlayerConditionComponent>();
                condition.SetDamage(_damage);
                Destroy(gameObject, 0.2f);
                return;
            }


            var cell = collision.GetComponent<CellComponent>();
            if (cell != null)
            {

                if (cell.DestroyProjectile )
                {
                    _steelSound.Play();
                                      
                    Destroy(gameObject, 0.2f); 
                }
                    
                                    
                if (cell.DestroyCell )
                {
                    _brickSound.Play();
                    Debug.Log(_brickSound.enabled);
                    

                    Destroy(cell.gameObject, 0.2f);
                    return;
                }

            }

        }

    }
}
