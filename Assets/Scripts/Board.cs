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

            float x = (i / 4) * 2.6f -7.5f; // 사진 사이즈 맞추어서 간격 + 위치 잡아주기 x 축  (로직, 카드 사이즈 + 0.1, 카드 위치)
            float y = (i % 4) * 1.9f -3.0f; // 사진 사이즈 맞추어서 간격 + 위치 잡아주기 y 축 (로직, 카드 사이즈 + 0.1, 카드 위치)

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
