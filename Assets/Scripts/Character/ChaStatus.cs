using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YJ.Zombie.UI;
using UnityEngine.UI;

namespace YJ.Zombie.Status
{
    public class ChaStatus : MonoBehaviour
    {
       // [SerializeField] Slider _hpSlider;
        [SerializeField] float MaxHealth = 100;
        
        public int Money;
        public float _currentHealth;
        

        private void Awake()
        {
            _currentHealth = MaxHealth;
         //   _hpSlider.maxValue = MaxHealth;
            Money = 0;
        }

        private void Update()
        {
            Money = UIGold.Gold;
        }


    }
}
