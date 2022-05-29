using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _mousePress = false;

    public void OnUpdate()
    {
        if (Input.anyKey != false && KeyAction != null)
            KeyAction.Invoke();

        if (Input.GetMouseButton(0))
        {
            if(MouseAction != null)
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
            }
            _mousePress = true;
        }
        else
        {
            if(_mousePress)
                MouseAction.Invoke(Define.MouseEvent.Click);
            _mousePress = false;   
        }
    }
}
