using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Button OffBtn;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notion_OFF()
    {
        Debug.Log("¾Ë¸²²¨Áü");
        Panel.SetActive(false);
    }
}
