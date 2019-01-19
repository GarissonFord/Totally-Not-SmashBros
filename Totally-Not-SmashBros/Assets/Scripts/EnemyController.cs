using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float hitPoints;
    public Text hitPointsText;

    public CreateNewPlatform parent;

    private void Start()
    {
        UpdateHitPoints();
        parent = transform.parent.GetComponent<CreateNewPlatform>();
    }

    public void TakeDamage(float damage)
    {
        hitPoints += damage;
        UpdateHitPoints();
    }

    void UpdateHitPoints()
    {
        hitPointsText.text = hitPoints.ToString() + "%";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
            parent.spawnPlatform();
    }
}
