using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownRangeEnemyContreoller : TopDownEnemyController
{
    [SerializeField] private float followRange = 15f;
    [SerializeField] private float shootRange = 10f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionTotarget();

        IsAttacking = false;
        if (distance <= followRange)
        {
            if (distance <= shootRange)
            {
                int layerMaskTarget = _stats.CurrentStats.attackSO.target;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 11f, (1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);

                if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                {
                    CallLookEvent(direction);
                    CallMoveEvent(Vector2.zero);
                    IsAttacking = true;
                }
                else
                {
                    CallMoveEvent(direction);
                }
            }
            else
            {
                CallMoveEvent(direction);
            }
        }
        else
        {
            CallMoveEvent(direction);
        }
    }
}