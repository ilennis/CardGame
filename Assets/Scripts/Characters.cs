using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Characters : MonoBehaviour
{
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

            
            if (transform.position.x > -8.0f)
            {
                transform.position = Vector3.left * direction;
            }
        }
        if(isRight)
        {
            
            if (transform.position.x < 7.6f)
            {
                transform.position = Vector3.right * direction;
                
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



