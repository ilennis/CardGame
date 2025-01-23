using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//메모
//0,1 : 동훈님 (Minicharacter_2)
//2.3 : 한나님 (Minicharacter_3)
//4,5 : 석호님 (Minicharacter_4)
//6,7 : 동영님 (Minicharacter_0)
//8,9 : 혜진님 (Minicharacter_1)

public class HiddenCards : MonoBehaviour
{
    public Scene_Hidden hidden;
    //public hiddenCharacter character;

    public CHARACTER index;
    

    private void Start()
    {
        
    }

    //카드를 클릭했을 때
    public void OnClickCard()
    {
  
        //캐릭터와 카드가 같은 index를 가지고 있는지 확인

        //만약 캐릭터의 turn과 card가 같은 인덱스를 가지고 있다면
        if (hidden.whoseTurn == (int)index)
        {
            //정답입니다!
            //Debug.Log("정답입니다!");
            hidden.bubble.CorrectText();
            hidden.bubble.RequestText();


            //캐릭터가 점프
            hidden.characters[(int)index].Jump();
            //캐릭터의 턴이 끝났음을 알려주기
            //hidden.characters[(int)index].isMyTurn = false;
            //돌아가게 만들기
            hidden.characters[(int)index].isBack = true;
            
            //만약 아직 다른 사람이 남아있다면
            if (hidden.whoseTurn < 4) 
            {
                //타음 턴으로 넘겨주기
                hidden.whoseTurn++;
                //다음 사람에게 네 턴이라고 알려주기
                //hidden.characters[hidden.whoseTurn].isMyTurn = true;
                //앞자리까지 부르기
                hidden.characters[hidden.whoseTurn].isGoing = true;
            }

            hidden.turnCount++;

        }
        //만약 다른 인덱스를 가지고 있다면
        else
        {
            //틀렸습니다
            //Debug.Log("틀렸습니다!!");
            hidden.bubble.WrongText();
            hidden.bubble.RequestText();
        }

    }
}
