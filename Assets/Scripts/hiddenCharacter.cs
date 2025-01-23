using UnityEngine;



public class HiddenCharacter : MonoBehaviour
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
        isMyTurn = false;

        children = GetComponent<Rigidbody2D>();
        myPosition = transform.position;

    }

    private void Update()
    {
        if (isGoing)
        {
            //Debug.Log(this.index + " Go 진입");


            if (hidden.whoseTurn == 0)
            {
                Go();
            }
            else
            {
                Invoke("Go", hidden.speed);
            }
        }

        if (isBack)
        {
            //Debug.Log(this.index + " Back 진입");
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
            transform.position += Vector3.left * 0.05f;
        }
        else
        {
            BubbleOn();
            isGoing = false;
            //Debug.Log(this.index + " Go 나감");
        }
    }

    private void Back()
    {
        if (transform.position.x < myPosition.x)
        {
            BubbleOff();
            transform.position += Vector3.right * 0.05f;
        }
        else
        {

            if (hidden.turnCount == 5)
            {
                Invoke("JumpAll", 2.5f);
                hidden.turnCount++;
            }

            if (hidden.turnCount >= 6)
            {
                Invoke("Ending", 3.5f);
            }

            //Debug.Log(this.index + " Back 나감");
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

    private void JumpAll()
    {
        transform.parent.GetComponent<MiniCharacters>().Jump();
    }

    private void Ending()
    {
        hidden.stageButton.gameObject.SetActive(true);
        hidden.titleButton.gameObject.SetActive(true);
        hidden.titleText.text = "사진을 찾아줘서 고마워요!";
    }

}
