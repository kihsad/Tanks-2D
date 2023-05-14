using System.Collections;
using UnityEngine;



namespace Tanks
{
    public class FireComponent : MonoBehaviour
    {
        public LayerMask _enemyLayer;
        private bool _canFire = true;

        public AudioSource shootSound;

        [SerializeField, Range(0.1f, 2f)]
        private float _delayFire = 2f;

        [SerializeField]
        private ProjectileComponent _prefab;

        [SerializeField]
        private SideType _side;
              
        public Transform _firePoint;

        public GameObject _bulletPrefab;

        public SideType GetSide => _side;

        public void OnFire()
        {
            if (!_canFire) return;

            if (_canFire) Fire();

        }

        public void Fire()
        {
            shootSound.Play();
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            StartCoroutine(OnDelay());

        }


        private IEnumerator OnDelay()
        {
            _canFire= false;

            yield return new WaitForSeconds(_delayFire);

            _canFire= true;
        } 

    }
}
