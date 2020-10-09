using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private BoxCollider2D playerBoxCollider;
    //private GameObject player;
    private Rigidbody2D rigidbody2d;
    [SerializeField] private LayerMask platformsLayerMask;
    private float jumpSpeed = 10.0f;
    private float movementSpeed = 5.0f;
    private bool hasHitZenith = false;

    // Start is called before the first frame update
    void Start()
    {

        //player = player.GetComponent<GameObject>();
        playerBoxCollider = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //regular jump
        if (Input.GetKey(KeyCode.W))
        {
            jumpSpeed = 10.0f;
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q))
            {
                //don't allow two jumps at once
            }
            else if (IsGrounded())
            {
                rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 20;
                hasHitZenith = false;
            }
            else if (!IsGrounded() && !hasHitZenith)
            {
                rigidbody2d.velocity += Vector2.up * jumpSpeed * Time.deltaTime * 2;
            }
        }

        //propelled jump
        if (Input.GetKey(KeyCode.Q))
        {
            jumpSpeed = 100.0f;
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.W))
            {
                //don't allow two jumps at once
            }
            else if (IsGrounded())
            {
                rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 20;
                hasHitZenith = false;
            }
            else if (!IsGrounded() && !hasHitZenith)
            {
                rigidbody2d.velocity += Vector2.up * jumpSpeed * Time.deltaTime * 2;
            }
        }

        //zoom jump (push forward)
        if (Input.GetKey(KeyCode.E))
        {
            jumpSpeed = 20.0f;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Q))
            {
                //don't allow two jumps at once
            }
            else if (IsGrounded())
            {
                rigidbody2d.velocity = Vector2.right * jumpSpeed * Time.deltaTime * 20;
                rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 20;
                hasHitZenith = false;
            }
            else if (!IsGrounded() && !hasHitZenith)
            {
                rigidbody2d.velocity += Vector2.right * jumpSpeed * Time.deltaTime * 2;
                rigidbody2d.velocity += Vector2.up * jumpSpeed * Time.deltaTime * 2;
            }
        }


        if (rigidbody2d.velocity.y >= 7.5f || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {

            hasHitZenith = true;

        }
        
        if (transform.position.y <= -6.0f)
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
