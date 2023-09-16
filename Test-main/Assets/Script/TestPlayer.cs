using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5.0f;
    private bool isGrounded = false;
    // 황준혁 추가 
    public float fastMoveSpeed = 10.0f;
    public float blinkDuration = 0.5f;
    private int jumpsRemaining = 2; // 더블점프
    private bool isBlinking = false;
    private float blinkTimer = 0f;

    public Transform mousepointer;


    private float sprayGauge
    {
        get => _sprayGauge;
        set
        {
            _sprayGauge = value;
            UImanager.Instance.SetSprayGauge(_sprayGauge);
        }
    }

    [SerializeField] private GameObject spray;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private float CurGauge;
    private float timer;

    private bool fillGauge;

    [SerializeField] private float _sprayGauge;

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            jumpsRemaining = 2;
        }

        if (jumpsRemaining > 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;

        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        float speed = isBlinking ? fastMoveSpeed : moveSpeed;

        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        if (isBlinking)
        {
            blinkTimer -= Time.deltaTime;
            if (blinkTimer <= 0f)
            {
                isBlinking = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isBlinking = true;
            blinkTimer = blinkDuration;
        }
        if (Input.GetMouseButton(0))
        {
            if (sprayGauge > 0)
            {
                fillGauge = false;
                sprayGauge -= 0.2f;
                Instantiate(spray,mousepointer.transform.position, Quaternion.identity);
            }
        }

        if (sprayGauge == CurGauge)
        {
            timer += Time.deltaTime;
        }else{
            CurGauge = sprayGauge;
            timer = 0;
        }
        if (timer > 0.5f)
        {
            fillGauge = true;
        }

        if (fillGauge && sprayGauge < 100)
        {
            sprayGauge += 0.5f;
            if (sprayGauge > 100)
                sprayGauge = 100;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")||(collision.gameObject.CompareTag("Ground")||
                                                          collision.gameObject.CompareTag("DropedPlatform")||
                                                          collision.gameObject.CompareTag("ColoredPlatform"))&&collision.contacts[1].normal.y>0.7f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("DropedPlatform")&&other.transform.position.y<transform.position.y)
        {
            other.transform.GetComponent<DroppedPlatform>().Dropped().Forget();
        }
    }
}
