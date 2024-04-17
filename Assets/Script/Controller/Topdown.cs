using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Topdown : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsAttacking { get; set; }
    protected CharacterStatsHandler _stats { get; private set; }

    protected virtual void Update() 
    {
        HandleAttackDelay();
    }

    protected virtual void Awake()
    {
        _stats=GetComponent<CharacterStatsHandler>();
    }


    private void HandleAttackDelay()
    {
        
        if (_stats.CurrentStats.attackSO == null) 
        {
            return;
        }
        if (_timeSinceLastAttack <= _stats.CurrentStats.attackSO.delay) 
        {
            _timeSinceLastAttack += Time.deltaTime;
            //Debug.Log("핸들어택시간들어옴?");
        }
        if (IsAttacking && _timeSinceLastAttack > _stats.CurrentStats.attackSO.delay) 
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(_stats.CurrentStats.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
