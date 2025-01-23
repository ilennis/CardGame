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
            if (GameManager.Instance.cardCount == 0)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(OpenCards());
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(OpenAllCards());
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            GameManager.Instance.Time += 1.0f;
        }
    }

    private IEnumerator OpenCards()
    {
        isOpening = true;

        yield return delay;

        cardList = GameManager.Instance.cards.OrderBy(x => x.index).ToList();
        for (int i = 0; i < 2; i++)
        {
            cardList[i].OpenCard();
            yield return delay;
        }

        isOpening = false;
    }

    private IEnumerator OpenAllCards()
    {
        while (GameManager.Instance.cardCount > 0)
        {
            yield return OpenCards();
        }
    }
}