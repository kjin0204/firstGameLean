using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliision : MonoBehaviour
{

    // 1) ��Ȥ�� ��� ���� RigidBody �վ�� �Ѵ� (IsKinematic : off)
    // 2) ������ collider�� �վ�� �Ѵ� (IsTrigger : off)
    // 3) ������� collider�� �վ�� �Ѵ� (IsTrigger : off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision! @@{collision.gameObject.name}");
    }

    //1) �Ѵ� collider�� �־�� �Ѵ�
    //2) ���� �ϳ��� IsTrigger : on
    //3) �� �� �ϳ��� RigidBody�� �վ���Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger! @@{other.gameObject.name}");
    }

    void Start()
    {

    }

    void Update()
    {
        //RayCasting=====================================================================================
        //Vector3 look = transform.TransformDirection(Vector3.forward); //�÷��̾ �ٷκ��� ���� ��ǥ�� ���� ��ǥ�� �ٲ���
        //Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        //foreach (RaycastHit data in hits)
        //{
        //    Debug.Log($"Raycast {data.collider.gameObject.name}");
        //}
        //====================================================================================================


        //���콺 ������ ������ ��� =========================================================================
        //Debug.Log(Input.mousePosition); //Screnn �ȼ� ������ ���콺 ������ ���
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); //������ ���콺 ������ ��� viewport
        //====================================================================================================



        // ī�޶󿡼� �����ɽ��� ===================================================================================
        //Camera.main.nearClipPlane ī�޶󿡼� ���� ����ü ������ �Ÿ�


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //���콺�� ������� ȭ�鿡 ǥ�� ���ֱ� ����
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            // ���̾� ������ ������ ���� ��� 2����------------------------------------------------
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //��Ʈ��  8��, 9�� ������ �̵� ��Ŵ 
            //int mask = (1 << 8) | (1 << 9); //��Ʈ��  8��, 9�� ������ �̵� ��Ŵ 
            //--------------------------------------------------------------------------------------


            //1: ī�޶� ������, 2: ����, 3: �ε��� �ǻ�ü,4: �ִ� �Ÿ�
            if (Physics.Raycast(ray, out hit, 100.0f, mask)) //Ư�� Layer�� ���� �ϰ� ������ mask�� ��Ʈ�� �־� ����
            {
                //hit.collider.gameObject.tag
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));//���� ���������� �ٲ���
        //    Vector3 dir = mousePos - Camera.main.transform.position; //���� ���� ���ϱ�
        //    dir = dir.normalized; //�Ÿ����� 1�� ���� ����

        //    //���콺�� ������� ȭ�鿡 ǥ�� ���ֱ� ����
        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;
        //    //1: ī�޶� ������, 2: ����, 3: �ε��� �ǻ�ü,4: �ִ� �Ÿ�
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //    }
        //}
       
        //====================================================================================================

        //Camera.main.ScreenToWorldPoint
    }
}
