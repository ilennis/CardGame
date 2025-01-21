using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    private void Start()
    {
        float x = transform.position.x;
        float y = Random.Range(0.0f, 4.0f);
        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        var speed = Random.Range(minSpeed, maxSpeed);
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}