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

        //���� ���� �ε����� ������ �ִٸ�
        if (hiddenScene.turnNumber == (int)index)
        {
            //�����Դϴ�!
            //ĳ���Ͱ� �ڸ��� ���ư�
            //���� ������ �Ѿ

            Debug.Log("�����Դϴ�!");
            hiddenScene.turnNumber++;
        }
        //���� �ٸ� �ε����� ������ �ִٸ�
        else
        {
            //Ʋ�Ƚ��ϴ�
            Debug.Log("Ʋ�Ƚ��ϴ�!!");
        }

    }
}
