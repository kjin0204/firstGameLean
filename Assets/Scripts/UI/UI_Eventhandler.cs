using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Eventhandler : MonoBehaviour , IPointerClickHandler, IDragHandler
{
    public Action<PointerEventData> OnPointerHandler = null;
    public Action<PointerEventData> OnDragHandler = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointerHandler != null)
            OnPointerHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

}
