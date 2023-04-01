using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamageable : MonoBehaviour
{
    [SerializeField] private EntityHealth entityHealth;
    [SerializeField] private Renderer rendererComp;

    private Color defaultColor;

    private void Awake()
    { 
        //renderer = GetComponent<Renderer>();
        defaultColor = rendererComp.material.color;
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.Log(nameof(damage) + "less then zero!");
            return;
        }

        Debug.Log("Damage: " + damage);
        var deltaHealth = entityHealth.Health - damage;
        entityHealth.Health = deltaHealth;
        Debug.Log(gameObject.name + "has been attacked! HP left: " + entityHealth.Health);
        StartCoroutine(ColorChange());
    }

    private IEnumerator ColorChange()
    {
        rendererComp.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rendererComp.material.color = defaultColor;
    }
}
