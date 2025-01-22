using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening.Core.Easing;

public class Board : MonoBehaviour
{
    public int cardCount = 20; // ���� ī�� ����. Easy = 12, Hard = 20
    public GameObject card;
    public GameObject start;
    public float speed;

     
    public Transform cards;
    public GameManager gameManager;
    public int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

    // Start is called before the first frame update
    void Start()
    {
        GenerateArray();
        StartCoroutine(MakeCards());
        
    }
    void GenerateArray() // ���� ����� ���
    {
        arr = new int[cardCount]; // ���� �� ������
        int pairing = cardCount / 2; // ���Ŀ� �� ���� Ƚ��

        HashSet<int> usedNumbers = new HashSet<int>(); // ���� ���ڰ� �ִ��� Ȯ�� ��
        for (int i = 0; i < pairing; i++)
        {
            int value; // ���Ŀ� �� ���� 

            // Unique Value �����

            do
            {
                value = Random.Range(0, 10);
            } while (usedNumbers.Contains(value));

            usedNumbers.Add(value);

            arr[i * 2] = value;
            arr[i * 2 + 1] = value;
        }
        ShuffleArray();
    }

    void ShuffleArray() // Array ���̴°� �����ؼ� �ٽ� ��������ϴ�.
    {
        for (int i = arr.Length - 1; i > 0; i--) // �ݴ� ī����
        {
            int shuffled = Random.Range(0, i + 1); // �� ���� ���� �پ��. 
            int temp = arr[i];
            arr[i] = arr[shuffled]; // TEMP���ٰ� ���� �� ����. ���� �ε��� ����. �ٽ� ���� �� ����. ���� ū ������
            arr[shuffled] = temp;
        }
    }

    private IEnumerator MakeCards() // ���Ŀ� ���� ī�� ����� ���
    {

        for (int i = 0; i < cardCount; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ȭ�� ���� transform.position���� (-9, 0) ī�� ����
            gameManager.cards.Add(go.GetComponent<Card>());

            float x = (i / 4) * 2.6f - 7.5f; // ���� ������ ���߾ ���� + ��ġ ����ֱ� x ��  (����, ī�� ������ + 0.1, ī�� ��ġ)
            float y = (i % 4) * 1.9f - 3.0f; // ���� ������ ���߾ ���� + ��ġ ����ֱ� y �� (����, ī�� ������ + 0.1, ī�� ��ġ)
            Vector2 targetPosition = new Vector2(x, y); // �� ���������� �̵��ϰ� �����
            go.GetComponent<Card>().Setting(i, arr[i]);

            GameManager.Instance.cardCount = arr.Length;
            go.transform.position = targetPosition;

            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }


}
