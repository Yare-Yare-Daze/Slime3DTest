using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EntityAttack
{
    [SerializeField] private PlayerCheckTriggerAttack playerTriggerAttack;

    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        playerTriggerAttack.OnEnemyDetected += OnEnemyDetectedHandler;
    }

    private void OnEnemyDetectedHandler(Collider enemyCollider)
    {
        Debug.Log(gameObject.name + " OnEnemyDetectedHandler invoked");
        EntityDamageable enemyDamageable = enemyCollider.transform.parent.GetComponent<EntityDamageable>();
        PerformAttack(enemyDamageable);
    }

    private void OnDestroy()
    {
        playerTriggerAttack.OnEnemyDetected -= OnEnemyDetectedHandler;
    }
}
