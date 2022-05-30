using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //��Ʈ����Ʈ �ٿ��ָ� ����Ƽ���� ������ ��밡��
    float _speed = 10.0f;


    Vector3 _destPos;
    void Start()
    {
        Managers.Input.KeyAction += Onkeyboard;
        Managers.Input.MouseAction += OnMouseClicked;
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
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //�ּ� ������ ���� ���� �ּҰ����� , �ִ밪���� ū���� �ִ밪���� ��ȯ
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

    //�������Ӵ� �ѹ��� ����
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

    public void NewEvent(int test)
    {
        Debug.Log($"�ѹ��ѹ� {test}");
    }

    void Onkeyboard()
    {
        //_yAngle += Time.deltaTime * _speed;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //2. �ε巴�� ȸ���� ������ a : ù��° ������, b : ��ǥ ��ġ, 3 : 0~ 1�� ���̸� 0 �� a�� ������ 1�� b�� ������ ȸ���� �ε巴�� ���ִ� ��
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
        //    //3. ���� �������� �̵�
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
        //���콺�� ������� ȭ�鿡 ǥ�� ���ֱ� ����
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
        
        RaycastHit hit;
        // ���̾� ������ ������ ���� ��� 2����------------------------------------------------
        //LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //��Ʈ��  8��, 9�� ������ �̵� ��Ŵ 
        //int mask = (1 << 8) | (1 << 9); //��Ʈ��  8��, 9�� ������ �̵� ��Ŵ 
        //--------------------------------------------------------------------------------------

        //1: ī�޶� ������, 2: ����, 3: �ε��� �ǻ�ü,4: �ִ� �Ÿ�
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall"))) //Ư�� Layer�� ���� �ϰ� ������ mask�� ��Ʈ�� �־� ����
        {
            _destPos = hit.point;

            //hit.collider.gameObject.tag
            //Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            _state = PlayerState.Moving;
        }
    }
}
