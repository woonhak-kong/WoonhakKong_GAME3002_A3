using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float JumpPower;
    public PlayerState CurrentState;
    public PlayerJumpState CurrentJumpState;
    public float GravityScale;
    public Transform GroundSensor;

    public bool BlueKey = false;
    public bool BlackKey = false;


    private Rigidbody _rigidbody;
    private Vector2 _inputVector;



    private float globalGravity = -9.81f;


    public enum PlayerState
    {
        IDLE,
        RUN,
        JUMP,
        DEAD
    }

    public enum PlayerJumpState
    {
        GROUND,
        JUMP1,
        JUMP2
    }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        CurrentState = PlayerState.IDLE;
        CurrentJumpState = PlayerJumpState.GROUND;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        Jump();

        Vector3 gravity = globalGravity * GravityScale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Move()
    {
        _rigidbody.AddForce(new Vector3(_inputVector.x * Speed, 0, 0), ForceMode.Force);

        if (_rigidbody.velocity.x > MaxSpeed)
        {
            _rigidbody.velocity = new Vector3(MaxSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }
        else if (_rigidbody.velocity.x < -MaxSpeed)
        {
            _rigidbody.velocity = new Vector3(-MaxSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }
    }

    private void Jump()
    {
        if (_inputVector.y > 0)
        {
            
            if (CurrentJumpState == PlayerJumpState.GROUND)
            {
                CurrentJumpState = PlayerJumpState.JUMP1;
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z);
                _rigidbody.AddForce(new Vector3(0, _inputVector.y * JumpPower, 0), ForceMode.Impulse);
            }
            else if (CurrentJumpState == PlayerJumpState.JUMP1)
            {
                CurrentJumpState = PlayerJumpState.JUMP2;
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z);
                _rigidbody.AddForce(new Vector3(0, _inputVector.y * JumpPower, 0), ForceMode.Impulse);
            }
            else if (CurrentJumpState == PlayerJumpState.JUMP2)
            {
                _inputVector.y = 0;
            }

            _inputVector.y = 0;
        }

        
    }


    private void CheckGround()
    {
        if (_rigidbody.velocity.y > 0)
            return;
        if (CurrentJumpState == PlayerJumpState.GROUND)
            return;

        RaycastHit hit;
        bool isThere = Physics.Raycast(GroundSensor.position, GroundSensor.up, out hit, 1.0f);
        if (isThere && hit.collider.tag == "Ground")
        {
            CurrentJumpState = PlayerJumpState.GROUND;
        }
        //print(hit.collider.name);
    }

    private void OnMove(InputValue value)
    {
        //print(value.Get<Vector2>().x + ", " + value.Get<Vector2>().y);
        _inputVector.x = value.Get<Vector2>().x;
    }

    private void OnJump(InputValue value)
    {
        print(value.Get<float>());
        _inputVector.y = value.Get<float>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Ground" && CurrentJumpState != PlayerJumpState.GROUND)
        {
            RaycastHit hit;
            bool isThere = Physics.Raycast(GroundSensor.position, GroundSensor.up, out hit, 1.0f);
            if (isThere && hit.collider.tag == "Ground")
            {
                CurrentJumpState = PlayerJumpState.GROUND;
            }
        }


       // CheckGround();
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckGround();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GroundSensor.position, GroundSensor.position + GroundSensor.up * 1.0f);
    }
}
