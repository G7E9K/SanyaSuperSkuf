using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//эта строчка гарантирует что наш скрипт не завалится 
//ести на плеере будет отсутствовать компонент Rigidbody
//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotSpeed = 1f;
    [SerializeField] private float _gravity = -9.81f;
    private Vector3 _movementVector;
    private Vector3 _inputVector;
    // [SerializeField] private CharacterController _characterController;
    private InputAsset _actions;
    private float _mouseX;

    void Awake()
    {
        _actions = new InputAsset();
        _actions.Enable();
        // _actions.Player.Movement.performed += _ => ReadInput();
        _actions.Player.Attack.performed += _ => Attack();
    }

    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        ReadInput();
        Rotate();
        Move();
    }

    private void Rotate()
    {
        _mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, _mouseX*_rotSpeed*Time.deltaTime);
    }

    private void ReadInput()
    {
        _inputVector = _actions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(_inputVector.ToString());
        // _movementVector = new Vector3(_inputVector.x, 0, _inputVector.y);
        _movementVector = _inputVector.x*transform.right + _inputVector.y*transform.forward;
    }

    private void Move()
    {
        // _inputVector = _actions.Player.Movement.ReadValue<Vector2>();
        // Debug.Log(_inputVector.ToString());
        // _movementVector = new Vector3(_inputVector.x, 0, _inputVector.y);
        // _characterController.Move(_movementVector*_moveSpeed*Time.deltaTime);
        transform.Translate(_movementVector*_moveSpeed*Time.deltaTime);
    }

    private void Attack()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        // IsGroundedUpate(collision, false);
    }
}
