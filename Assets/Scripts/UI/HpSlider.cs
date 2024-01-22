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
        public static float HP;
        void Start()
        {
            _text = GetComponent<Text>();
            _hpBar = GetComponent<Slider>();
            HP = 100;
        }

        // Update is called once per frame
        private void UpdateText()
        {
            _text.text = "HP : " + HP;
        }
    }
}
