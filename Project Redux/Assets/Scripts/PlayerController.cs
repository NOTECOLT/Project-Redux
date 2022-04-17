using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float moveSpeed = 3f;

    private Vector2 _walkInput;

    private Rigidbody2D _rb;

    private Timer _attackTimer;
    private bool _isAttacking;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();

        _attackTimer = new Timer(3.0f);
    }


    void Update() {
        MoveInput();
        AttackInput();

        if (_isAttacking) {
            _attackTimer.UpdateTimer(Time.deltaTime);

            if (_attackTimer.timerTriggered)
                _isAttacking = false;
        }
    }

    private void FixedUpdate() {
        _rb.MovePosition((Vector2)transform.position + _walkInput * Time.deltaTime * moveSpeed);
    }

    private void MoveInput() {
        _walkInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _walkInput = Vector2.ClampMagnitude(_walkInput, 1f);
    }

    private void AttackInput() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (!_isAttacking) {
                Debug.Log("Attack!");
                _attackTimer.ResetTimer();
                _isAttacking = true;
            } else Debug.Log("Can't attack yet bro");
        } 
    }
}

