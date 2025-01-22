using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum CHARACTER
{
    DongYoung = 0,
    HyeJin = 1,
    DongHoon = 2,
    HanNa = 3,
    SeokHo = 4
}

public class hiddenCharacter : MonoBehaviour
{
    public CHARACTER index;

    public Scene_Hidden hidden;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hidden.turnNumber == (int)index)
        {
            //transform.position += Vector3.left * 0.005f;
        }
    }
}
