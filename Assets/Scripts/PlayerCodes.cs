using UnityEngine;

public class PlayerCodes : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float moveSpeed = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }


    void Update()
    {
        InputSistem();
        Move();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    private void InputSistem()
    {
        moveInput = Input.GetAxis("Horizontal");
            if(moveInput != 0f)
            {
                transform.localScale = new Vector3 (moveInput, 1f, 1f);
            }
    }

}
