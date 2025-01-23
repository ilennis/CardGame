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

    public bool isMyTurn = false;
    public bool isGoing = false;
    public bool isBack = false;

    //private bool isBubbleOn = false;


    void Start()
    {
        children = GetComponent<Rigidbody2D>();
        myPosition = transform.position;
        hidden.speed = 1.0f;
        //isMyTurn = false;
        //isGoing = false;
        //isBack = false;
    }

    private void Update()
    {
        if(isGoing)
        {
            //Debug.Log(this.index + " Go ����");
            

            if (hidden.whoseTurn == 0)
            {
                Go();
            }
            else
            {
                Invoke("Go", hidden.speed);
            }    
        }

        if(isBack)
        {
            //Debug.Log(this.index + " Back ����");
            Invoke("Back", hidden.speed);
            //Invoke("BubbleOff", speed);
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
            BubbleOn();
            isGoing = false;
            //Debug.Log(this.index + " Go ����");
        }
    }

    private void Back()
    {
        if (transform.position.x < myPosition.x)
        {
            BubbleOff();
            transform.position += Vector3.right * 0.02f;
        }
        else
        {
            //Debug.Log(this.index + " Back ����");
            isBack = false;
        }
    }

    private void BubbleOff()
    {
        hidden.bubble.gameObject.SetActive(false);
    }
    private void BubbleOn()
    {
        hidden.bubble.gameObject.SetActive(true);
    }

}
