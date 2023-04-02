using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EnemyCheckTriggerAttack enemyCheckTriggerAttack;

    private bool isPlayerDetected = false;

    private void Awake()
    {
        enemyCheckTriggerAttack.OnPlayerDetected += PlayerDetected;
    }

    private void PlayerDetected(Collider playerCollider)
    {
        isPlayerDetected = true;
    }

    private void Update()
    {
        if(!isPlayerDetected)
        {
            Vector3 targetPos = Vector3.left * speed * Time.deltaTime;
            transform.Translate(targetPos);
        }
    }
}
