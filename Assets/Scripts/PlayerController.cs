using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {

            rigidbody2d.velocity = Vector2.up * jumpSpeed * Time.deltaTime * 20;
            hasHitZenith = false;

        }
        else if (Input.GetKey(KeyCode.W) && !hasHitZenith)
        {

            rigidbody2d.velocity += Vector2.up * jumpSpeed * Time.deltaTime * 2;

        }

        if (rigidbody2d.velocity.y >= 7.5f || Input.GetKeyUp(KeyCode.W))
        {

            hasHitZenith = true;

        }

    }

    private bool IsGrounded()
    {

        RaycastHit2D groundedCheck = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0.0f, Vector2.down, 0.01f, platformsLayerMask);

        return groundedCheck.collider != null;

    }

}
