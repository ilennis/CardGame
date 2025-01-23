using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�޸�
//0,1 : ���ƴ� (Minicharacter_2)
//2.3 : �ѳ��� (Minicharacter_3)
//4,5 : ��ȣ�� (Minicharacter_4)
//6,7 : ������ (Minicharacter_0)
//8,9 : ������ (Minicharacter_1)

public class HiddenCards : MonoBehaviour
{
    public Scene_Hidden hidden;
    //public hiddenCharacter character;

    public CHARACTER index;
    

    private void Start()
    {
        
    }

    //ī�带 Ŭ������ ��
    public void OnClickCard()
    {
  
        //ĳ���Ϳ� ī�尡 ���� index�� ������ �ִ��� Ȯ��

        //���� ĳ������ turn�� card�� ���� �ε����� ������ �ִٸ�
        if (hidden.whoseTurn == (int)index)
        {
            //�����Դϴ�!
            //Debug.Log("�����Դϴ�!");
            hidden.bubble.CorrectText();
            hidden.bubble.RequestText();


            //ĳ���Ͱ� ����
            hidden.characters[(int)index].Jump();
            //ĳ������ ���� �������� �˷��ֱ�
            //hidden.characters[(int)index].isMyTurn = false;
            //���ư��� �����
            hidden.characters[(int)index].isBack = true;
            
            //���� ���� �ٸ� ����� �����ִٸ�
            if (hidden.whoseTurn < 4) 
            {
                //Ÿ�� ������ �Ѱ��ֱ�
                hidden.whoseTurn++;
                //���� ������� �� ���̶�� �˷��ֱ�
                //hidden.characters[hidden.whoseTurn].isMyTurn = true;
                //���ڸ����� �θ���
                hidden.characters[hidden.whoseTurn].isGoing = true;
            }

            hidden.turnCount++;

        }
        //���� �ٸ� �ε����� ������ �ִٸ�
        else
        {
            //Ʋ�Ƚ��ϴ�
            //Debug.Log("Ʋ�Ƚ��ϴ�!!");
            hidden.bubble.WrongText();
            hidden.bubble.RequestText();
        }

    }
}
