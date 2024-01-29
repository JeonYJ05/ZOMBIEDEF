using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YJ.Zombie.GameManage
{
    public class Gate : MonoBehaviour
    {
        public GameObject Ui;
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
            {
                Debug.Log("다음 단계");
                Toggle();
            }
           
        }
        public void Toggle()
        {
            Ui.SetActive(!Ui.activeSelf);

            if (Ui.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

        }
    }
}
