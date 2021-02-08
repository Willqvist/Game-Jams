using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static bool IsBridgeBroken { get; set; }
    public static bool ShouldCollectSquirrelForUncleJoe { get; set; }
    public static bool BrokeSquirrleDam { get; set; }
    
    public static bool HasSolvedSecretChest { get; set; }
    public static bool HelpStefan { get; set; }
    public static string KeyCode => "4562";

    public static string safeKeyCode => "3810";


}
