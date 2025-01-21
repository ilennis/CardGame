using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int index = 0;
    public GameObject back;
    public Animator anim;
    SpriteRenderer front;
    public void Awake()
    {
        front = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();

    }
    public void Setting(int i)
    {
        index = i;
        front.sprite = Resources.Load<Sprite>($"photo{index}");
    }
    public void OpenCard()
    {
        
        anim.SetBool("isOpen", true);
        back.SetActive(false);
    }
}
