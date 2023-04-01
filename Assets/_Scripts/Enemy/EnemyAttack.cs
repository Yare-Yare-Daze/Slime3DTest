using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EntityAttack
{
    [SerializeField] private EnemyCheckTriggerAttack enemyTriggerAttack;

    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        enemyTriggerAttack.OnPlayerDetected += OnPlayerDetectedHandler;
    }

    private void OnPlayerDetectedHandler(Collider playerCollider)
    {
        EntityDamageable playerDamageable = playerCollider.transform.parent.GetComponent<EntityDamageable>();
        PerformAttack(playerDamageable);
    }

    private void OnDisable()
    {
        enemyTriggerAttack.OnPlayerDetected -= OnPlayerDetectedHandler;
    }
}
