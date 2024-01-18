using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YJ.Zombie.Enemy;

namespace YJ.Zombie.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        public bool IsSearch;
        public bool IsAttack;
        private float _attackDelay = 0.5f;
        private EnemyAnimation _animator;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _animator = GetComponent<EnemyAnimation>();
        }

        private void Update()
        {
            Search();

            if (IsSearch)
            {
                IsAttack = true;
                Invoke("AttackAni", _attackDelay);
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

            if (distance <= 3)
            {
                IsSearch = true;
            }
            else
            {
                IsSearch = false;
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
    }
}