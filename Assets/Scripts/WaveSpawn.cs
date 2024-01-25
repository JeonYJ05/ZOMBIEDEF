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
        void Start()
        {
            InvokeRepeating("SpawnEnemy", 0f, SpawnCycle);
        }

        void SpawnEnemy()
        {
            for (int i = 0; i < ResponeSpot.Length; i++)
            {
                Instantiate(Enemy, ResponeSpot[i].position, ResponeSpot[i].rotation);
            }
        }
    }
}