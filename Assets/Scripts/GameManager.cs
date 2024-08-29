﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YJ.Zombie.GameManage
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Mission Spot")]
        [SerializeField] GameObject _spotEffect;
        [SerializeField] Transform _spot;
        private GameObject Spot;

        [Header("Menu")]
        public GameObject MainUi;
        public static int GetKey;

        // 유니티 싱글톤화 GameManager
        public int getKey { get { return GetKey; } }

        public void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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
            if (GetKey >= 5 && !_spotEffect.activeSelf)
            {
                _spotEffect.SetActive(true);
            }
        }

        public void Toggle()
        {
            MainUi.SetActive(!MainUi.activeSelf);
            
            if(MainUi.activeSelf)
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
