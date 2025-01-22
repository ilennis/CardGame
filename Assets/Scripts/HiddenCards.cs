using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//메모
//0,1 : 동훈님 (Minicharacter_2)
//2.3 : 한나님 (Minicharacter_3)
//4,5 : 석호님 (Minicharacter_4)
//6,7 : 동영님 (Minicharacter_0)
//8,9 : 혜진님 (Minicharacter_1)

public class HiddenCards : MonoBehaviour
{
    public Scene_Hidden hiddenScene;
    //public hiddenCharacter character;

    public CHARACTER index;

    private void Start()
    {

    }

    //카드를 클릭했을 때
    public void OnClickCard()
    {
  
        //캐릭터와 카드가 같은 index를 가지고 있는지 확인

        //만약 같은 인덱스를 가지고 있다면
        if (hiddenScene.turnNumber == (int)index)
        {
            //정답입니다!
            //캐릭터가 자리로 돌아감
            //다음 턴으로 넘어감

            Debug.Log("정답입니다!");
            hiddenScene.turnNumber++;
        }
        //만약 다른 인덱스를 가지고 있다면
        else
        {
            //틀렸습니다
            Debug.Log("틀렸습니다!!");
        }

    }
}
