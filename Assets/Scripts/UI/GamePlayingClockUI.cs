using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField]
    private Image Fill;

    private void Update()
    {
        Fill.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalized();
    }
}
