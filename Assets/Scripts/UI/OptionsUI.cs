using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField]
    private Button _soundButton;

    [SerializeField]
    private Button _musicButton;

    [SerializeField]
    private Button _closeButton;

    [SerializeField]
    private TextMeshProUGUI _soundButtonText;

    [SerializeField]
    private TextMeshProUGUI _musicButtonText;

    private void Awake()
    {
        Instance = this;

        _soundButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        _musicButton.onClick.AddListener(() => {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        _closeButton.onClick.AddListener(() => {
            Hide();
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        UpdateVisual();

        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    void UpdateVisual()
    {
        _soundButtonText.text = "…˘–ß£∫" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        _musicButtonText.text = "“Ù¿÷£∫" + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }
}
