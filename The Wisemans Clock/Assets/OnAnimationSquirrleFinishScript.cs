using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationSquirrleFinishScript : MonoBehaviour
{
    public GameObject squirrleToReplaceMe;

    public void OnAnimationFinish()
    {
        var instance = DropHelper.Drop(this.squirrleToReplaceMe);
        instance.transform.position = this.transform.position;
        instance.transform.rotation = this.transform.rotation;
        PlayerSingleton.Instance.occupied = false;
        Destroy(this.gameObject);
    }
}
