using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private float startHealth = 100;
    public Action<float> OnHealthChanged;
    public Action<float, float> OnMaxHealthChanged;
    
    private float _health;
    private float _maxHealth;

    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            OnHealthChanged?.Invoke(_health);
        }
    }

    public float MaxHealth 
    { 
        get { return _maxHealth; } 
        set
        {
            _maxHealth = Mathf.Clamp(value, 0, int.MaxValue);
            OnMaxHealthChanged?.Invoke(Health, _maxHealth);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _maxHealth = startHealth;
        Health = _maxHealth;
    }
}
