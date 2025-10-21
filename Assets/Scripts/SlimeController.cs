using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Blow Up")]
    public float blowUpScale = 2f;
    public float blowUpSpeed = 5f;

    [Header("Face")]
    public Transform faceTransform;  // 拖入臉的子物件

    private Vector3 originalScale;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;       // 冻結物理旋轉
        originalScale = transform.localScale;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleBlowUp();
    }

    void LateUpdate()
    {
        // 保持臉正向
        if (faceTransform != null)
            faceTransform.rotation = Quaternion.identity;
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void HandleBlowUp()
    {
        if (Input.GetKey(KeyCode.Space))
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * blowUpScale, blowUpSpeed * Time.deltaTime);
        else
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, blowUpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}


