using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasActions : MonoBehaviour {
	
	private bool showMap;
    private GameObject miniMap;
    private GameObject reportButton;
    void Start()
    {
	    this.miniMap = this.gameObject.transform.Find("Minimap").gameObject;
	    this.reportButton = this.gameObject.transform.Find("ReportButton").gameObject;
        this.showMap = false;
        GameObject reportButtonInstance = (GameObject)Instantiate(this.reportButton);
        reportButtonInstance.GetComponent<Button>().onClick.AddListener(() => { this.OnReportButtonClicked(); });
    }

    // Update is called once per frame
    void Update() {
		mapCheck();
    }

	void mapCheck() {
		if (Input.GetButtonDown("Map") == true) {
			showMap = !showMap;
        }
		miniMap.SetActive(showMap);
	}

	void OnReportButtonClicked()
	{
		Debug.unityLogger.Log("You have clicked the button!");
	}
}
