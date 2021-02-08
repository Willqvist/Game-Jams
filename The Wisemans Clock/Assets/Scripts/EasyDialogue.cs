using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDialogue : MonoBehaviour
{

    public Dialogue dialogue;
    public float radius = 1;
    public string name;
    public Transform origin;
    private InteractorShower shower;
    
    // Start is called before the first frame update
    void Start()
    {
        var npcDialogue = this.gameObject.AddComponent<NpcDialogue>();
        npcDialogue.manager = this.gameObject.AddComponent<DialogueManager>();
        npcDialogue.manager.entry = dialogue;
        npcDialogue.rotationSpeed = 0;
        npcDialogue.name = name;
        shower = this.gameObject.AddComponent<InteractorShower>();
        shower.radius = radius;
        shower.origin = origin != null ? origin : this.transform;
        shower.letter = 'E';
        shower.toShow = PrefabProvider.instance.uiShower;
        shower.addListener(npcDialogue.onDialogueBegin);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disable()
    {
        shower.disable();
        this.gameObject.SetActive(false);
    }
}
