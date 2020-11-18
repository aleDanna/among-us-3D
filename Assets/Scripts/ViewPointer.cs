using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ViewPointer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!this.isLocalPlayer)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
