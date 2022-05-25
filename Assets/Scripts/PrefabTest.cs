using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject prefab;
    GameObject tank;

    void Start()
    {
        tank = Managers.Resource.Instantiate("Tank");
        //prefab = Resources.Load<GameObject>("Prefabs/Tank");
        //tank = Instantiate(prefab); //按眉 积己
        Managers.Resource.Destroy(tank);
        //Destroy(tank, 3.0f); // 3檬 饶俊 按眉昏力 
    }

}
