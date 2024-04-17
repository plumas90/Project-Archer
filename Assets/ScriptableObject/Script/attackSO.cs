using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName ="DefaultAttackData",menuName ="TopDownController/Attacks/Default",order =0)]
public class AttackSO : ScriptableObject
{
    [Header("ATTACK INFO")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("KNOCK BACK INFO")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
