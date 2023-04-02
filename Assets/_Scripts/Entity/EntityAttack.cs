using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] private float damageValue;
    [SerializeField] private float attackInterval;

    public Action<float> OnDamageChanged;
    public Action<float> OnAttackIntervalChanged;

    private float _damage;
    private float _attackInterval;

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

    public float AttackInterval
    {
        get
        {
            return _attackInterval;
        }
        set
        {
            _attackInterval = Mathf.Clamp(value, 0, float.MaxValue);
            OnAttackIntervalChanged?.Invoke(_attackInterval);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        Damage = damageValue;
        AttackInterval = attackInterval;
    }

    protected virtual void PerformAttack(EntityDamageable entityDamageable)
    {
        StartCoroutine(AttackCoroutine(entityDamageable));
    }

    private IEnumerator AttackCoroutine(EntityDamageable entityDamageable)
    {
        while(gameObject.activeSelf && entityDamageable.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(AttackInterval);
            entityDamageable.ApplyDamage(Damage);
        }
    }
}
