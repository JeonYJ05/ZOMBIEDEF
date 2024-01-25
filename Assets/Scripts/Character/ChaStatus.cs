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
        private bool _isPause;
        public float ChaCurrentHealth;
        public Image HpBar;
        public int Money;

        public float _chaCurrentHealth { get { return ChaCurrentHealth; } }
        private void Awake()
        {
            _isPause = false;
            ChaCurrentHealth = MaxHealth;
            //HpBar.fillAmount = ChaCurrentHealth/MaxHealth;
            Money = 0;
        }

        private void FixedUpdate()
        {
            Pause();    
            HpBar.fillAmount = ChaCurrentHealth / MaxHealth;
            if(ChaCurrentHealth <= 0)
            {
                ChaCurrentHealth = 0;
                Death();
            }
            Money = UIGold.Gold;
        }
        private void Death()
        {
            _isPause = true;
        }
        private void Pause()
        {
            if(_isPause)
            {
                Time.timeScale = 0;
            }
            else if(!_isPause)
            {
                Time.timeScale = 1;
            }
        }

    }
}
