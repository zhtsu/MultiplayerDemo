using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField]
    private PlatesCounter _platesCounter;

    [SerializeField]
    private GameObject _counterTopPoint;

    [SerializeField]
    private GameObject _plateVisualPrefab;

    private List<GameObject> _plateVisualGameObjectList = new List<GameObject>();

    private void Start()
    {
        _platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        _platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateVisualObj = _plateVisualGameObjectList[_plateVisualGameObjectList.Count - 1];
        _plateVisualGameObjectList.Remove(plateVisualObj);
        Destroy(plateVisualObj);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        GameObject plateVisualObj = Instantiate(_plateVisualPrefab, _counterTopPoint.transform);
        float plateOffsetY = .1f;
        plateVisualObj.transform.localPosition = new Vector3(0, plateOffsetY * _plateVisualGameObjectList.Count, 0);
        _plateVisualGameObjectList.Add(plateVisualObj);
    }
}
