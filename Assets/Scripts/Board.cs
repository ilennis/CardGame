using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening.Core.Easing;

public class Board : MonoBehaviour
{
    public int cardCount = 20; // 생성 카드 개수. Easy = 12, Hard = 20
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
    void GenerateArray() // 정렬 만드는 기능
    {
        arr = new int[cardCount]; // 정렬 몇 행인지
        int pairing = cardCount / 2; // 정렬에 들어갈 숫자 횟수

        HashSet<int> usedNumbers = new HashSet<int>(); // 같은 숫자가 있는지 확인 용
        for (int i = 0; i < pairing; i++)
        {
            int value; // 정렬에 들어갈 내용 

            // Unique Value 만들기

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

    void ShuffleArray() // Array 섞이는거 복잡해서 다시 만들었습니다.
    {
        for (int i = arr.Length - 1; i > 0; i--) // 반대 카운팅
        {
            int shuffled = Random.Range(0, i + 1); // 할 수록 점점 줄어듬. 
            int temp = arr[i];
            arr[i] = arr[shuffled]; // TEMP에다가 정렬 값 저장. 정렬 인덱스 수정. 다시 정렬 값 수정. 가장 큰 값부터
            arr[shuffled] = temp;
        }
    }

    private IEnumerator MakeCards() // 정렬에 따라 카드 만드는 기능
    {

        for (int i = 0; i < cardCount; i++)
        {
            GameObject go = Instantiate(card, this.transform); // 화면 왼쪽 transform.position에서 (-9, 0) 카드 생성
            gameManager.cards.Add(go.GetComponent<Card>());

            float x = (i / 4) * 2.6f - 7.5f; // 사진 사이즈 맞추어서 간격 + 위치 잡아주기 x 축  (로직, 카드 사이즈 + 0.1, 카드 위치)
            float y = (i % 4) * 1.9f - 3.0f; // 사진 사이즈 맞추어서 간격 + 위치 잡아주기 y 축 (로직, 카드 사이즈 + 0.1, 카드 위치)
            Vector2 targetPosition = new Vector2(x, y); // 이 포지션으로 이동하게 만들기
            go.GetComponent<Card>().Setting(i, arr[i]);

            GameManager.Instance.cardCount = arr.Length;
            go.transform.position = targetPosition;

            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }


}
