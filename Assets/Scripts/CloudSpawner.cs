using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private float minDelay;

    [SerializeField]
    private float maxDelay;

    [SerializeField]
    private List<GameObject> clouds = new();

    private void Start()
    {
        Initialize();
        StartCoroutine(Spawning());

        DontDestroyOnLoad(gameObject);
    }

    private void Initialize()
    {
        float x = -10.0f;
        while (x < 10.0f)
        {
            Spawn(new Vector2(x, transform.position.y));

            float speed = Random.Range(1.0f, 2.0f);
            x += Random.Range(minDelay * speed, maxDelay * speed);
        }
    }

    private void Spawn(Vector2 position)
    {
        int index = Random.Range(0, clouds.Count);
        Instantiate(clouds[index], position, Quaternion.identity, transform);
    }

    private IEnumerator Spawning()
    {
        Spawn(transform.position);

        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        StartCoroutine(Spawning());
    }
}