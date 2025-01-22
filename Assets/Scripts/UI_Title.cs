using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    RectTransform title;
    Graphic groupName;

    private Sequence stand;

    private void Awake()
    {
        title = transform.GetChild(0).GetComponent<RectTransform>();
        groupName = transform.GetChild(1).GetComponent<Graphic>();
    }

    private void Start()
    {
        stand = DOTween.Sequence().SetLoops(-1)
            .Append(title.DOPunchRotation(Vector3.one, 0.8f).SetDelay(1.6f));
    }

    private void OnDestroy()
    {
        stand.Kill();
    }

    public void Death()
    {
        title.DOAnchorPosY(0.0f, 0.8f).SetEase(Ease.InBack);
        groupName.DOFade(0.0f, 0.5f);
    }
}