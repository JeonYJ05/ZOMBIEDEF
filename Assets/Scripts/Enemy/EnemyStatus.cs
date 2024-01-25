using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YJ.Zombie.Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] Transform _coin;
        [SerializeField] Transform _potion;
        [SerializeField] Transform _key;

        public float MaxHealth = 100f;
        public float _currentHealth;
        public Image HealthBar;
        public bool _isDeath = false;
        private EnemyMove _move;
        private CapsuleCollider _colider;
        private int _dropP;



        
        public float EnemyCurrentHealth { get { return _currentHealth; } }

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
            _isDeath = true;
            _move.enabled = false;
            _colider.enabled = false;
            ItemDrop();
            DestroyEnemy();
            
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject, 2f);
        }

        public void ItemDrop()
        {
            Vector3 DropSpot = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            _dropP = Random.Range(0, 2);
            if (_dropP == 0)
            {
                Instantiate(_potion, DropSpot, Quaternion.identity, null);
            }
           // if (_dropP == 1)
           // {
           //     Instantiate(_coin, DropSpot, Quaternion.identity, null);
           // }
            if (_dropP == 1)
            {
                Instantiate(_key, DropSpot, Quaternion.identity, null);
            }

        }
    }
    
}