using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성보장
    static Managers Instance { get { init(); return s_instance; } }
    
    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    static public InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }

    static void init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null) //매니저 오브젝트가 없으면 매니저를 만들고 컴포넌트 추가
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);// 쉽게 삭제되지 않게함.
            s_instance = go.GetComponent<Managers>();
        }
    }
}
