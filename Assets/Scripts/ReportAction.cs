using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReportAction : MonoBehaviour {
    public Button reportButton;

    void Start () {
        reportButton = this.GetComponent<Button>();
        reportButton.onClick.AddListener(delegate () { this.TaskOnClick(); });
    }

    void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
    }
}