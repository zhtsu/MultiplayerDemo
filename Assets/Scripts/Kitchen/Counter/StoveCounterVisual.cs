using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField]
    private StoveCounter _stoveCounter;

    [SerializeField]
    private GameObject _stoveOnEffectObj;

    [SerializeField]
    private GameObject _particlesEffectObj;

    private void Start()
    {
        _stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = (e.NewState == StoveCounter.State.Frying || e.NewState == StoveCounter.State.Fried);
        _stoveOnEffectObj.SetActive(showVisual);
        _particlesEffectObj.SetActive(showVisual);
    }
}
