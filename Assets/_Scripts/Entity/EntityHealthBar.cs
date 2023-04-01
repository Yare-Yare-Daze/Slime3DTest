using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    [SerializeField] private EntityHealth entityHealth;
    [SerializeField] private RectTransform healthBar;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        entityHealth.OnHealthChanged += ChangeHealthBar;
    }

    private void ChangeHealthBar(float health)
    {
        var healthScale = healthBar.localScale;
        healthScale.x = health / 100;
        healthBar.localScale = healthScale;
    }

}

