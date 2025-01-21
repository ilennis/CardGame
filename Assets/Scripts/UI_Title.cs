using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    RectTransform title;
    Graphic groupName;

    private void Awake()
    {
        title = transform.GetChild(0).GetComponent<RectTransform>();
        groupName = transform.GetChild(1).GetComponent<Graphic>();
    }

    public void Death()
    {
        title.DOAnchorPosY(0.0f, 0.8f).SetEase(Ease.InBack);
        groupName.DOFade(0.0f, 0.5f);
    }
}