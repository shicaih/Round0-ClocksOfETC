using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f, maxAirAcceleration = 1f;

    [SerializeField, Range(0f, 10f)]
    float jumpHeight = 2f;

    [SerializeField, Range(0, 10)]
    int maxAirJumps = 2;

    Vector3 velocity, desiredVelocity;
    Rigidbody body;
    bool desiredJump, onGround;
    int jumpPhase;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        
        // Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxAcceleration;

        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        // float maxSpeedChange = maxAcceleration * Time.deltaTime;

        desiredJump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        UpdateState();
        if (desiredJump)
        {
            desiredJump = false;
            Jump();
        }

        float acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        body.velocity = velocity;
        onGround = false;
    }

    void Jump()
    {
        if (onGround || jumpPhase <maxAirJumps)
        {
            gameObject.GetComponent<AudioSource>().Play();
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(0f, jumpSpeed - velocity.y);
            }
            velocity.y += jumpSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }

    void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.5f;
        }
    }

    void UpdateState()
    {
        velocity = body.velocity;
        if (onGround)
        {
            jumpPhase = 0;
        }
    }
}
