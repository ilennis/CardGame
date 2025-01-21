using System.Collections;
using UnityEngine;

public class MiniCharacters : MonoBehaviour
{
    [SerializeField]
    private bool playable;

    private Rigidbody2D[] children;
    private readonly WaitForSeconds waitForSecond = new(0.8f);

    private int index = -1;
    private int childCount = 0;

    private void Start()
    {
        childCount = transform.childCount - 1;
        children = new Rigidbody2D[childCount];
        for (int i = 0; i < childCount; i++)
        {
            children[i] = transform.GetChild(i).GetComponent<Rigidbody2D>();
        }

        if (playable)
        {
            StartCoroutine(Jumping());
        }
    }

    public void Jump()
    {
        StopAllCoroutines();

        for (int i = 0; i < children.Length; i++)
        {
            if (i == index)
            {
                continue;
            }

            children[i].AddForce(200.0f * Vector2.up);
        }
    }

    private IEnumerator Jumping()
    {
        int i = index + 1;
        index = i == childCount ? 0 : i;
        children[index].AddForce(150.0f * Vector2.up);

        yield return waitForSecond;

        StartCoroutine(Jumping());
    }
}