using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckTriggerAttack : MonoBehaviour
{
    public Action<Collider> OnPlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Strings.Player))
        {
            OnPlayerDetected?.Invoke(other);
        }
    }
}
