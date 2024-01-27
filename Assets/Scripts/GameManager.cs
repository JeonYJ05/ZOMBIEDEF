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
        [Header("Mission Spot")]
        [SerializeField] GameObject _spotEffect;
        [SerializeField] Transform _spot;
        private GameObject Spot;

        [Header("Menu")]
        public GameObject Ui;
        public static int GetKey;

        // 유니티 싱글톤화 GameManager
        public int getKey { get { return GetKey; } }

        public void Awake()
        {
            GetKey = 0;
        }
        private void Update()
        {
            Mission();    

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Mission()
        {
            if (GetKey >= 5 && Spot == null)
            {
                Spot = (GameObject)Instantiate(_spotEffect, _spot.position, _spot.rotation);
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
