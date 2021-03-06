﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fighter") || other.CompareTag("Player"))
            Destroy(other.gameObject);
    }
}
