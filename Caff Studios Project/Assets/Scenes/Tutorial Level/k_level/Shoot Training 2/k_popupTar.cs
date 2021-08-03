using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_popupTar : MonoBehaviour
{
    private GameObject spawnPoint1;
    private GameObject spawnPoint2;

    public int destroyTime;
    public float speed;
    public float distance;

    public bool right, left;

    private float startTime = 0f;

    void Start()
    {
        spawnPoint1 = GameObject.Find("Spwan1");
        spawnPoint2 = GameObject.Find("Spwan2");

        startTime = Time.time;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(Destroy());

        //Object moves(ping pong) to left if spwan from right
        //Object moves(ping pong) to right if spwan from left
        if (transform.position == spawnPoint1.transform.position)
        {
            right = true;
        }

        if (transform.position == spawnPoint2.transform.position)
        {
            left = true;
        }

        if (right)
        {
            transform.position = new Vector3(spawnPoint1.transform.position.x + Mathf.PingPong((Time.time - startTime) * speed, distance), transform.position.y, transform.position.z);
        }

        if (left)
        {
            transform.position = new Vector3(spawnPoint2.transform.position.x - Mathf.PingPong((Time.time - startTime) * speed, distance), transform.position.y, transform.position.z);
        }

    }
}
