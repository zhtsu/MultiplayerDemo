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
    private Button _moveUpButton;

    [SerializeField]
    private Button _moveDownButton;

    [SerializeField]
    private Button _moveLeftButton;

    [SerializeField]
    private Button _moveRightButton;

    [SerializeField]
    private Button _interactButton;

    [SerializeField]
    private Button _interactAlternateButton;

    [SerializeField]
    private UnityEngine.UI.Button _pauseButton;

    [SerializeField]
    private TextMeshProUGUI _moveUpText;

    [SerializeField]
    private TextMeshProUGUI _moveDownText;

    [SerializeField]
    private TextMeshProUGUI _moveLeftText;

    [SerializeField]
    private TextMeshProUGUI _moveRightText;

    [SerializeField]
    private TextMeshProUGUI _interactText;

    [SerializeField]
    private TextMeshProUGUI _interactAlternateText;

    [SerializeField]
    private TextMeshProUGUI _pauseText;

    [SerializeField]
    private TextMeshProUGUI _soundButtonText;

    [SerializeField]
    private TextMeshProUGUI _musicButtonText;

    [SerializeField]
    private GameObject _pressToRebingKeyUI;

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

        _moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Up); });
        _moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down); });
        _moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        _moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        _interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact); });
        _interactAlternateButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.InteractAlternate); });
        _pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        UpdateVisual();

        Hide();
        HidePressToRebingKey();
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
        _soundButtonText.text = "ÉùÐ§£º" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        _musicButtonText.text = "ÒôÀÖ£º" + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        _moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        _moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        _moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        _moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        _interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        _interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        _pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    private void ShowPressToRebingKey()
    {
        _pressToRebingKeyUI.SetActive(true);
    }

    private void HidePressToRebingKey()
    {
        _pressToRebingKeyUI.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebingKey();
        GameInput.Instance.RebindBinding(binding, () => {
            HidePressToRebingKey();
            UpdateVisual();
        });
    }
}
