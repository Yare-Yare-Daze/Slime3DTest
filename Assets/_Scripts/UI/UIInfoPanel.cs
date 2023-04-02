using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageValueText;
    [SerializeField] private TextMeshProUGUI hpValueText;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private EntityHealth playerHP;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerAttack.OnDamageChanged += DamageChanged;
        playerHP.OnHealthChanged += HPChanged;
    }

    private void HPChanged(float hp)
    {
        hpValueText.text = hp.ToString();
    }

    private void DamageChanged(float damage)
    {
        damageValueText.text = damage.ToString();
    }
}
