using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class ConditionComponent : MonoBehaviour
    {

        [SerializeField]
        public int _health = 3;

        public UI_Manager _uiManager;
        public virtual void SetDamage(int damage)
        {
            _uiManager = FindObjectOfType<UI_Manager>();
            _health -= damage;

            _uiManager.ShowHealth();
            Debug.Log("Health - 1");

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
