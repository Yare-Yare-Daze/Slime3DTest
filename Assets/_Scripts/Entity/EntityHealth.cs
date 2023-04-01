using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private float startHealth = 100;
    public Action<float> OnHealthChanged;
    
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
