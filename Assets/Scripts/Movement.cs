using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _speedJump = 5f;

    [Range(0f, 2f)]
    [SerializeField] private float _velocityDecrease = 1f;

    [SerializeField] private ForceMode _forceMoveMode = ForceMode.Impulse;
    [SerializeField] private ForceMode _forceJumpMode = ForceMode.Force;

    public bool CanMove { get; set; } = true;

    private bool _isForwardProgress = false;
    private bool _isBackProgress = false;
    private bool _isLeftProgress = false;
    private bool _isRightProgress = false;

    private bool _isJumpProgress = false;

    private bool _isGrounded = true;

    private Vector3 _startPosition;


    public void Awake()
    {
        _startPosition = transform.position;        
    }

    public void Init()
    {
        transform.position = _startPosition;

        _isForwardProgress = false;
        _isBackProgress = false;
        _isLeftProgress = false;
        _isRightProgress = false;

        _isJumpProgress = false;
        _isGrounded = true;       

        _rigidbody.velocity = new Vector3(0f, 0f, 0f);
        _rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);

        _rigidbody.isKinematic = false;                

        CanMove = true;
    }



    private void Update()
    {
        if (CanMove)
            MoveToInput();
        else
            _rigidbody.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (_isForwardProgress)
        {
            Move(Vector3.forward, _speedMove, _forceMoveMode);
            _isForwardProgress = false;
        }

        if (_isBackProgress)
        {
            Move(-Vector3.forward, _speedMove, _forceMoveMode);
            _isBackProgress = false;
        }

        if (_isLeftProgress)
        {
            Move(-Vector3.right, _speedMove, _forceMoveMode);
            _isLeftProgress = false;
        }

        if (_isRightProgress)
        {
            Move(Vector3.right, _speedMove, _forceMoveMode);
            _isRightProgress = false;
        }

        if (_isJumpProgress && _isGrounded)
        {
            Jump(Vector3.up, _speedJump, _forceJumpMode);
        }
    }

    private void MoveToInput()
    {
        if (_isJumpProgress == false)
        {
            if (Input.GetKey(KeyCode.W))
                _isForwardProgress = true;


            if (Input.GetKey(KeyCode.A))
                _isLeftProgress = true;


            if (Input.GetKey(KeyCode.S))
                _isBackProgress = true;


            if (Input.GetKey(KeyCode.D))
                _isRightProgress = true;
        }

        if (Input.GetKey(KeyCode.Space))
            _isJumpProgress = true;
    }

    private void Jump(Vector3 direction, float speed, ForceMode forceMode)
    {
        _isGrounded = false;

        _rigidbody.velocity *= _velocityDecrease;

        _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, forceMode);     

        _isJumpProgress = false;
    }

    private void Move(Vector3 direction, float speed, ForceMode forceMode)
    {
        _rigidbody.velocity *= _velocityDecrease;

        _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, forceMode);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isJumpProgress = false;

        _isGrounded = true;
    }
}
