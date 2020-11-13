using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMap : MonoBehaviour {
    // Start is called before the first frame update

    private GameObject camera;
    private bool hide;
    void Start()
    {
        this.hide = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Map") == true) {
            hide = !hide;
        }
        this.gameObject.transform.Find("minimap").gameObject.SetActive(!hide);
    }
}
