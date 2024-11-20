using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float ProgressNormalized;
    }

    public event EventHandler OnCut;

    [SerializeField]
    private CuttingRecipeSO[] _cuttingRecipeSOArray;

    private int _cuttingProgress;

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

                    _cuttingProgress = 0;

                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetSO());
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        ProgressNormalized = (float)_cuttingProgress / (float)cuttingRecipeSO.cuttingProgressMax
                    });
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
            _cuttingProgress++;

            OnCut?.Invoke(this, EventArgs.Empty);

            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetSO());
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                ProgressNormalized = (float)_cuttingProgress / (float)cuttingRecipeSO.cuttingProgressMax
            });

            KitchenObjectSO output = GetOutputForInput(GetKitchenObject().GetSO());
            if (_cuttingProgress >= GetCuttingRecipeSOWithInput(GetKitchenObject().GetSO()).cuttingProgressMax)
            {
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(output, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        return GetCuttingRecipeSOWithInput(input) != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(input);
        return cuttingRecipeSO != null ? cuttingRecipeSO.output : null;
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (CuttingRecipeSO recipeSO in _cuttingRecipeSOArray)
        {
            if (recipeSO.input == input)
            {
                return recipeSO;
            }
        }
        return null;
    }
}