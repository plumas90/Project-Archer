using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;
    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem _collidingTargetHealthSystem;
    private TopDownMove _collidingMove;
    
    protected override void Start()
    {
        base.Start();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += Ondamege;
    }

    private void Ondamege()
    {
        followRange = 100f;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_isCollidingWithTarget) 
        {
            ApplyHealthChange();
        }
        Vector2 direction = Vector2.zero;
        if (DistanceToTarget() < followRange) 
        {
            direction = DirectionTotarget();
        }
        CallMoveEvent(direction);
        Rotate(direction);
    }
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ)  > 90f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver =collision.gameObject;
        if (!receiver.CompareTag(targetTag)) 
        {
            return;
        }
        _collidingTargetHealthSystem =receiver.GetComponent<HealthSystem>();
        if (_collidingTargetHealthSystem != null) 
        {
            _isCollidingWithTarget = true;
        }
        _collidingMove = receiver.GetComponent<TopDownMove>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;
        if (!receiver.CompareTag(targetTag))
        {
            return;
        }
        _isCollidingWithTarget = false;
    }

    private void ApplyHealthChange() 
    {
        AttackSO attackSO = _stats.CurrentStats.attackSO;
        bool hasBeenChanged = _collidingTargetHealthSystem.ChangeHealth(-attackSO.power);
        if(attackSO.isOnKnockback && _collidingMove != null)
        {
            _collidingMove.ApplyKnockback(transform, attackSO.knockbackPower, attackSO.knockbackTime);
        
        }

    }
}
