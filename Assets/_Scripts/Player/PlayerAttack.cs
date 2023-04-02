using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EntityAttack
{
    [SerializeField] private PlayerCheckTriggerAttack playerTriggerAttack;

    private bool isAttack = false;
    private Queue<EntityDamageable> enemyDamageablesQueue = new Queue<EntityDamageable>();

    private EntityDeath currentEnemyDeath;

    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        playerTriggerAttack.OnEnemyDetected += OnEnemyDetectedHandler;
    }

    private void Update()
    {
        if(!isAttack && enemyDamageablesQueue.Count > 0)
        {
            EntityDamageable enemyDamageable = enemyDamageablesQueue.Dequeue();
            currentEnemyDeath = enemyDamageable.gameObject.GetComponent<EntityDeath>();
            PerformAttack(enemyDamageable);

            isAttack = true;
            currentEnemyDeath.OnEntityDeath += ResetIsAttack;
        }
    }

    private void ResetIsAttack()
    {
        currentEnemyDeath.OnEntityDeath -= ResetIsAttack;
        isAttack = false;
    }

    private void OnEnemyDetectedHandler(Queue<Collider> enemyCollidersQueue)
    {
        EntityDamageable enemyDamageable = enemyCollidersQueue.Dequeue().transform.parent.GetComponent<EntityDamageable>();
        enemyDamageablesQueue.Enqueue(enemyDamageable);
    }

    private void OnDestroy()
    {
        playerTriggerAttack.OnEnemyDetected -= OnEnemyDetectedHandler;
    }
}
