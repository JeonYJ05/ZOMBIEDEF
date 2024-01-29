using System.Collections;
using UnityEngine;
using YJ.Zombie.Enemy;

namespace YJ.Zombie.Bullets
{
    public class Bullet : MonoBehaviour
    {
        protected float Damage = 100f;
        protected float Range = 0;
        protected float Speed = 5.0f;
        private Vector3 _position;
        private int _layerMask;

        public virtual void Create(float damage, float range, Vector3 dir)
        {
            _position = transform.position;

            Damage = damage;
            Range = range;

            transform.localRotation = Quaternion.LookRotation(dir);
            _layerMask = LayerMask.GetMask("Shootable");
        }

        private void Update()
        {
            Vector3 move = Speed * Time.deltaTime * Vector3.forward;
            transform.Translate(move);
            Invoke(nameof(DestroyBullet), 5f);
        }

        private void DestroyBullet()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<EnemyStatus>(out EnemyStatus enemy))
            {
                enemy.TakeDamage(Damage, "SmallZombie");
                enemy.TakeDamage(Damage, "MiddleZombie");
            }
            DestroyBullet();
        }
    }
}