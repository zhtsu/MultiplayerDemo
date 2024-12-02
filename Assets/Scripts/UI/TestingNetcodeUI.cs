using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField]
    private Button _hostButton;

    [SerializeField]
    private Button _clientButton;

    private void Awake()
    {
        _hostButton.onClick.AddListener(() => {
            Debug.Log("Host");
            NetworkManager.Singleton.StartHost();
            Hide();
        });

        _clientButton.onClick.AddListener(() => {
            Debug.Log("Client");
            NetworkManager.Singleton.StartClient();
            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
