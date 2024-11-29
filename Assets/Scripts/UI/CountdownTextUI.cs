using TMPro;
using UnityEngine;

public class CountdownTextUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopup";

    [SerializeField]
    private TextMeshProUGUI _countdownText;

    private Animator _animator;
    private int previousCountdownNumber;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(Mathf.Ceil(GameManager.Instance.GetCountdownToStartTimer()));
        _countdownText.text = countdownNumber.ToString();

        if (countdownNumber != previousCountdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            _animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
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
