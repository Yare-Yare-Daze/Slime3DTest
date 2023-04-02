using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayerCheckTriggerAttack : MonoBehaviour
{
    private Queue<Collider> enemyCollidersQueue = new Queue<Collider>();

    public Action<Queue<Collider>> OnEnemyDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Strings.Enemy))
        {
            enemyCollidersQueue.Enqueue(other);
            OnEnemyDetected?.Invoke(enemyCollidersQueue);
        }
    }
}
