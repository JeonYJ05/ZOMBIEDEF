using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YJ.Zombie.Status;
using YJ.Zombie.UI;

namespace YJ.Zombie.Item
{
    public class ItemCoin : BaseItem
    {
        public override ItemType ItemType => ItemType.Money;
        protected override void OnEffect(GameObject cha)
        {
            ChaStatus state = cha.GetComponent<ChaStatus>();
            UIGold.Gold += 100;
            Debug.Log("100골드 흭득");
        }
    }
}
