using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < objects.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, name = names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, name = names[i], true);
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        return _objects[typeof(T)][index] as T;
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Eventhandler evt = Util.GetComponent<UI_Eventhandler>(go); /*go.GetComponent("UI_Eventhandler") as UI_Eventhandler;*/
        switch(type)
        {
            case Define.UIEvent.Click:
                evt.OnPointerHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler += action;
                break;
        }

    }

    protected Text GetText(int index) { return Get<Text>(index); }
    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }
}
