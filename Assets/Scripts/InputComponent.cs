using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace Tanks
{

    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]


    public class InputComponent : MonoBehaviour
    {
        private DirectionType _lastType;
        
        private MoveComponent _moveComp;

        private FireComponent _fireComp;

        public Animator _animator;

        [SerializeField]
        private InputAction _move;
        [SerializeField]
        private InputAction _fire;
        [SerializeField]
        private InputAction _escToMenu;

        [SerializeField]
        private InputAction _explode;

        private void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            _fireComp = GetComponent<FireComponent>();

            _move.Enable();
            _fire.Enable();
            _escToMenu.Enable();
            _explode.Enable();

            
        }

        private void Update() 
        {
            var fire = _fire.ReadValue<float>();

            if (fire == 1f) _fireComp.OnFire();

            var escToMenu = _escToMenu.ReadValue<float>();

            if (escToMenu == 1f)
            {
                onEscToMenu();
            }

            var explode = _explode.ReadValue<float>();
            if (explode == 1f) onExplosion();

            var direction = _move.ReadValue<Vector2>();
            DirectionType type;

            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;

            else type = _lastType = Extensions.ConvertDirectionFromType(direction);
            
            _moveComp.OnMove(type);
            _animator.SetFloat("speed", 1f);

        }


        private void OnDestroy()
        {
            
            _move.Dispose();
            _fire.Dispose();
                        
        }

        private void onEscToMenu()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }

        public void onExplosion()
        {
            _animator.SetFloat("death", 1);
        }
    }
}
