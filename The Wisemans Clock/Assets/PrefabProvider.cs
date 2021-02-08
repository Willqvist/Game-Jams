using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabProvider : MonoBehaviour
{
    public GameObject uiShower;

    public static PrefabProvider instance;

    private void Awake()
    {
        instance = this;
    }
}
