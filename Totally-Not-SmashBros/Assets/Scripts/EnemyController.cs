using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float hitPoints;
    public Text hitPointsText;

    private void Start()
    {
        UpdateHitPoints();
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
}
