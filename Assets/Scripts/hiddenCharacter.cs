using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;



public class hiddenCharacter : MonoBehaviour
{
    public CHARACTER index;

    public Scene_Hidden hidden;

    public Rigidbody2D children;
    public Vector3 myPosition;

    public bool isMyTurn;
    public bool isGoing;
    public bool isBack;


    void Start()
    {
        children = GetComponent<Rigidbody2D>();
        myPosition = transform.position;

        //isMyTurn = false;
        //isGoing = false;
        //isBack = false;
    }

    private void Update()
    {
        if(isGoing)
        {
            Debug.Log(this.index + " Go 진입");

            if (hidden.whoseTurn == 0)
            {
                Go();
            }
            else
            {
                Invoke("Go", 2.0f);
            }    
        }

        if(isBack)
        {
            Debug.Log(this.index + " Back 진입");
            Invoke("Back", 2.0f);
        }

    }

    public void Jump()
    {
        children.AddForce(150.0f * Vector2.up);
    }

    public void Go()
    {
        if (transform.position.x > -6.0f)
        {
            transform.position += Vector3.left * 0.02f;
        }
        else
        {
            isGoing = false;
            Debug.Log(this.index + " Go 나감");
        }
    }

    private void Back()
    {
        if (transform.position.x < myPosition.x)
        {
            transform.position += Vector3.right * 0.02f;
        }
        else
        {
            Debug.Log(this.index + " Back 나감");
            isBack = false;
        }
    }

}
