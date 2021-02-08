using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkorreHouseFadeEnabler : MonoBehaviour
{
    public GameObject disable,enable;

    public Transform teleportTo;

    private bool alreadyEnab = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fade(Fader.onFade fadeCallback)
    {
        PlayerSingleton.Instance.occupied = true;
        Fader.Instance().fadeIn(4, () =>
        {
            disable.SetActive(false);
            enable.SetActive(true);
            PlayerSingleton.Instance.gameObjectInstance.ChangePosition(teleportTo.position);
            PlayerSingleton.Instance.occupied = false;
            Fader.Instance().fadeOut(4, () =>
            {
                if (PlayerSingleton.Instance.hasTalkedToNukeNote && !alreadyEnab)
                {
                    alreadyEnab = true;
                    SmoothSlider.Instance.EnableTimestamp(3);
                }

                fadeCallback?.Invoke();
            });
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        fade(null);
    }
}
