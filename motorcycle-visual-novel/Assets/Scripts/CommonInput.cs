using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonInput : MonoBehaviour
{
    public bool Pause()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public bool ForwardText()
    {
        bool pc = Input.GetKeyDown(KeyCode.Return)
                    || Input.GetMouseButtonDown(0)
                    || Input.GetKeyDown(KeyCode.Space);
        bool mobile = Input.touchCount > 0;
        
        return pc || mobile;
    }

    public bool Left()
    {
        //A, left Arrow, Girar celular
        bool pc = Input.GetKey(KeyCode.A)
                   || Input.GetKey(KeyCode.LeftArrow);

        bool mobile = Input.acceleration.z < -0.5f;
        return pc || mobile;
    }

    public bool Right()
    {
        //D, right Arrow, Girar celular
        bool pc = Input.GetKey(KeyCode.D)
                   || Input.GetKey(KeyCode.RightArrow);

        bool mobile = Input.acceleration.z > 0.5f;
        return pc || mobile;
    }

    public bool Acceleration()
    {
        bool pc = Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.UpArrow);

        bool mobile = false;
        //garante que exista um toque
        if (Input.touchCount > 0)
        {
            //Pega as informações do primeiro toque
            Touch t = Input.GetTouch(0);
            float side = Screen.width / 2;
            //direita
            mobile = t.position.x > side;
        }
        return pc || mobile;
    }

    public bool Braking()
    {
        bool pc = Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.LeftShift);

        bool mobile = false;
        //garante que exista um toque
        if (Input.touchCount > 0)
        {
            //Pega as informações do primeiro toque
            Touch t = Input.GetTouch(0);
            float side = Screen.width / 2;
            //esquerda
            mobile = t.position.x < side;
        }
        return pc || mobile;
    }
}
