using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int scoreMultiplier = 1;
    public float pickupTimer = 0.0f;
    public float platformSpeed = 0.05f;
    public GameObject flatScorePickup;
    public GameObject scoreMultiplierPickup;
    public GameObject platform;
    public Text scoreText;
    public Text multiplierText;
    public GameObject player;

    private int pickupType;
    private float gameTimer = 0.0f;
    private GameObject pickup;

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

        if (Input.GetKeyDown("space") && Time.timeScale == 1)
        {

            Time.timeScale = 0;
            //platformSpeed = 0.0f;

        }
        else if (Input.GetKeyDown("space"))
        {

            Time.timeScale = 1;

        }

        gameTimer += Time.deltaTime;

        if (gameTimer > 1.0f)
        {

            gameTimer = 0.0f;
            score += 10 * scoreMultiplier;
            scoreText.text = " Score: " + score;

        }

        if (pickupTimer > 0.0f)
        {

            pickupTimer -= Time.deltaTime;

            multiplierText.text = " Score x" + scoreMultiplier + ": " + ((int)pickupTimer + 1) + "s";

            if (pickupTimer <= 0.0f)
            {

                scoreMultiplier = 1;
                multiplierText.text = "";

            }

        }

        platformSpeed += 0.0015f * Time.deltaTime;
        
        
        if (platform.transform.position.x <= player.transform.position.x + 9.0f)
        {

            int platformType = Random.Range(0, 2);
            pickupType = Random.Range(0, 3);

            if (platformType == 1)
            {

                //regular platform spawns
                platform = Instantiate(platform, new Vector3(player.transform.position.x + 24.0f, Random.Range(platform.transform.position.y - 3, platform.transform.position.y + 6), 1.0f), Quaternion.identity);
                platform.transform.localScale = new Vector3(Random.Range(platformMinWidth, platformMaxWidth), 3.5f, 1.0f);

                if (pickupType == 1)
                {

                    pickup = flatScorePickup;

                }
                else if (pickupType == 2)
                {

                    pickup = scoreMultiplierPickup;

                }
                else
                {

                    return;

                }

            }
            else
            {

                //regular platform spawns
                platform = Instantiate(platform, new Vector3(player.transform.position.x + 34, platform.transform.position.y, 1.0f), Quaternion.identity);
                platform.transform.localScale = new Vector3(Random.Range(platformMinWidth, platformMaxWidth), 3.5f, 1.0f);

                if (pickupType == 1)
                {

                    pickup = flatScorePickup;

                }
                else if (pickupType == 2)
                {

                    pickup = scoreMultiplierPickup;

                }
                else
                {

                    return;

                }

            }

            pickup = Instantiate(pickup, new Vector3(platform.transform.position.x, platform.transform.position.y + 1.0f, 1.0f), Quaternion.identity);
            pickup.GetComponent<PickupController>().isActive = 1;
            pickup.GetComponent<PickupController>().pickupType = pickupType;

        }


    }

}
