using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnHelper : MonoBehaviour
{
    private static ObjectSpawnHelper instance;

    public static ObjectSpawnHelper Instance => instance;

    public GameObject saw;
    public GameObject squirrle;

    void Start()
    {
        instance = this;
    }
}
