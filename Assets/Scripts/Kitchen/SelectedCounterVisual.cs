using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField]
    private BaseCounter _baseCounter;

    [SerializeField]
    private GameObject[] _selectedEffectObjArray;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == _baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject selectedEffectObj in _selectedEffectObjArray)
        {
            selectedEffectObj.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject selectedEffectObj in _selectedEffectObjArray)
        {
            selectedEffectObj.SetActive(false);
        }
    }
}
