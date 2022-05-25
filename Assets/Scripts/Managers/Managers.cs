using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //���ϼ�����
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
            if (go == null) //�Ŵ��� ������Ʈ�� ������ �Ŵ����� ����� ������Ʈ �߰�
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);// ���� �������� �ʰ���.
            s_instance = go.GetComponent<Managers>();
        }
    }
}
