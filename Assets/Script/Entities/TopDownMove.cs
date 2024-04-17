using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopDownMove : MonoBehaviour
{
    private Topdown _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _knockback=Vector2.zero;
    private float knockbackDuration = 0.0f;
    private void Awake()
    {
        _controller = GetComponent<Topdown>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
        
    }
    public void ApplyKnockback(Transform other,float power,float duration) 
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }

    private void FixedUpdate() // 물리처리후 호출됨 = 업데이트보다 호출이 느림
    {
        ApplyMovement(_movementDirection);
        if (knockbackDuration > 0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    private void Move(Vector2 direction) 
    {
        _movementDirection = direction;
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStats.speed ;
        if (knockbackDuration > 0.0f) 
        {
            direction += _knockback;
        }
        _rigidbody2D.velocity = direction; //속도 저장
    }
}
