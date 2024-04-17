
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private Topdown _controller;

    [SerializeField]private Transform projectileSpawnPositon;
    private Vector2 _aimDirection = Vector2.right; //기존값쓰기

    public AudioClip shootingClip;


    private void Awake()
    {
        _controller = GetComponent<Topdown>();
    }
    void Start()
    {
        _projectileManager = ProjectileManager.Instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAim)
    {
        _aimDirection= newAim;
    }

    private void OnShoot(AttackSO AttackSO)
    {
        RangedAttackData rangedAttackData = AttackSO as RangedAttackData;
        float projectilesAngelSpace = rangedAttackData.multipleProjectilesAngel;
        int numberofProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberofProjectilesPerShot / 2f) * projectilesAngelSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;

        for (int i = 0; i < numberofProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngelSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectTile(rangedAttackData,angle);
        }
        
    }

    private void CreateProjectTile(RangedAttackData rangedAttackData, float angle)
    {
            _projectileManager.shootBullet(
            projectileSpawnPositon.position,
            RotateVector2(_aimDirection,angle),
            rangedAttackData
            );

        if (shootingClip)
            SoundManager.PlayClip(shootingClip);


    }
    private static Vector2 RotateVector2(Vector2 v, float degree) 
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }


}
