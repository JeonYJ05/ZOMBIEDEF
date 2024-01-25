using UnityEngine;
using System.Collections;
using YJ.Zombie.Bullets;
using YJ.Zombie.Enemy;

namespace YJ.Zombie.Cha
{
    public class ChaShoot : MonoBehaviour
    {
        [SerializeField] Transform _shootPoint;
        [SerializeField] ParticleSystem _muzzle;
        private Animator _anim;
        public int Damage;
        public float Range;
        public bool IsCanShoot = true;

        public Bullet CurrentBlueprint { get; set; } = null;

        private void Awake()
        {
            var path = "Prefabs/Bullets/BaseBullet";
            var bulletPrefab = Resources.Load<Bullet>(path);
            _anim = GetComponent<Animator>();

            CurrentBlueprint = bulletPrefab;
        }

        private IEnumerator PlayMuzzleDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            _muzzle.Play();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsCanShoot)
            {
                _anim.SetBool("Attack", true);
                Invoke("CreateBullet" , 0.2f);
                IsCanShoot = false;
                Invoke("CanShoot", 0.5f);
                StartCoroutine(PlayMuzzleDelayed(0.05f));
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                _anim.SetBool("Attack", false);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                IsCanShoot = false;
                Invoke("CanShoot", 0.5f);
            }
            
            
        }

        private void CreateBullet()
        {
            Bullet instance = Instantiate(CurrentBlueprint, _shootPoint.position, Quaternion.identity, null);
            
            
            instance.Create(Damage, Range, _shootPoint.right);

        }

        private void CanShoot()
        {
            IsCanShoot = true;
        }
    }
}
