using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField]
    private PlateKitchenObject _plateKitchenObject;

    [SerializeField]
    private GameObject _iconPrefab;

    private void Start()
    {
        _plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in _plateKitchenObject.GetKitcehnObjectSOList())
        {
            GameObject iconObject = Instantiate(_iconPrefab, transform);
            iconObject.SetActive(true);
            iconObject.GetComponent<PlateIconsSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
