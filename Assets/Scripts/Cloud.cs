using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    private float speed;

    private void Start()
    {
        float x = transform.localPosition.x;
        float y = Random.Range(0.0f, 4.0f);
        transform.localPosition = new Vector2(x, y);

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}