using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyScene : MonoBehaviour
{
    private static BabyScene instance;
    public static BabyScene Instance => instance;

    public GameObject location;

    private void Awake()
    {
        instance = this;
    }
}
