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
            other.attachedRigidbody.AddRelativeForce(-transform.forward * damage * knockback);
            //other.SendMessageUpwards("TakeDamage", damage);
        }
    }
}
