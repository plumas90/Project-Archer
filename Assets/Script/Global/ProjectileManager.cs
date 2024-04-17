using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticelSystem;

    private ObjectPool objectpool;
    public static ProjectileManager Instance;

    public void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        objectpool=GetComponent<ObjectPool>();
    }

    public void shootBullet(Vector2 startPositon,Vector2 direction,RangedAttackData attackData) 
    {
       
        GameObject obj= objectpool.SpawnFromPool(attackData.bulletNameTag);
        obj.transform.position = startPositon;
        RangedController attackController = obj.GetComponent<RangedController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

    public void CreateImpactParticleAtPosition(Vector3 positon, RangedAttackData attackData) 
    {
        _impactParticelSystem.transform.position = positon;
        ParticleSystem.EmissionModule em = _impactParticelSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));
        ParticleSystem.MainModule mainModule = _impactParticelSystem.main;
        mainModule.startSpeedMultiplier = attackData.size * 10f;
        _impactParticelSystem.Play();
    }
}
