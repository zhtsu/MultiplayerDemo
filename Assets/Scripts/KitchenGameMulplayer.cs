using Unity.Netcode;
using UnityEngine;

public class KitchenGameMulplayer : MonoBehaviour
{
    public static KitchenGameMulplayer Instance { get; private set; }

    [SerializeField]
    private KitchenObjectListSO _kitchenObjectListSO;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnKitchenObject(KitchenObjectSO SO, IKitchenObjectParent parent)
    {
        SpawnKitchenObjectServerRpc(GetKitchenObjectSOIndex(SO), parent.GetNetworkObject());
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnKitchenObjectServerRpc(int SOIndex, NetworkObjectReference parentNetworkObjectRef)
    {
        GameObject gameObject = Instantiate(GetKitchenObjectSOFromIndex(SOIndex).Prefab);

        NetworkObject kitchenObjectNetworkObject = gameObject.GetComponent<NetworkObject>();
        kitchenObjectNetworkObject.Spawn(true);

        KitchenObject kitchenObject = gameObject.GetComponent<KitchenObject>();

        parentNetworkObjectRef.TryGet(out NetworkObject kitchenObjectParentNetworkObject);
        IKitchenObjectParent kitchenObjectParent = kitchenObjectParentNetworkObject.GetComponent<IKitchenObjectParent>();

        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
    }

    private int GetKitchenObjectSOIndex(KitchenObjectSO kitchenObject)
    {
        return _kitchenObjectListSO.KitchenObjectSOList.IndexOf(kitchenObject);
    }

    private KitchenObjectSO GetKitchenObjectSOFromIndex(int kitchenObjectSOIndex)
    {
        return _kitchenObjectListSO.KitchenObjectSOList[kitchenObjectSOIndex];
    }
}
