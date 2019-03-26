using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnclick : MonoBehaviour
{
    public bool[] buttonOnClick = new bool[5]{false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Button0()
    {
        buttonOnClick[0] = true;
    }
    void Button1()
    {
        buttonOnClick[1] = true;
    }
    void Button2()
    {
        buttonOnClick[2] = true;
    }
    void Button3()
    {
        buttonOnClick[3] = true;
    }
    void Button4()
    {
        buttonOnClick[4] = true;
    }


}
