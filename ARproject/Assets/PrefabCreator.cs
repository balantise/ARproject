using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject StanokPrefab;
    [SerializeField] private Vector3 prefabOffcet;
    GameObject stanok;
    private ARTrackedImageManager aRTrackedImageManager;
    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var image in obj.added) 
        {
            stanok=Instantiate(StanokPrefab, image.transform);
            stanok.transform.position += prefabOffcet;
        }
    }
}
