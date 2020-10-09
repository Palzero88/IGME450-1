using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public GameObject manager;
    private GameManager managerScript;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {

        manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + new Vector3(-managerScript.platformSpeed, 0.0f, 0.0f);

        if (transform.position.x <= -28.0f)
        {
            
            Destroy(gameObject);

        }

    }
}
