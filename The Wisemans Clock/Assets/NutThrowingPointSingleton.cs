using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutThrowingPointSingleton : MonoBehaviour
{
    private static NutThrowingPointSingleton instance;
    public static NutThrowingPointSingleton Instance => instance;
    void Start()
    {
        instance = this;
    }
}
