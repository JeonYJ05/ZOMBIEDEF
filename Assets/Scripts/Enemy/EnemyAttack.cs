using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YJ.Zombie.Enemy;
using YJ.Zombie.Cha;
using YJ.Zombie.Status;
using YJ.Zombie.UI;
using UnityEngine.UI;

namespace YJ.Zombie.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        [SerializeField] Slider _healthBar;
        public bool IsSearch;
        public bool IsAttack;
        private EnemyAnimation _animator;
        private EnemyStatus _enemyStatus;
        private ChaStatus _chaHp;
        private Zombie _zombie;
        private float _attackTimer;
        private float _attackInterval = 2f;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _animator = GetComponent<EnemyAnimation>();
            _enemyStatus = GetComponent<EnemyStatus>();
            _chaHp = GetComponent<ChaStatus>();
            _zombie = GetComponent<Zombie>();
        }

        private void Update()
        {
            Search();

            if (IsSearch)
            {
                IsAttack = true;
                _attackTimer += Time.deltaTime;
                if(_attackTimer >= _attackInterval)
                {
                    Attack();
                    _attackTimer = 0f;
                }
            }
            else if(_enemyStatus._isDeath)
            {
                DeathAni();
            }
            else
            {
                IsAttack = false;
                MoveAni();
            }
        }

        public void Search()
        {
            float distance = Vector3.Distance(transform.position, _player.transform.position);
            IsSearch = distance <= 2;
         //   삼항연산자 줄임   
         //   if (distance <= 2  )
         //   {
         //       IsSearch = true;
         //   }
         //   else
         //   {
         //       IsSearch = false;
         //   }
        }
        private void Attack()
        {
            if (IsAttack)
            {
                if (_chaHp == null)
                {
                    _chaHp = FindObjectOfType<ChaStatus>();
                }
                else if (_chaHp != null)
                {
                    AttackAni();
                    _chaHp.ChaCurrentHealth -= 10f;
                    Debug.Log("현재 HP : " + _chaHp.ChaCurrentHealth);
                }
            }
        }
        private void AttackAni()
        {
            _animator.PlayAnimation("Z_Attack");
        }
        private void MoveAni()
        {
            _animator.PlayAnimation("Z_Run");
        }
        private void DeathAni()
        {
            _animator.PlayAnimation("Z_FallingBack");
        }
    }
}