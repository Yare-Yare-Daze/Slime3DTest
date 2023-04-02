using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerAttack playerAttack;

    private void Update()
    {
        if(!playerAttack.IsAttack)
        {
            Vector3 targetPos = Vector3.right * speed * Time.deltaTime;
            transform.Translate(targetPos);
        }
    }
}
