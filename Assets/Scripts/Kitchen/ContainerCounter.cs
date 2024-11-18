using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField]
    private KitchenObjectSO _kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (_kitchenObject == null)
        {
            if (player.HasKitchenObject() == false)
            {
                KitchenObject.SpawnKitchenObject(_kitchenObjectSO, player);
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
