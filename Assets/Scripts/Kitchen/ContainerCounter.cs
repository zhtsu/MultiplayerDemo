using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField]
    private KitchenObjectInfo _kitchenObjectInfo;

    public override void Interact(Player player)
    {
        if (_kitchenObject == null)
        {
            if (player.HasKitchenObject() == false)
            {
                GameObject gameObject = Instantiate(_kitchenObjectInfo.prefab);
                gameObject.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
