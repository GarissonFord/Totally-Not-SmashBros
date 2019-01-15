using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float knockback;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fighter"))
        {
            EnemyController ec = other.GetComponent<EnemyController>();
            other.attachedRigidbody.AddRelativeForce(-transform.forward * ec.hitPoints * knockback);
            other.SendMessageUpwards("TakeDamage", damage);
        }
    }
}
