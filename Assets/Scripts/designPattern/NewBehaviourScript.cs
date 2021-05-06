using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool team;

    private void Start()
    {
        if (team)
        {

        Class1 class1 = new Class1();
        class1.game();
        }
        else 
        {
            Class2 class2 = new Class2();
            class2.game();
        }
    }
}
