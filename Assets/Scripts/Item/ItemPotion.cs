using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YJ.Zombie.Cha;
using YJ.Zombie.Status;

namespace YJ.Zombie.Items
{
    public class ItemPotion : BaseItem
    {
        public override ItemType ItemType => ItemType.Potion;

        protected override void OnEffect(GameObject cha)
        {
            ChaStatus state = cha.GetComponent<ChaStatus>();
            state.ChaCurrentHealth += 10;
            Debug.Log("체력 회복");
        }


    }
}
