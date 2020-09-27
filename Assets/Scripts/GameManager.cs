using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject platform;
    public float platformSpeed = 0.05f;
    private float counter = 2.0f;

    //regular platform var
    public float platformMinRange = -3.0f;
    public float platformMaxRange = 3.0f;
    public float platformMinWidth = 50.0f;
    public float platformMaxWidth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;

        Debug.Log(counter);

        if (platform.transform.position.y <= -2.8f)
        {
            counter = 0.0f;

            //high platform spawns
            platform = Instantiate(platform, new Vector3(15.0f, 3.0f, 1.0f), Quaternion.identity);
            platform.transform.localScale = new Vector3(Random.Range(platformMinWidth, platformMaxWidth), 3.5f, 1.0f);

        }
        else if (platform.transform.position.x <= 0.0f)
        {

            counter = 0.0f;

            //regular platform spawns
            platform = Instantiate(platform, new Vector3(15.0f, Random.Range(platformMinRange, platformMaxRange), 1.0f), Quaternion.identity);
            platform.transform.localScale = new Vector3(Random.Range(platformMinWidth, platformMaxWidth), 3.5f, 1.0f);

        }

        platformSpeed += 0.001f * Time.deltaTime;

    }

}
