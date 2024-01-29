using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// enemis로 수정 
namespace YJ.Zombie.Enemy 
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] Transform _coin;
        [SerializeField] Transform _potion;
        [SerializeField] Transform _key;
        
        public float MaxHealth;
        public float _currentHealth;
        public Image HealthBar;
        public float Damage;
        public bool _isDeath = false;
        private Zombie _currentZombieType;
        private EnemyMove _move;
        private CapsuleCollider _colider;
        private int _dropP;


        public Dictionary<string, Zombie> Zombies = new Dictionary<string, Zombie>();



        
        public float EnemyCurrentHealth { get { return _currentHealth; } }

        private void Awake()
        {
            _move = GetComponent<EnemyMove>();
            _colider = GetComponent<CapsuleCollider>();

            Zombies.Add("SmallZombie", new Zombie { ZombieType = "SmallZombie", MaxHealth = 100, Damage = 10 });
            Zombies.Add("MiddleZombie", new Zombie { ZombieType = "MiddleZombie", MaxHealth = 150, Damage = 20 });
            _currentZombieType = Zombies["SmallZombie"];
            MaxHealth = _currentZombieType.MaxHealth;
            Damage = _currentZombieType.Damage;
            _currentHealth = MaxHealth;
        }


        public void TakeDamage(float Damage, string ZombieType)
        {
            if (_isDeath)
                return;

            Zombie zombie;
            if(Zombies.TryGetValue(ZombieType, out zombie))
            {
            _currentHealth -= Damage;
            HealthBar.fillAmount = _currentHealth / MaxHealth;
            }
            // 피격 애니매이션
            if (_currentHealth <= 0f)
            {
                Death(ZombieType);
            }
            Debug.Log($"좀비의 피 :" + _currentHealth);
        }

        public void Death(string zombieType)
        {
            _isDeath = true;
            _move.enabled = false;
            _colider.enabled = false;
            ItemDrop(zombieType);
            DestroyEnemy();
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject, 2f);
        }

        public void ItemDrop(string zombieType)
        {
            Vector3 DropSpot = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            _dropP = Random.Range(0, 3);
            if (zombieType == "SmallZombie")
            {
                if (_dropP == 0)
                {
                    Instantiate(_potion, DropSpot, Quaternion.identity, null);
                }
                if (_dropP == 1)
                {
                    Instantiate(_coin, DropSpot, Quaternion.identity, null);
                }
                if (_dropP == 2)
                {
                    Instantiate(_key, DropSpot, Quaternion.identity, null);
                }
            }
        }
       
    }
    
}