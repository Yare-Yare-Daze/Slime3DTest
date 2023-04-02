using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    [SerializeField] private EntityHealth entityHealth;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        healthText.text = $"{entityHealth.Health}/{entityHealth.MaxHealth}";
        entityHealth.OnHealthChanged += ChangeHealthBar;
        entityHealth.OnMaxHealthChanged += ChangeMaxHealthBar;
    }

    private void ChangeHealthBar(float health)
    {
        var healthScale = healthBar.localScale;
        healthScale.x = health / 100;
        healthBar.localScale = healthScale;
        healthText.text = $"{health}/{entityHealth.MaxHealth}";
    }

    private void ChangeMaxHealthBar(float health, float maxhealth)
    {
        var healthScale = healthBar.localScale;
        healthScale.x = health / 100;
        healthBar.localScale = healthScale;
        healthText.text = $"{health}/{maxhealth}";
    }

}

