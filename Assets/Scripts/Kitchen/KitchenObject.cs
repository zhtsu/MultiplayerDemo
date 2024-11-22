using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectSO _kitchenObjectSO;

    private IKitchenObjectParent _kitchenObjectParent;

    public KitchenObjectSO GetSO()
    {
        return _kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (_kitchenObjectParent != null)
        {
            _kitchenObjectParent.ClearKitchenObject();
        }

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject!");
        }

        _kitchenObjectParent = kitchenObjectParent;
        _kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowPoint().transform;
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return _kitchenObjectParent;
    }

    public void DestroySelf()
    {
        _kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO SO, IKitchenObjectParent parent)
    {
        GameObject gameObject = Instantiate(SO.Prefab);
        KitchenObject kitchenObject = gameObject.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(parent);
        return kitchenObject;
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }

        plateKitchenObject = null;
        return false;
    }
}
