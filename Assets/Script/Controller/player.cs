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


    public void OnMove(InputValue value) // send 메시지 방식 함수 실행시 앞에 On을 붙이면 뒷내용실행시 on이
    {                                   // 무브는 키보드 상하좌우를 받고 있음 상하좌우 입력시 안에거 실행됨
        Vector2 moveInput = value.Get<Vector2>().normalized; // 노말라이즈 가로세로 1 일시 대각선은 루트2 값이 나옴 즉 대각선이동이 직선이동보다 빠름 이값 처리
        //옵저버패턴구독
        CallMoveEvent(moveInput);
        //Debug.Log("OnMove" + value.ToString());
    }
    public void OnLook(InputValue value)
    {
        // 마우스는 스크린에서 사용하기 때문에 스크린 좌표로 들어오는데 게임에 적용하기 위해선 월드 좌표로 바꿔줘야한다
        Vector2 newAim = value.Get<Vector2>();// 현재 마우스 위치 받기
        Vector2 wolrdPos = _camera.ScreenToWorldPoint(newAim);//월드좌표로 변환
        // 마우스값 - 내 현재 벡터 = 현재 -> 마우스 를 바라보는 벡터값 노말라이즈 위처럼 1값으로 맞춰줌
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