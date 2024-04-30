using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFeed : MonoBehaviour
{
    //private float timbeBetweenSpawn;
    public float setTime;
    public float xPos;
    Vector3 spawnPos;
    //int amountToPool = 5;

    public GameObject[] feedVariety = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine(SpawnFeeds());
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = new Vector3(xPos, transform.position.y, transform.position.z);
        xPos = Random.Range(-10, 9);
      


        //if (timbeBetweenSpawn <= 0)
        //{

        //    Instantiate(feedVariety[Random.Range(0, 3)], spawnPos, transform.rotation);
        //    timbeBetweenSpawn = setTime;

        //}
        //else
        //{
        //    timbeBetweenSpawn -= Time.deltaTime;
        //}

    }
    IEnumerator SpawnFeeds()
    {
        while (true)
        {
            yield return new WaitForSeconds(setTime);
            SpawnObject(ObjectPooling.instance.GetPooledObjectFeed(), spawnPos);
        }
    }

    void SpawnObject(GameObject obj, Vector3 position)
    {
        if (obj != null)
        {
            obj.transform.position = position;
            obj.SetActive(true);
        }
    }

}
