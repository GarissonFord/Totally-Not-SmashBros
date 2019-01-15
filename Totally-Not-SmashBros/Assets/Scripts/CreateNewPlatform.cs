using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPlatform : MonoBehaviour
{
    public GameObject currentPlatform;
    public GameObject nextPlatform;

    private void Start()
    {
        currentPlatform = transform.parent.gameObject;
        nextPlatform = currentPlatform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fighter") || other.CompareTag("Player"))
        {
            Instantiate(nextPlatform, new Vector3(currentPlatform.transform.position.x + 30.0f,
                currentPlatform.transform.position.y, currentPlatform.transform.position.z), currentPlatform.transform.rotation);
            Destroy(gameObject);
        }
    }
}
