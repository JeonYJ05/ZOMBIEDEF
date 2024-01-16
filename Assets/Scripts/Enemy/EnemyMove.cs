using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using YJ.Zombie.Enemy;

namespace YJ.Zombie.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        private Transform _player;
        private NavMeshAgent _nav;
        [SerializeField] private float _trackingUpdateTime = 1f;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _nav = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            GetComponent<EnemyAnimation>().PlayAnimation("Walk");

            StartCoroutine(UpdateDestinationPosition());
        }

        private IEnumerator UpdateDestinationPosition()
        {
            var wait = new WaitForSeconds(_trackingUpdateTime);

            bool isDeath = false;
            while (!isDeath)
            {
                _nav.SetDestination(_player.position);
                yield return wait;
            }

            yield break;
        }
    }
}