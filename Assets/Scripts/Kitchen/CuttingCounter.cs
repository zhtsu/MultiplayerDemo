using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]
    private CuttingRecipeSO[] _cuttingRecipeSOArray;

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
                if (HasRecipeWithInput(player.GetKitchenObject().GetSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
            else
            {

            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetSO()))
        {
            KitchenObjectSO output = GetOutputForInput(GetKitchenObject().GetSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(output, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipeSO in _cuttingRecipeSOArray)
        {
            if (recipeSO.input == input)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipeSO in _cuttingRecipeSOArray)
        {
            if (recipeSO.input == input)
            {
                return recipeSO.output;
            }
        }
        return null;
    }
}
