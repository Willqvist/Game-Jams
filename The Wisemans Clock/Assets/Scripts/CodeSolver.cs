using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeSolver : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;
    public GameObject window;
    public NpcDialogue safeDialogue;
    public AudioSource enteringKeyCode, wrong, correct;

    
    private TextMeshProUGUI textM;
    private TextMeshProUGUI textTtile;
    private bool isOn;

    private void Start()
    {
        textM = this.text.GetComponent<TextMeshProUGUI>();
        textTtile = this.text2.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if(!isOn)
        {
            return;
        }

        int a = 0;
        if(int.TryParse(textM.text, out a))
        {
            if(a == int.Parse(GlobalVariables.safeKeyCode))
            {
                correct.Play();
                this.isOn = false;
                GameObject.FindGameObjectWithTag("SafeCodeDialogue").gameObject.SetActive(false);
                PlayerSingleton.Instance.hasSolvedSafe = true;
                safeDialogue.onDialogueBegin();
                return;
            }
        }

        if(textM.text.Equals(GlobalVariables.safeKeyCode))
        {
            correct.Play();
            this.isOn = false;
            GameObject.FindGameObjectWithTag("SafeCodeDialogue").gameObject.SetActive(false);
            PlayerSingleton.Instance.hasSolvedSafe = true;
            safeDialogue.onDialogueBegin();
            return;
        }

        if (PlayerSingleton.Instance.gameObjectInstance.GetComponent<PlayerMovement>().wew.magnitude > 0.1f)
        {
            textTtile.text = "Correct";
            this.isOn = false;
            text.SetActive(false);
            text2.SetActive(false);
            window.SetActive(false);
            this.text.GetComponent<TextMeshProUGUI>().text = "";
            textTtile.text = "Insert code";
            return;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            textM.text = textM.text.Substring(0, textM.text.Length - 1);
        }

        if (textM.text.Length >= 4)
        {
            wrong.Play();
            textTtile.text = "Wrong Code";
            textM.text = "";
            return;
        }
        
        int length = textM.text.Length;
        
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            textM.text += "0";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            textM.text += "1";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            textM.text += "2";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            textM.text += "3";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            textM.text += "4";
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            textM.text += "5";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            textM.text += "6";
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            textM.text += "7";
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            textM.text += "8";
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            textM.text += "9";
        }

        if (textM.text.Length != length)
        {
            textTtile.text = "Insert code";
            enteringKeyCode.Play();
        }
    }

    public void OnActivate()
    {
        this.isOn = true;
        text.SetActive(true);
        text2.SetActive(true);
        window.SetActive(true);
        textTtile.text = "Insert code";
        textM.text = "";

    }
}
