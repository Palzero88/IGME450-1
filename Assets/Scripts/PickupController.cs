using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    public int isActive;
    public int pickupType;
    public GameObject manager;
    private GameManager managerScript;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {

        manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<GameManager>();
        //rigidbody2d = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + new Vector3(-managerScript.platformSpeed, 0.0f, 0.0f) * isActive;

        if (transform.position.x <= -11.0f)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (pickupType == 1)
        {

            managerScript.score += 100;

        }
        else
        {

            managerScript.scoreMultiplier += 1;
            managerScript.pickupTimer = 10.0f;

        }

        Destroy(gameObject);

    }

}
