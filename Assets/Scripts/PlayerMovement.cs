using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    [Header("Referenced Scripts:")]
    public PlayerManager playerMgr;

    private void Start()
    {
        if (playerMgr == null)
            playerMgr = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Moves the player when you press W, A, S, or D / Arrow keys.
        Vector3 playerInput = new (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = speed * playerInput.normalized * Time.deltaTime;
    }
}
