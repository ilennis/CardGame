using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private List<Card> cardList = new();

    private bool isOpening = false;
    private WaitForSeconds delay = new(0.1f);

    private void Awake() => Initialize();

    private void Initialize()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {
        if (isOpening)
        {
            return;
        }

        cardList = GameManager.Instance.cards.OrderBy(x => x.index).ToList();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpening = true;
            StartCoroutine(OpenCards());
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