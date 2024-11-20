using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField]
    protected GameObject _kitchenObjectFollowPoint;

    protected KitchenObject _kitchenObject;

    public virtual void Interact(Player player)
    {
        Debug.Log("Default Interact!");
    }

    public virtual void InteractAlternate(Player player)
    {
        Debug.Log("Default InteractAlternate!");
    }

    public GameObject GetKitchenObjectFollowPoint()
    {
        return _kitchenObjectFollowPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        _kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
}