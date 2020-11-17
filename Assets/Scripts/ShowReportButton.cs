using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowReportButton : MonoBehaviour
{
    private GameObject reportButton;
    void Start()
    {
        reportButton = gameObject.transform.Find("PlayerCanvas")
            .gameObject.transform.Find("ReportButton").gameObject;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        reportButton.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        reportButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
