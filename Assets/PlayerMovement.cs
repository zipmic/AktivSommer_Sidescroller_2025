using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float groundCheckRadius = 0.2f;
	[SerializeField] private LayerMask groundLayer;

	private Rigidbody2D rb;
	private bool isGrounded;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.linearVelocityY = jumpForce;
		}
	}

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

		float moveInput = 0f;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			moveInput = -1f;
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			moveInput = 1f;

		rb.linearVelocityX = moveInput * moveSpeed;
	}

	private void OnDrawGizmosSelected()
	{
		if (groundCheck != null)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
		}
	}

	public void StartSpeedBoost(float amount, float duration)
	{
		StopAllCoroutines();
		StartCoroutine(SpeedBoostCoroutine(amount, duration));
	}

	private IEnumerator SpeedBoostCoroutine(float amount, float duration)
	{
		float originalSpeed = moveSpeed;
		moveSpeed += amount;
		yield return new WaitForSeconds(duration);
		moveSpeed = originalSpeed;
	}
}
