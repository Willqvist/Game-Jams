using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractorShower : MonoBehaviour
{

    public float radius;

    public char letter;

    public GameObject toShow;
    public Transform origin;

    private GameObject instance;

    private Transform parentCanvas;

    private Transform target;
    
    private Camera camera;
    private Text textField;
    private KeyCode keyCode;
    private bool inRange = false;
    private bool disabled = false;
    private bool destroyed = false;
    public UnityEvent<bool> onVisible = new UnityEvent<bool>();
    public UnityEvent onInteraction = new UnityEvent();

    public void addListener(UnityAction a)
    {
        if(onInteraction == null)
            onInteraction = new UnityEvent();
        
        onInteraction.AddListener(a);
    }
   
    

    // Start is called before the first frame update
    void Start()
    {
        this.parentCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas").transform;
        this.instance = Instantiate(toShow,this.parentCanvas);
        this.textField = instance.transform.Find("Text").gameObject.GetComponent<Text>();
        this.textField.text = letter+"";
        this.camera = Camera.main;
        this.target = PlayerSingleton.Instance.getGameObject().transform;
        this.keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), letter+"");
        this.instance.SetActive(false);

        SmoothSlider.OnSlide += OnSlide;
        BabyTransition.OnBabyTransition += OnBabySlide;
        Fader.onFading += OnFade;
    }

    void OnSlide(Timestamp stamp)
    {
        inRange = false;
        this.instance?.SetActive(false);
    }

    void OnBabySlide(bool to, GameObject prev)
    {
        OnSlide(null);
    }
    
    void OnFade()
    {
        OnSlide(null);
    }
    

    private bool checkInRange()
    {
        return Vector3.Distance(this.target.position, this.transform.position) <= radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled) return;
        if (!inRange && checkInRange())
        {
            inRange = true;
            this.instance.SetActive(true);
            onVisible.Invoke(true);
        }
        else if (inRange && !checkInRange())
        {
            inRange = false;
            this.instance.SetActive(false);
            onVisible.Invoke(false);
        }

        if (inRange)
        {
            Vector3 pos = this.camera.WorldToScreenPoint(this.origin.position);
            this.instance.transform.position = pos;
        }

        if (Input.GetKeyDown(keyCode) && inRange)
        {
            onInteraction.Invoke();
        }
    }

    private void OnDestroy()
    {
        Destroy(this.instance);
        SmoothSlider.OnSlide -= OnSlide;
        BabyTransition.OnBabyTransition -= OnBabySlide;
        Fader.onFading -= OnFade;
    }

    public void disable()
    {
        disabled = true;
        this.instance.SetActive(false);
    }
}
