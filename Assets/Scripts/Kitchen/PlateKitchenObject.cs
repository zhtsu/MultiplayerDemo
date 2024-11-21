using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField]
    private List<KitchenObjectSO> _validKitchenObjectSOList;

    [SerializeField]
    private List<KitchenObjectSO> _kitchenObjectSOList;

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (_validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }

        if (!_kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            _kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }

        return false;
    }
}
