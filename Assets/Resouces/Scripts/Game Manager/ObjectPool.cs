using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool ObjectInstance;
    public GameObject objectToPool;
    public List<GameObject> pooledObject;
    public int amount;
    // Start is called before the first frame update
    void Awake()
    {
        CheckIfObjectPoolIsInTheScene();
    }

    // Update is called once per frame
    void Start()
    {
        pooledObject = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject temp = (GameObject)Instantiate(objectToPool);
            temp.transform.SetParent(transform);
            temp.SetActive(false);
            pooledObject.Add(temp);
        }    
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if(!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        return null;
    }

    private void CheckIfObjectPoolIsInTheScene()
    {
        if (ObjectInstance == null)
        {
            ObjectInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
