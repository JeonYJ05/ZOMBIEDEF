using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YJ.Zombie.GameManage;
using UnityEngine.UI;
using YJ.Zombie.UI;

namespace YJ.Zombie.Item
{
    public class ItemKey : BaseItem
    {
        public override ItemType ItemType => ItemType.Key;
        protected override void OnEffect(GameObject cha)
        {
            GameManager.GetKey += 3;
            Debug.Log($"현재 열쇠갯수 = " + GameManager.GetKey);
        }
    }
}
