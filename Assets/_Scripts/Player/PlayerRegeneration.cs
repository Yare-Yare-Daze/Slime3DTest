using System.Collections;
using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    [SerializeField] private float hpPerSecond;
    [SerializeField] private EntityHealth entityHealth;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        StartCoroutine(RegenerationPerSercon());
    }

    private IEnumerator RegenerationPerSercon()
    {
        while(gameObject.activeSelf)
        {
            entityHealth.Health += hpPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

}
