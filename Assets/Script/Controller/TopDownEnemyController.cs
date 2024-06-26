using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemyController : Topdown
{
    GameManager gameManager;
    protected Transform ClosetTarget { get; private set; }

    protected override void Awake() 
    {
        base.Awake();
    }
    protected virtual void Start() 
    {
        gameManager = GameManager.Instance;
        ClosetTarget = gameManager.player.transform;
    }
    protected virtual void FixedUpdate() 
    {
    
    }
    protected float DistanceToTarget() 
    {
        return Vector3.Distance(transform.position, ClosetTarget.position);
    }

    protected Vector2 DirectionTotarget() 
    {
        return (ClosetTarget.position - transform.position).normalized;
    }
}
