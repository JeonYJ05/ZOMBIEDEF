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

        private readonly Collider[] _checkPlayer = new Collider[0];
        public void Search()
        {
            #region 콜리더로 물리적으로 탐색하는법 오류 이유(공격을 안함)
           // int layer = 1 << LayerMask.NameToLayer("Player");
           // var count = Physics.OverlapSphereNonAlloc(transform.position, 5f, _checkPlayer, layer);
           //
           // if (count != 0)
           // {
           //     Collider value = _checkPlayer[0];
           //     float distance = Vector3.Distance(transform.position, value.transform.position);
           //     IsSearch = distance <= 2;
           //     for (int i = 0; i < count; ++i)
           //     {
           //         var target = _checkPlayer[i];
           //         float d = Vector3.Distance(transform.position, target.transform.position);
           //
           //         // 내가 이미 구한 길이보다 새로 구한 길이 값이 더 작으면 
           //         if (distance > d)
           //         {
           //             // 거리값과 대상 타겟을 갱신해준다.
           //             distance = d;
           //             value = target;
           //         }
           //         
           //     }
           //     return value;
           // }
           // return null;
            #endregion
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