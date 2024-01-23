using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJ.Zombie.Enemy
{
    public class WaveSpawn : MonoBehaviour
    {

        public Transform ResponeSpot;
        public GameObject Enemy;
        void Start()
        {
            InvokeRepeating("SpawnEnemy", 0f, 3f);
        }

        void SpawnEnemy()
        {
            Instantiate(Enemy, ResponeSpot.position, ResponeSpot.rotation);
        }
    }
}