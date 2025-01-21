using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;
    public GameObject back;
    public Animator anim;
    SpriteRenderer front;
    public int arr_index = 0;

    public bool cardStatus = true;

    public void Awake()
    {
        front = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();

    }
    public void Setting(int num, int i)
    {
        arr_index = num;
        index = i;
        front.sprite = Resources.Load<Sprite>($"photo{index}");
    }
    public void OpenCard()
    {

        if (!cardStatus) return;
        
        anim.SetBool("isOpen", true);
        back.SetActive(false);
        if(GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }
    
    public void CloseCard()
    {

        StartCoroutine(DelayClose(0.5f));
    }
    
    public void DestroyCard()
    {
        // ���� �߰��� ���� ���� ���ּ���
        StartCoroutine(DelayDestroy(0.5f));
      
    }
    
    IEnumerator DelayDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    IEnumerator DelayClose(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("isOpen", false);
        back.SetActive(true);
        GameManager.Instance.firstCard = null;
        GameManager.Instance.secondCard = null;
    }
}
