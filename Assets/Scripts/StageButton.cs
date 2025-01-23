using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    public GameObject Panel;

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
        Invoke("SelectScene", 2f);
        StageManager.Instance.SelectStage(StageType.Easy);
    }
    public void MakeHardMode()
    {
        ConditionCheck();
        if (StageManager.Instance.clear == true)
        {
            Invoke("SelectScene", 2f);
            StageManager.Instance.SelectStage(StageType.Hard);
        }
    }

    public void ConditionCheck()
    {
        //이지모드를 깼는지에 대한 기록을 갱신함
        if (StageManager.Instance.clear != true)
        {
            StageManager.Instance.clear = StageManager.Instance.Isclear();
        }

        if (StageManager.Instance.clear == false)
        {
            Panel.SetActive(true);
        }
    }
}
