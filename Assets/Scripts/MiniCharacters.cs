using UnityEngine;

public class MiniCharacters : MonoBehaviour
{
    [SerializeField]
    private bool playable;

    private Transform[] children;

    private void Start()
    {
        children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i);
        }
    }
}