using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : EntityAttack
{
    [SerializeField] private PlayerCheckTriggerAttack playerTriggerAttack;
    [SerializeField] private Transform projectile;

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
        if (!isAttack && enemyDamageablesQueue.Count > 0)
        {
            EntityDamageable enemyDamageable = enemyDamageablesQueue.Dequeue();
            currentEnemyDeath = enemyDamageable.gameObject.GetComponent<EntityDeath>();
            PerformAttack(enemyDamageable);

            isAttack = true;
            currentEnemyDeath.OnEntityDeath += ResetIsAttack;
            StartCoroutine(ThrowProjectileToEnemy(enemyDamageable.transform));
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

    private IEnumerator ThrowProjectileToEnemy(Transform enemyTransform)
    {
        projectile.gameObject.SetActive(true);
        

        while(isAttack)
        {
            float time = 0f;
            while (time < AttackInterval)
            {
                Vector3 point0 = transform.position;
                Vector3 point2 = enemyTransform.position;
                Vector3 point1 = point0 + (point2 - point0) / 2 + Vector3.up * 5.0f;
                Vector3 m1 = Vector3.Lerp(point0, point1, time);
                Vector3 m2 = Vector3.Lerp(point1, point2, time);
                projectile.position = Vector3.Lerp(m1, m2, time);
                time += Time.deltaTime;
                yield return null;
            }
        }
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        playerTriggerAttack.OnEnemyDetected -= OnEnemyDetectedHandler;
    }
}
