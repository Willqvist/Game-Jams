using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawnLocationUncleJoeQuest : MonoBehaviour
{
    private static SawSpawnLocationUncleJoeQuest instance;
    public static SawSpawnLocationUncleJoeQuest Instance => instance;

    private void Start()
    {
        instance = this;
    }
}
