using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //��Ʈ����Ʈ �ٿ��ָ� ����Ƽ���� ������ ��밡��
    float _speed = 10.0f;
    void Start()
    {
        Managers.Input.KeyAction += Onkeyboard;
    }

    float _yAngle = 0.0f;
    //�������Ӵ� �ѹ��� ����
    void Update()
    {
    }

    void Onkeyboard()
    {
        //transform.position ���� ��ǥ
        //Time.deltaTime;  �����ð������� ���� ����� �ð�
        //transform.position.magnitude ũ�⸦ ��ȯ(��Ÿ��� ���Ƿ� ����)
        //transform.position.normalized ����Ű�� ������ ������ ũ�Ⱑ 1�� ���� ��ȯ

        //TransformDirection ���ÿ��� ���� ��ǥ�� ��ȯ
        //InverseTransformDirection ���忡�� ���÷� ��ȯ
        // Translate �ٶ󺸰��ִ� �������� ��ǥ�� �ٲ���
        _yAngle += Time.deltaTime * _speed;

        //���� ȸ�����Է�
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // += delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));
        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

        if (Input.GetKey(KeyCode.W))
        {
            //1. �ش� �������� �ٶ󺸰� ȸ�� ��Ŵ ���� ����
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            //2. �ε巴�� ȸ���� ������ a : ù��° ������, b : ��ǥ ��ġ, 3 : 0~ 1�� ���̸� 0 �� a�� ������ 1�� b�� ������ ȸ���� �ε巴�� ���ִ� ��
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            //3. ���� �������� �̵�
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
