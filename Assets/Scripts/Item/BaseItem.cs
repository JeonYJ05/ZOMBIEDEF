using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.AI.Navigation.Samples;
using UnityEditor;
using UnityEngine;

namespace YJ.Zombie.Items
{

    public enum ItemType
    {
        Money =0,
        Potion,
        Key,
        Weapon
    }
    public abstract class BaseItem : MonoBehaviour
    {
        private float _speed = 150f;
        private Vector3 _axis = Vector3.up;

       public abstract ItemType ItemType { get; }

        protected virtual void Awake()
        {
            float yAxis = UnityEngine.Random.Range(-1f, 1f);
            float zAxis = UnityEngine.Random.Range(-1f, 1f);
            if(yAxis == 0f)
            {
                yAxis = 1f;
            }
            if(zAxis == 0f)
            {
                zAxis = 1f;
            }
            yAxis = (float)Math.Round(yAxis, 2);
            zAxis = (float)Math.Round(zAxis, 2);
            _axis = new Vector3(0, yAxis, zAxis);
        }
        private void Update()
        {
            float spin = _speed * Time.deltaTime;
            Vector3 axis = _axis * spin;
            transform.Rotate(axis);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                Debug.Log("안사라짐");
                return;
            }
            OnEffect(other.gameObject);
            Destroy(gameObject);
                // 파티클 추가
            
        }
        protected abstract void OnEffect(GameObject cha);
    }
}
