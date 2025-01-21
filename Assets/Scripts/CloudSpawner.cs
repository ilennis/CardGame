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
    }

    private void Initialize()
    {
        float x = -10.0f;
        float y = Random.Range(transform.position.y, transform.position.y + Random.Range(0.0f, 4.0f));
        while (x < 10.0f)
        {
            Spawn(new Vector2(x, y));
            x += Random.Range(minDelay, maxDelay);
        }
    }

    private void Spawn(Vector2 position)
    {
        int index = Random.Range(0, clouds.Count);
        Instantiate(clouds[index], position, Quaternion.identity);
    }

    private IEnumerator Spawning()
    {
        Spawn(transform.position);

        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        StartCoroutine(Spawning());
    }
}