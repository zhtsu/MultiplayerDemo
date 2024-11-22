using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject GameObject;
    }

    [SerializeField]
    private PlateKitchenObject _plateKitchenObject;

    [SerializeField]
    private List<KitchenObjectSO_GameObject> _kitchenObjectSOGameObjectList;

    private void Start()
    {
        _plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject iter in _kitchenObjectSOGameObjectList)
        {
            if (iter.KitchenObjectSO == e.AddedKitchenObjectSO)
            {
                iter.GameObject.SetActive(true);
            }
        }
    }
}
