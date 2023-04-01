using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] private float damageValue;
    [SerializeField] private float attackInterval;

    public Action<float> OnDamageChanged;

    private float _damage;

    public float Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = Mathf.Clamp(value, 0, float.MaxValue);
            OnDamageChanged?.Invoke(_damage);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        Damage = damageValue;
    }

    protected virtual void PerformAttack(EntityDamageable entityDamageable)
    {
        StartCoroutine(AttackCoroutine(entityDamageable));
    }

    private IEnumerator AttackCoroutine(EntityDamageable entityDamageable)
    {
        while(gameObject.activeSelf && entityDamageable.gameObject.activeSelf)
        {
            entityDamageable.ApplyDamage(Damage);
            yield return new WaitForSeconds(attackInterval);
        }
    }
}
