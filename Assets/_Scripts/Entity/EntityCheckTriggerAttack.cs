using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCheckTriggerAttack : MonoBehaviour
{
    public Action<Collider> OnPlayerDetected;
    public Action<Collider> OnEnemyDetected;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name +  " triggered");
        if (other.gameObject.CompareTag(Strings.Player))
        {
            Debug.Log("Player detected");
            OnPlayerDetected?.Invoke(other);
        }

        if(other.gameObject.CompareTag(Strings.Enemy))
        {
            Debug.Log("Enemy detected");
            OnEnemyDetected?.Invoke(other);
        }
    }
}
