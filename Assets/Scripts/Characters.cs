using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Characters : MonoBehaviour
{
    public StageButton EasyButton;
    public StageButton HardButton;
    bool isLeft = false;
    bool isRight = false;
    float direction = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isLeft)
        {

            transform.position = Vector3.left * direction;
            if (transform.position.x == -8.0f)
            {
                StageManager.Instance.SelectStage(StageType.Easy);
            }
        }
        if(isRight)
        {
            transform.position = Vector3.right * direction;
            if (transform.position.x == 7.6f)
            {
                StageManager.Instance.SelectStage(StageType.Hard);
                
            }
        }  
    }
    public void OnClick()
    {
        isLeft = true;
        isRight = false;
    }

    public void reverseClick()
    {
        isRight = true;
        isLeft = false;
    }

}



