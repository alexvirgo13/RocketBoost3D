using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> objectPoolList = new List<GameObject>();

    private void Start()
    {
        CreatePool();
    }

    /// <summary>
    /// Instantiate new object and add it to the pool
    /// </summary>
    /// <returns>GameObject from objectPrefab</returns>
    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objectPrefab);
        obj.SetActive(false);
        objectPoolList.Add(obj);
        return obj;
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject(bool setActive)
    {
        Debug.Log("New Bullet created.");
        GameObject obj = CreateNewObject();
        obj.SetActive(setActive);
        return obj;
    }

    public GameObject GetObjectFromPool()
    {
        GameObject returnedObject = objectPoolList.Find(obj => !obj.activeInHierarchy);
        if (returnedObject != null)
        {
            Debug.Log("Fetching bullet...");
        }
        else
        {
            returnedObject = CreateNewObject();
        }

        returnedObject.SetActive(true);
        return returnedObject;
    }
}
