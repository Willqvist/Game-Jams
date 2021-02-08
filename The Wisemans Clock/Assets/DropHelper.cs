using System;
using UnityEngine;
using System.Collections.Generic;

public class DropHelper : MonoBehaviour
{
    private static Dictionary<String, GameObject> objs = new Dictionary<String, GameObject>();

    public GameObject[] houses;
    private static GameObject[] sHouses = new GameObject[1];

    private void Awake()
    {
        sHouses = houses;
    }

    public static void registerDropArea(string name, GameObject obj)
    {
        objs[name] = obj;
    }

    public static GameObject Drop(GameObject obj)
    {
        GameObject activeHouse = null;
        foreach (var house in sHouses)
        {
            if (house.activeSelf) { activeHouse = house;
                break;
            }
        }

        Transform parent;
        if (activeHouse == null)
        {
            Timestamp stamp = SmoothSlider.Instance.getCurrentTimestamp();
            parent = objs[stamp.timestamp].transform;
        }
        else
        {
            parent = activeHouse.transform;
        }

        return Instantiate(obj, parent);
    }

    public static GameObject getTimestampObject(Timestamp t)
    {
        return objs[t.timestamp];
    }
}
