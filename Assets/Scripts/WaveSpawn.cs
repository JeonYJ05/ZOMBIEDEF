using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJ.Zombie.Enemy
{
    public class WaveSpawn : MonoBehaviour
    {
        public Transform[] ResponeSpot;
        public int SpawnCycle;
        public GameObject Enemy;
        private EnemyStatus _enemyStatus;
        void Start()
        {
            _enemyStatus = GetComponent<EnemyStatus>();
            InvokeRepeating("SpawnEnemy", 0f, SpawnCycle);
        }

        void SpawnEnemy()
        {
            for (int i = 0; i < ResponeSpot.Length; i++)
            {
                Zombie smallZombie = _enemyStatus.Zombies["SmallZombie"];
                
                GameObject SpawnedSmall = Instantiate(Enemy, ResponeSpot[i].position, ResponeSpot[i].rotation);
                EnemyStatus SmallStatus = SpawnedSmall.GetComponent<EnemyStatus>();
                SmallStatus.MaxHealth = smallZombie.MaxHealth;
                SmallStatus.Damage = smallZombie.Damage;
            }
        }
    }
}