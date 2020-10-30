using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject manager;
    private GameManager managerScript;
    private BoxCollider2D playerBoxCollider;
    private Rigidbody2D rigidbody2d;
    [SerializeField] private LayerMask platformsLayerMask;
    private float jumpSpeed = 10.0f;
    private bool hasHitZenith = false;

    // Start is called before the first frame update
    void Start()
    {

        manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<GameManager>();
        playerBoxCollider = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded())
        {

            rigidbody2d.gravityScale = 4.0f;

        }

        //regular jump
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.E))
            {
                //don't allow two jumps at once
            }
            else if (IsGrounded())
            {
                rigidbody2d.gravityScale = 0.5f;
                rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 36;
                hasHitZenith = false;
            }
            else if (!IsGrounded() && !hasHitZenith)
            {
                //rigidbody2d.velocity += Vector2.up * jumpSpeed * Time.deltaTime * 1;
            }
        }

        //propelled jump
        if (Input.GetKey(KeyCode.E))
        {

            //jumpSpeed = 100.0f;
            if (Input.GetKey(KeyCode.W))
            {
                //don't allow two jumps at once
            }
            else if (IsGrounded())
            {
                rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 160;
                hasHitZenith = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            managerScript.platformSpeed *= 0.5f;

        }

        //propelled jump
        if (Input.GetKeyDown(KeyCode.R))
        {

            managerScript.platformSpeed *= 2.0f;

        }

        //propelled jump
        if (Input.GetKeyUp(KeyCode.Q))
        {

            managerScript.platformSpeed *= 2.0f;

        }

        //propelled jump
        if (Input.GetKeyUp(KeyCode.R))
        {

            managerScript.platformSpeed *= 0.5f;

        }


        if ( Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E))
        {

            hasHitZenith = true;

        }
        
        if (transform.position.y <= -60.0f)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

    private bool IsGrounded()
    {

        RaycastHit2D groundedCheck = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0.0f, Vector2.down, 0.01f, platformsLayerMask);

        return groundedCheck.collider != null;

    }

}
