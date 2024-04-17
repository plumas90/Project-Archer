using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterrenderer;

    private Topdown _controller;
    private void Awake()
    {
        _controller = GetComponent<Topdown>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //���콺 �����϶� �� ������ ����
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection) 
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 Direction) 
    {
        float rotZ=MathF.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg; //���� ����

        armRenderer.flipY =MathF.Abs(rotZ)>90f;
        characterrenderer.flipX=armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0,0,rotZ);

    }
}
