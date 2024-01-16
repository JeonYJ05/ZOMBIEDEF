using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


    internal class CameraFollower : MonoBehaviour
    {
    [SerializeField] private Transform _target;
    [SerializeField] float offsetX = 0.0f;
    [SerializeField] float offsetY = 10.0f;
    [SerializeField] float offsetZ= 10.0f;
    public float SmoothValue = 5f;
    private Vector3 _offset;
    private float _cameraSpeed = 10f;


    private void Start()
        {
            _offset = transform.position - _target.position;
        }

        private void FixedUpdate()
        {
        Vector3 TargetPos = new Vector3(
            _target.transform.position.x + offsetX,
            _target.transform.position.y + offsetY,
            _target.transform.position.z + offsetZ
            );

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * _cameraSpeed);

        


        //Vector3 targetCameraPosition = _target.position + _offset;
        //
        //transform.position = Vector3.Lerp(
        //        transform.position,
        //        targetCameraPosition,
        //        SmoothValue * Time.deltaTime);
        //
        //Vector3 directiontoTarget = _target.forward;
        //directiontoTarget.y = 0f;   
        //transform.rotation = Quaternion.LookRotation(directiontoTarget);

        }
    }



