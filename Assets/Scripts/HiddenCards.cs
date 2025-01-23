using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�޸�
//0,1 : ���ƴ� (Minicharacter_2)
//2.3 : �ѳ��� (Minicharacter_3)
//4,5 : ��ȣ�� (Minicharacter_4)
//6,7 : ������ (Minicharacter_0)
//8,9 : ������ (Minicharacter_1)

public class HiddenCards : MonoBehaviour
{
    public Scene_Hidden hiddenScene;
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
        if (hiddenScene.whoseTurn == (int)index)
        {
            //�����Դϴ�!
            Debug.Log("�����Դϴ�!");
            //ĳ���Ͱ� ����
            hiddenScene.characters[(int)index].Jump();
            //ĳ������ ���� �������� �˷��ֱ�
            hiddenScene.characters[(int)index].isMyTurn = false;
            //���ư��� �����
            hiddenScene.characters[(int)index].isBack = true;
            
            //���� ���� �ٸ� ����� �����ִٸ�
            if (hiddenScene.whoseTurn < 4) 
            {
                //Ÿ�� ������ �Ѱ��ֱ�
                hiddenScene.whoseTurn++;
                //���� ������� �� ���̶�� �˷��ֱ�
                hiddenScene.characters[hiddenScene.whoseTurn].isMyTurn = true;
                //���ڸ����� �θ���
                hiddenScene.characters[hiddenScene.whoseTurn].isGoing = true;
            }

        }
        //���� �ٸ� �ε����� ������ �ִٸ�
        else
        {
            //Ʋ�Ƚ��ϴ�
            Debug.Log("Ʋ�Ƚ��ϴ�!!");
        }

    }
}
