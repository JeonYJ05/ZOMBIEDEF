using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YJ.Zombie.Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] Transform _coin;
        public float MaxHealth = 100f;
        public float _currentHealth;
        public Image HealthBar;
        private bool _isDeath = false;
        private EnemyMove _move;
        private CapsuleCollider _colider;



        
        public float CurrentHealth { get { return _currentHealth; } }

        private void Start()
        {
            _move = GetComponent<EnemyMove>();
            _colider = GetComponent<CapsuleCollider>();
            _currentHealth = MaxHealth;
            
        }

        public void TakeDamage(float damage)
        {
            if (_isDeath)
                return;
            _currentHealth -= damage;
            HealthBar.fillAmount = _currentHealth / MaxHealth;
            
            // 피격 애니매이션
            if (_currentHealth <= 0f)
            {
                Death();
            }
            Debug.Log($"좀비의 피 :" + _currentHealth);
        }

        public void Death()
        {
            Vector3 CoinSpot = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            _isDeath = true;
            // 죽는 애니매이션
            _move.enabled = false;
            _colider.enabled = false;
            DestroyEnemy();
            Instantiate(_coin, CoinSpot , Quaternion.identity, null);
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject, 2f);
        }

       // private void Update()
       // {
       //     _hpSlider.transform.position = transform.position;
       // }
    }
    
}