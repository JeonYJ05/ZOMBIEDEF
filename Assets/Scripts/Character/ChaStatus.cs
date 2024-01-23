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
        public float ChaCurrentHealth;
        public Image HpBar;
        public int Money;

        public float _chaCurrentHealth { get { return ChaCurrentHealth; } }
        private void Awake()
        {
            ChaCurrentHealth = MaxHealth;
            //HpBar.fillAmount = ChaCurrentHealth/MaxHealth;
            Money = 0;
        }

        private void FixedUpdate()
        {
            HpBar.fillAmount = ChaCurrentHealth / MaxHealth;
            Money = UIGold.Gold;
        }


    }
}
