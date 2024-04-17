using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapperOnDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.currentRoomClearPoint -= 1;

        //_rigidbody.velocity = Vector3.zero;

        //foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        //{
        //    Color color = renderer.color;
        //    color.a = 0.3f;
        //    renderer.color = color;
        //}

        //foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        //{
        //    component.enabled = false;
        //}

        //Destroy(gameObject, 2f);
    }
}