using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private CuttingCounter _cuttingCounter;

    [SerializeField]
    private Image _barImage;

    private void Start()
    {
        _cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
        _barImage.fillAmount = 0f;
        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        _barImage.fillAmount = e.ProgressNormalized;

        if (e.ProgressNormalized == 0f || e.ProgressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
