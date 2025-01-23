using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeEasyMode()
    {
        StageManager.Instance.SelectStage(StageType.Easy);
    }
    public void MakeHardMode()
    {
        StageManager.Instance.SelectStage(StageType.Hard);
    }
      
}

