
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestHelper : MonoBehaviour
{
    private static QuestHelper instance;

    private void Start()
    {
        instance = this;
    }

    public static QuestHelper Instance => instance;

    public void SetText(string text)
    {
        this.GetComponent<TextMeshProUGUI>().text = text;
    }
}
