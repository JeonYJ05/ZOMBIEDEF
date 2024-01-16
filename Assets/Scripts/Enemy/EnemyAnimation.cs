using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YJ.Zombie.Enemy
{
   public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();   
        }

        public void PlayAnimation(string clipName)
        {
            _animator.Play(clipName);   
        }
    }
}
