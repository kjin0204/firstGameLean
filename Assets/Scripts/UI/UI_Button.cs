using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : UI_Base
{
    int _point = 0;

    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        GameObject
    }
    enum Images
    {
        ItemIcon
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));


        GameObject go = GetImage((int)Images.ItemIcon).gameObject;

        AddUIEvent(go, ((PointerEventData point) => { go.gameObject.transform.position = point.position; }), Define.UIEvent.Drag);

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(ButtonClieck);

    }


    public void ButtonClieck(PointerEventData data)
    {
        _point++;
        Get<Text>((int)Texts.ScoreText).text = $"Á¡¼ö : {_point}Á¡";
    }
}
