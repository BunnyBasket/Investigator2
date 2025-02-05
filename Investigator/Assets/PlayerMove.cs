using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb; 
    public Camera mainCamera;

    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
void Start()
{
    mainCamera = Camera.main;
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
}

void FixedUpdate()
{
    float moveX = 0f;
    float moveY = 0f;
    bool isWalking = false;

    if (Input.GetKey(KeyCode.W))
    {
        moveY += 1f;
        spriteRenderer.sprite = up;
        isWalking = true;
    }
    if (Input.GetKey(KeyCode.S))
    {
        moveY -= 1f;
        spriteRenderer.sprite = down;
        isWalking = true;
    }
    if (Input.GetKey(KeyCode.A))
    {
        moveX -= 1f;
        spriteRenderer.sprite = left;
        isWalking = true;
    }
    if (Input.GetKey(KeyCode.D))
    {
        moveX += 1f;
        spriteRenderer.sprite = right;
        isWalking = true;
    }

    Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
    rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

    // Update animator parameter
    animator.SetBool("IsWalking", isWalking);
}

void LateUpdate()
{
    if (mainCamera != null && rb != null)
    {
        Vector3 targetPosition = new Vector3(rb.position.x, rb.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = targetPosition;
    }
}
}
