using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoDialogueBox : MonoBehaviour
{

    public Button yes, no;
    public Text textField;
    public Text nameField;
    private YesNoDialogueBox instance;

    public void setup()
    {
        Transform parent = GameObject.FindGameObjectWithTag("DialogueEntryCanvas").transform;
        this.instance = Instantiate(this, parent);
        this.instance.gameObject.SetActive(false);
    }

    public GameObject getInstance()
    {
        return instance.gameObject;
    }
    
    // Start is called before the first frame update
    public void show(string name, string text)
    {
        this.instance.nameField.text = name;
        this.instance.textField.text = text;
        this.instance.gameObject.SetActive(true);
    }

    public void onClick(Action<bool> callback)
    {
        instance.yes.onClick.AddListener(()=> {
            instance.yes.onClick.RemoveAllListeners();
            instance.no.onClick.RemoveAllListeners();
            callback(true);
        });

        instance.no.onClick.AddListener(() => {
            instance.yes.onClick.RemoveAllListeners();
            instance.no.onClick.RemoveAllListeners();
            callback(false);
        });
    }
}
