using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestampSingleton
{
    private static TimestampSingleton instance = new TimestampSingleton();

    public int currentTime;

    public static TimestampSingleton Instance => instance;
}
