using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkorrSpawnlocationUncleJoeQuest : MonoBehaviour
{
    private static EkorrSpawnlocationUncleJoeQuest instance;
    public static EkorrSpawnlocationUncleJoeQuest Instance => instance;

    private void Start()
    {
        instance = this;
    }
}
