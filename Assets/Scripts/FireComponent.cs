using System.Collections;
using UnityEngine;



namespace Tanks
{
    public class FireComponent : MonoBehaviour
    {

        private bool _canFire = true;

        [SerializeField, Range(0.1f, 1f)]
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

            //var bullet = Instantiate(_prefab, _firePoint.position, _firePoint.rotation);
            //bullet.SetParams(transform.eulerAngles.ConvertDirectionFromType(), _side);

            Fire();
            StartCoroutine(OnDelay());

        }

        public void Fire()
        {
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        }


        private IEnumerator OnDelay()
        {
            _canFire= false;

            yield return new WaitForSeconds(_delayFire);

            _canFire= true;
        } 

    }
}
