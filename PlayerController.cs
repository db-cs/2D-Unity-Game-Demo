using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2d;

	private float jumpForce;
	[SerializeField] private float jumpHeight;
	[SerializeField] private float gravityScale = 10;
	[SerializeField] private float fallingGravityScale = 40;

    public bool isGrounded { get; private set; }

    private void Awake() => rb2d = gameObject.GetComponent<Rigidbody2D>();

    private void Start()
	{
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
    }

    private void Update()
	{
        if (GameLogic.instance.isGameRunning()) { 
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }

            if (rb2d.velocity.y >= 0)
            {
                rb2d.gravityScale = gravityScale;
            }
            else if (rb2d.velocity.y < 0)
            {
                rb2d.gravityScale = fallingGravityScale;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                break;
            case "Obstacle":
                GameLogic.instance.HitObstacle();
                break;
        }
    }


}
