using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityDamageable : MonoBehaviour
{
    [SerializeField] private EntityHealth entityHealth;
    [SerializeField] private Renderer rendererComp;
    [SerializeField] private TextMeshProUGUI takenDamageText;
    [SerializeField] private float timeShowTakenDamage = 2f;

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
        StartCoroutine(TakenDamageText(damage));
    }

    private IEnumerator ColorChange()
    {
        rendererComp.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rendererComp.material.color = defaultColor;
    }

    private IEnumerator TakenDamageText(float damage)
    {
        Color colorDamage = takenDamageText.color;
        colorDamage.a = 255f;
        takenDamageText.color = colorDamage;
        float time = 0f;
        takenDamageText.text = "-" + damage.ToString();

        while(colorDamage.a != 0)
        {
            colorDamage.a = Mathf.Lerp(colorDamage.a, 0f, time / timeShowTakenDamage);
            takenDamageText.color = colorDamage;
            time += Time.deltaTime;
            yield return null;
        }
    }
}
