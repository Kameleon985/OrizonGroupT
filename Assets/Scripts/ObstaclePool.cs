using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool instance;
    private List<GameObject> pool;

    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private int objectsLimit;

    private void Awake()
    {
        pool = new List<GameObject>();
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i =0; i < objectsLimit; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab);
            obj.transform.parent = transform;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public void DespawnAll()
    {
        for(int i =0; i < pool.Count; i++)
        {
            pool[i].SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return null;
    }
}
