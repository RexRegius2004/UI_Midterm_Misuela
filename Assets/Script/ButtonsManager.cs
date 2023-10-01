using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false, isFadeOut = true, isFlipOut = false, isFlyOut = true;
    private Vector3 originalPosition = new Vector3(0, 250, 0);
    
    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        float fadeValue = 1f;
        float targetFade = isFadeOut ? 0f : fadeValue;
        imageToScale.DOFade(targetFade, 0.25f);
        isFadeOut = !isFadeOut;
    }

    public void Shake()
    {

        imageToScale.transform.DOShakePosition(0.50f, new Vector3(15, 0, 0), 10, 90.0f, false, false, ShakeRandomnessMode.Harmonic);
        imageToScale.transform.DOLocalMove(originalPosition, 0.2f);
    }

    public void Fly()
    {
        float MoveValue = 0;
        float targetMove = isFlyOut ? 50 : MoveValue;
        Sequence mySequence = DOTween.Sequence();
        imageToScale.transform.DOMoveX(targetMove, 0.25f);
        isFlyOut = !isFlyOut;
    }
    public void Flip()
    {
        if (isFlipOut == false) {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(imageToScale.transform.DOScale(new Vector3(-1f, 1f, 1f), 1f));
            mySequence.Join(imageToScale.DOFade(0f, 0.25f)); 
            isFlipOut = true;
        }
        else
        {
            imageToScale.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
            transform.localScale = originalPosition;
            imageToScale.DOFade(1f, 0.25f);
            isFlipOut = false;
        }
    }
    public void Flash()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(imageToScale.DOFade(0f, 0.25f));
        mySequence.Append(imageToScale.DOFade(1f, 0.25f));
        mySequence.Append(imageToScale.DOFade(0f, 0.25f));
        mySequence.Append(imageToScale.DOFade(1f, 0.25f));
    }

}
