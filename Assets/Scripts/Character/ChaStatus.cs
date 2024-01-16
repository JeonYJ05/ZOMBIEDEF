using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YJ.Zombie.UI;

namespace YJ.Zombie.Status
{
    public class ChaStatus : MonoBehaviour
    {
        public int Money;

        private void Start()
        {
            Money = 0;
        }

        private void Update()
        {
            Money = UIGold.Gold;
        }


    }
}
