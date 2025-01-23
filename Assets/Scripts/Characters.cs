using UnityEngine;

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
        if (isLeft)
        {

            if (transform.position.x > -8.0f)
            {
                transform.position += Vector3.left * direction;
            }

        }
        if (isRight)
        {
            ;
            if (transform.position.x < 7.6f)
            {
                transform.position += Vector3.right * direction;
            }
        }



    }
    public void OnClick()
    {
        if (!isLeft && !isRight)
        {
            isLeft = true;
            isRight = false;
        }
    }

    public void ReverseClick()
    {
        if (StageManager.Instance.Isclear() == false)
        {
            return;
        }

        if (!isLeft && !isRight)
        {
            isRight = true;
            isLeft = false;
        }
    }
}