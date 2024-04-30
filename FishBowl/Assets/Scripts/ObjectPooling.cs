using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private int amountToPool = 5; 
    [SerializeField] private GameObject[] feedPrefab = new GameObject[3];
    private List<GameObject> pooledObjectsFeed = new List<GameObject>();

    public static ObjectPooling instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < amountToPool; i++)
        {
            InitializePool(pooledObjectsFeed, feedPrefab[Random.Range(0,feedPrefab.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void InitializePool(List<GameObject> pool, GameObject prefab)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            pool.Add(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetPooledObject(List<GameObject> pool)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public GameObject GetPooledObjectFeed()
    {
        return GetPooledObject(pooledObjectsFeed);
    }
}
                                                                                                 