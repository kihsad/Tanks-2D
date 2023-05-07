

using UnityEngine;

namespace Tanks
{

    [RequireComponent(typeof(MoveComponent))]
    public class ProjectileComponent : MonoBehaviour

    {
       
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


            //rb_bullet.velocity = transform.up * _speed;

            _moveComp= GetComponent<MoveComponent>();
            Destroy (gameObject, _lifetime);

            _uiManager = FindObjectOfType<UI_Manager>();
            
        }

        //public void SetParams(DirectionType direction, SideType side)
        //{
        //    (_direction, _side) = (direction, side);
        //}


        private void Update() => rb_bullet.velocity = transform.up * _speed;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            var fire = collision.GetComponent<FireComponent>(); 
            if (fire != null)
            {
                if (fire.GetSide == _side) return;

                var condition = fire.GetComponent<ConditionComponent>();
                condition.SetDamage(_damage);
                Debug.Log("Score+1");
                _uiManager.AddScore();
                Destroy(gameObject);
                return;
            }

            var cell = collision.GetComponent<CellComponent>();
            if (cell != null)
            {

                if (cell.DestroyProjectile) Destroy(gameObject);
                if (cell.DestroyCell) Destroy(cell.gameObject);
                return;
            }





        }

    }
}
