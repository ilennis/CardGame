using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int index = 0;

    SpriteRenderer front;
    public void Awake()
    {
        front = GetComponent<SpriteRenderer> ();
    }
    public void Setting(int i)
    {
        index = i;
        front.sprite = Resources.Load<Sprite>($"photo{index}");
    }
}
