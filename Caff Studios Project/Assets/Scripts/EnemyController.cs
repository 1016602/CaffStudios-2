using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // A basic enemy controller for prototyping - will pick a random speed and direction every few seconds or so
    //To improve: Mkae sure it cant walk off an edge - Make it react when shot

    float speed1;
    float speed2;
    int maxTime;
    public Material Red;
    void Start()
    {
       // StartCoroutine(Change());
       // StartCoroutine(Change());
    }

    // Update is called once per frame
    void Update()
    {
       // print(Time.deltaTime); //get this working later
    }

    IEnumerator Change()
    {
        speed1 = Random.Range(-10, 10);
        speed2 = Random.Range(-10, 10);
        maxTime = Random.Range(0, 5);
        transform.Translate(Vector3.forward * speed1);
        transform.Translate(Vector3.right * speed2);
        // GetComponent<Renderer>().material = Red;
        yield return new WaitForSeconds(maxTime);
        StartCoroutine(Change());
    }
}
