using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    private KitchenObjectInfo _kitchenObjectInfo;

    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {

            }
        }
    }
}
