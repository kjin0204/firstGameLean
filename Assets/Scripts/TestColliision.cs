using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliision : MonoBehaviour
{

    // 1) 나혹은 상대 한테 RigidBody 잇어야 한다 (IsKinematic : off)
    // 2) 나한테 collider가 잇어야 한다 (IsTrigger : off)
    // 3) 상대한테 collider가 잇어야 한다 (IsTrigger : off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision! @@{collision.gameObject.name}");
    }

    //1) 둘다 collider가 있어야 한다
    //2) 둘중 하나는 IsTrigger : on
    //3) 둘 중 하나는 RigidBody가 잇어야한다.
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
        //Vector3 look = transform.TransformDirection(Vector3.forward); //플레이어가 바로보는 로컬 좌표를 월드 좌표로 바꿔줌
        //Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        //foreach (RaycastHit data in hits)
        //{
        //    Debug.Log($"Raycast {data.collider.gameObject.name}");
        //}
        //====================================================================================================


        //마우스 포지션 얻어오는 방법 =========================================================================
        //Debug.Log(Input.mousePosition); //Screnn 픽셀 단위로 마우스 포지션 출력
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); //비율로 마우스 포지션 출력 viewport
        //====================================================================================================



        // 카메라에서 레이케스팅 ===================================================================================
        //Camera.main.nearClipPlane 카메라에서 작은 투사체 까지의 거리


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //마우스를 찍었을때 화면에 표시 해주기 위함
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            // 레이어 정보를 가지고 오는 방법 2가지------------------------------------------------
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); //비트를  8번, 9번 옆으로 이동 시킴 
            //int mask = (1 << 8) | (1 << 9); //비트를  8번, 9번 옆으로 이동 시킴 
            //--------------------------------------------------------------------------------------


            //1: 카메라 포지션, 2: 방향, 3: 부딪힌 피사체,4: 최대 거리
            if (Physics.Raycast(ray, out hit, 100.0f, mask)) //특정 Layer만 적용 하고 싶을때 mask에 비트를 넣어 적용
            {
                //hit.collider.gameObject.tag
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));//월드 포지션으로 바꿔줌
        //    Vector3 dir = mousePos - Camera.main.transform.position; //방향 벡터 구하기
        //    dir = dir.normalized; //거리값이 1인 방향 벡터

        //    //마우스를 찍었을때 화면에 표시 해주기 위함
        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;
        //    //1: 카메라 포지션, 2: 방향, 3: 부딪힌 피사체,4: 최대 거리
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //    }
        //}
       
        //====================================================================================================

        //Camera.main.ScreenToWorldPoint
    }
}
