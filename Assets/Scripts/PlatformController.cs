using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;
    private float platformSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2d = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + new Vector3(-platformSpeed, 0.0f, 0.0f);

        if (transform.position.x <= -42)
        {

            transform.position = new Vector3(42, Random.Range(0.0f, 1.0f), transform.position.z);

        }

        platformSpeed += 0.01f * Time.deltaTime;

    }
}
