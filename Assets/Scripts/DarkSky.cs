using DG.Tweening;
using UnityEngine;

public class DarkSky : MonoBehaviour
{
    private void Start()
    {
        transform.DOScaleY(1.0f, 1.0f).From(0.0f);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}