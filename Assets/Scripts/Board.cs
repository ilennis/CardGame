using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();
        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i / 4) * 2.6f -7.5f; // ���� ������ ���߾ ���� + ��ġ ����ֱ� x ��  (����, ī�� ������ + 0.1, ī�� ��ġ)
            float y = (i % 4) * 1.9f -3.0f; // ���� ������ ���߾ ���� + ��ġ ����ֱ� y �� (����, ī�� ������ + 0.1, ī�� ��ġ)

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
