using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _tankPrefab;
        public void InstantiateTank()
        {

            GameObject tank = Instantiate(_tankPrefab, transform.position, Quaternion.identity);
        }
    }
}