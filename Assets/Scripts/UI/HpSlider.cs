using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YJ.Zombie.Status;

namespace YJ.Zombie.UI
{
    public class HpSlider : MonoBehaviour
    {
        [SerializeField] Slider _hpBar;
        [SerializeField] Text _text;
        private ChaStatus _chaHp;
        public static float HP;

        void Awake()
        {
            _chaHp = GetComponent<ChaStatus>();
            _text = GetComponent<Text>();
            _hpBar = GetComponent<Slider>();
        }
               
        private void Update()
        {
            _text.text = "HP : " + HP;
        }
    }
}
