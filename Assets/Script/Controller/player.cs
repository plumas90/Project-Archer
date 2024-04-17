using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Topdown
{
    private Camera _camera;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }


    public void OnMove(InputValue value) // send �޽��� ��� �Լ� ����� �տ� On�� ���̸� �޳������� on��
    {                                   // ����� Ű���� �����¿츦 �ް� ���� �����¿� �Է½� �ȿ��� �����
        Vector2 moveInput = value.Get<Vector2>().normalized; // �븻������ ���μ��� 1 �Ͻ� �밢���� ��Ʈ2 ���� ���� �� �밢���̵��� �����̵����� ���� �̰� ó��
        //���������ϱ���
        CallMoveEvent(moveInput);
        //Debug.Log("OnMove" + value.ToString());
    }
    public void OnLook(InputValue value)
    {
        // ���콺�� ��ũ������ ����ϱ� ������ ��ũ�� ��ǥ�� �����µ� ���ӿ� �����ϱ� ���ؼ� ���� ��ǥ�� �ٲ�����Ѵ�
        Vector2 newAim = value.Get<Vector2>();// ���� ���콺 ��ġ �ޱ�
        Vector2 wolrdPos = _camera.ScreenToWorldPoint(newAim);//������ǥ�� ��ȯ
        // ���콺�� - �� ���� ���� = ���� -> ���콺 �� �ٶ󺸴� ���Ͱ� �븻������ ��ó�� 1������ ������
        newAim = (wolrdPos - (Vector2)transform.position).normalized;
        //Debug.Log("OnLook" + value.ToString());

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }

    }
    public void OnFire(InputValue value)
    {
         IsAttacking = value.isPressed;

    }

}