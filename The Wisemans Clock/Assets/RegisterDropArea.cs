using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterDropArea : MonoBehaviour
{

    public string name;
    
    // Start is called before the first frame update
    void Start()
    {
        DropHelper.registerDropArea(name,this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
