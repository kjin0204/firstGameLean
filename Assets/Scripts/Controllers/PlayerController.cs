using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //어트리뷰트 붙여주면 유니티에서 변수로 사용가능
    float _speed = 10.0f;


    Vector3 _destPos;
    void Start()
    {
        Managers.Input.KeyAction += Onkeyboard;
        Managers.Input.MouseAction += OnMouseClicked;

        //Managers.Resource.Instantiate("UI/UI_Button");
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    float _yAngle = 0.0f;

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;

        if (dir.magnitude <= 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //최소 값보다 작은 값은 최소값으로 , 최대값보다 큰값은 최대값으로 반환
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            //transform.LookAt(_destPos);
        }


        Animator any;
        any = GetComponent<Animator>();
        any.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {

        Animator any;
        any = GetComponent<Animator>();
        any.SetFloat("speed", 0);
    }

    //한프레임당 한번씩 실행
    void Update()
    {
        switch(_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }

    void Onkeyboard()
    {
        //_yAngle += Time.deltaTime * _speed;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //2. 부드럽게 회전을 시켜줌 a : 첫번째 포지션, b : 목표 위치, 3 : 0~ 1의 값이며 0 은 a에 가깝게 1은 b에 가깝게 회전을 부드럽게 해주는 값
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
        //    //3. 월드 방향으로 이동
        //    transform.position += Vector3.forward * Time.deltaTime * _speed;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
        //    transform.position += Vector3.left * Time.deltaTime * _speed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
        //    transform.position += Vector3.right * Time.deltaTime * _speed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
        //    transform.position += Vector3.back * Time.deltaTime * _speed;
        //}
        //_moveToDest = false;
    }


    void OnMouseClicked(Define.MouseEvent evt)
    {
        if(_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //마우스를 찍었을때 화면에 표시 해주기 위함
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
        
        RaycastHit hit;
        // 레이어 정보를 가지고 오는 방법 2가지------------------------------------------------
        //LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //비트를  8번, 9번 옆으로 이동 시킴 
        //int mask = (1 << 8) | (1 << 9); //비트를  8번, 9번 옆으로 이동 시킴 
        //--------------------------------------------------------------------------------------

        //1: 카메라 포지션, 2: 방향, 3: 부딪힌 피사체,4: 최대 거리
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall"))) //특정 Layer만 적용 하고 싶을때 mask에 비트를 넣어 적용
        {
            _destPos = hit.point;

            //hit.collider.gameObject.tag
            //Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            _state = PlayerState.Moving;
        }
    }
}
