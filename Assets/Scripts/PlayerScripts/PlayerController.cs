using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //assign
    private Rigidbody2D rb;

    //movement variables
    public Vector2 moveInput;
    public float speed = 10f;
    private float _activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 1f;

    private float _dashCounter;
    private float _dashCoolCounter;


    //caching
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _activeMoveSpeed = speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * _activeMoveSpeed;
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Dash();
    }

    private void Dash ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_dashCoolCounter <= 0 && _dashCounter <= 0)
            {
                _activeMoveSpeed = dashSpeed;
                _dashCounter = dashLength;
            }
        }

        if (_dashCounter > 0)
        {
            _dashCounter -= Time.deltaTime;
            if (_dashCounter <= 0)
            {
                _activeMoveSpeed = speed;
                _dashCoolCounter = dashCooldown;
            }
        }

        if (_dashCoolCounter > 0)
        {
            _dashCoolCounter -= Time.deltaTime;
        }  
    }
}

