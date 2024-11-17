using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField]
    private KitchenObjectInfo _kitchenObjectInfo;

    [SerializeField]
    private GameObject _kitchenObjectFollowPoint;

    private KitchenObject _kitchenObject;

    public void Interact(Player player)
    {
        if (_kitchenObject == null)
        {
            GameObject gameObject = Instantiate(_kitchenObjectInfo.prefab, _kitchenObjectFollowPoint.transform);
            gameObject.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
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
