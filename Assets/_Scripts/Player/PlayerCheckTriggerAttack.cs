using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckTriggerAttack : MonoBehaviour
{
    public Action<Collider> OnEnemyDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Strings.Enemy))
        {
            OnEnemyDetected?.Invoke(other);
        }
    }
}
