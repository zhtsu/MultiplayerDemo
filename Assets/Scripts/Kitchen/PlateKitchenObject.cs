using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO AddedKitchenObjectSO;
    }

    [SerializeField]
    private List<KitchenObjectSO> _validKitchenObjectSOList;

    [SerializeField]
    private List<KitchenObjectSO> _kitchenObjectSOList;

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!_validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }

        if (!_kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            _kitchenObjectSOList.Add(kitchenObjectSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                AddedKitchenObjectSO = kitchenObjectSO
            });
            return true;
        }

        return false;
    }

    public List<KitchenObjectSO> GetKitcehnObjectSOList()
    {
        return _kitchenObjectSOList;
    }
}
