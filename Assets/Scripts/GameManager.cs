using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject platform;
    public float platformSpeed = 0.05f;
    private float counter = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;

        Debug.Log(counter);
            
        if (platform.transform.position.x <= 0.0f)
        {

            counter = 0.0f;

            platform = Instantiate(platform, new Vector3(15.0f, Random.Range(-4.748f, 1.0f), -5.25f), Quaternion.identity);
            platform.transform.localScale = new Vector3(Random.Range(35.0f, 100.0f), 3.5f, 1.0f);

        }

        platformSpeed += 0.01f * Time.deltaTime;

    }

}
