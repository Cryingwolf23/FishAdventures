using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedExpire : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowAndHide(gameObject, 10.0f)); // 5 second
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
