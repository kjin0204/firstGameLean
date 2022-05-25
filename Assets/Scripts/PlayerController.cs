using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //어트리뷰트 붙여주면 유니티에서 변수로 사용가능
    float _speed = 10.0f;
    void Start()
    {
        Managers.Input.KeyAction += Onkeyboard;
    }

    float _yAngle = 0.0f;
    //한프레임당 한번씩 실행
    void Update()
    {
    }

    void Onkeyboard()
    {
        //transform.position 월드 좌표
        //Time.deltaTime;  지난시간프레임 이후 경과된 시간
        //transform.position.magnitude 크기를 반환(피타고라스 정의로 구현)
        //transform.position.normalized 가리키는 방향은 같지만 크기가 1인 벡터 반환

        //TransformDirection 로컬에서 월드 좌표로 변환
        //InverseTransformDirection 월드에서 로컬로 변환
        // Translate 바라보고있는 방향으로 좌표를 바꿔줌
        _yAngle += Time.deltaTime * _speed;

        //절대 회전값입력
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // += delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));
        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

        if (Input.GetKey(KeyCode.W))
        {
            //1. 해당 방향으로 바라보게 회전 시킴 월드 기준
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            //2. 부드럽게 회전을 시켜줌 a : 첫번째 포지션, b : 목표 위치, 3 : 0~ 1의 값이며 0 은 a에 가깝게 1은 b에 가깝게 회전을 부드럽게 해주는 값
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            //3. 월드 방향으로 이동
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
    }
}
