using UnityEngine;

public interface IKitchenObjectParent
{
    public GameObject GetKitchenObjectFollowPoint();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
}
