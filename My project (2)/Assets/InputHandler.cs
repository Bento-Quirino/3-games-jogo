using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //TODO: Make InputHandler Singleton Class
    //public static InputHandler
    //handler { get; private set; }

    public bool inInteraction { get; private set; }

    void Update()
    {
        inInteraction =
            OnTouchScreen() || OnMouseClick();
    }

    //Retorna verdadeiro sempre que
    //o número de toques na tela 
    //for maior que zero
    bool OnTouchScreen()
    {
        return Input.touchCount > 0;
    }

    bool OnMouseClick()
    {
        return Input.GetMouseButtonDown(0);
    }
}
