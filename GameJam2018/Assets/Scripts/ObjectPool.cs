using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool objectPool;
    public GameObject[] poolableGameObjects;
    public int[] pooledAmount;

    List<GameObject> pooledObjects;

    private void Awake()
    {

        objectPool = this;
    }

    void Start()
    {

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolableGameObjects.Length; i++)
        {
            for (int j = 0; j < pooledAmount[i]; j++)
            {
                GameObject obj = (GameObject)Instantiate(poolableGameObjects[i]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

    }

    public GameObject GetPooledObjct(string name, bool willGrow)
    {
        string OriString = name + ("(Clone)");
        Debug.Log(name);
        for (int i = 0; i < pooledObjects.Count; i++)
        {   
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == OriString)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            
            Debug.Log(name);
            GameObject obj = (GameObject)Instantiate(Resources.Load(name) as GameObject);
            pooledObjects.Add(obj);
            return obj;

        }
        return null;
   }
}