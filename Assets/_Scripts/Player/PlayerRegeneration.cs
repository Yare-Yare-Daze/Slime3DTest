using System.Collections;
using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    [SerializeField] private float hpPerSecond;
    [SerializeField] private EntityHealth entityHealth;

    private float _hpPerSecond;

    public float HPPerSecond
    {
        get
        {
            return _hpPerSecond;
        }
        set
        {
            _hpPerSecond = Mathf.Clamp(value, 0f, float.MaxValue);
        }
    }

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
            entityHealth.Health += HPPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

}
