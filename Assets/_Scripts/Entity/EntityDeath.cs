using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeath : MonoBehaviour
{
    [SerializeField] private EntityHealth entityHealth;

    public Action OnEntityDeath;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        entityHealth.OnHealthChanged += CheckEntityDeath;
    }

    private void CheckEntityDeath(float health)
    {
        if(health == 0)
        {
            OnEntityDeath?.Invoke();
            EntityDied();
        }
    }

    protected virtual void EntityDied()
    {
        Destroy(gameObject);
    }
}
