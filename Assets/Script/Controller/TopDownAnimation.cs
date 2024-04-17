using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimation : MonoBehaviour
{
    protected Animator animator;
    protected Topdown controller;//이부분 잘못가져왔을수도

    protected virtual void Awake() 
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<Topdown>();
    }
}
