using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tem : MonoBehaviour
{
    public ItemData one;
    public ItemData two;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerSingleton.Instance.CurrentEquippedItem = one;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayerSingleton.Instance.CurrentEquippedItem = two;
        }
    }
}
