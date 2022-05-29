using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;


    void Start()
    {
        
    }

    void LateUpdate() // LakeUpdate 
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform); //카메라가 해당 오브젝트를 주시하게 함.
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
