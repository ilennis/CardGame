using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private List<Card> cardList = new();

    private bool isOpening = false;
    private readonly WaitForSeconds delay = new(0.1f);

    private void Update()
    {
        if (isOpening == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isOpening = true;
                cardList = GameManager.Instance.cards.OrderBy(x => x.index).ToList();
                StartCoroutine(OpenCards());
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            GameManager.Instance.Time += 1.0f;
        }
    }

    private IEnumerator OpenCards()
    {
        yield return delay;

        for (int i = 0; i < 2; i++)
        {
            cardList[i].OpenCard();
            yield return delay;
        }

        isOpening = false;
    }
}