using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YJ.Zombie.GameManage
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject _spotEffect;
        [SerializeField] Transform _spot;
        public GameObject Ui;
        public static int GetKey;


        public int getKey { get { return GetKey; } }

        public void Awake()
        {
            GetKey = 0;
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Mission()
        {
            if(GetKey > 4)
            {
                Instantiate(_spotEffect, _spot.position, _spot.rotation);
            }
        }

        public void Toggle()
        {
            Ui.SetActive(!Ui.activeSelf);
            
            if(Ui.activeSelf)
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
