using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YJ.Zombie.UI
{
    public class UIGold : MonoBehaviour
    {
        private Text _goldTxt;
        public static int Gold;

        private void Awake()
        {
            _goldTxt = GetComponent<Text>();
            Gold = 0;
        }
        private void Update()
        {
            _goldTxt.text = " =   " + Gold;
        }
    }
}
