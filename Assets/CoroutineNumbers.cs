using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineNumbers : MonoBehaviour
{
    public int maxCount;
    public Vector3 endLocation;
    Vector3 offset;

    IEnumerator CoroutineCounting(float waitTime)
    {
        int number = 0;
        while ( number <= maxCount)
        {
            Debug.Log(number);
            number++;
            yield return new WaitForSeconds(waitTime);
        }
        transform.position = Vector3.Lerp(endLocation, transform.position + offset, Time.deltaTime);
        
    }


    // Use this for initialization
    void Start ()
    {
        offset = endLocation - transform.position;
	}

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(CoroutineCounting(.5f));
        }
    }

}
