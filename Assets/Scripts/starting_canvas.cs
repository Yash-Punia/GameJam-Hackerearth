using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class starting_canvas : MonoBehaviour
{
    public TextMeshProUGUI task;
    public GameObject startingcanvas;
    public GameObject slider;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        turnon();
    }
    public void turnon()
    {
        int count = FindObjectOfType<TaskManager>().Count;
        Debug.Log(count);
        task.text = FindObjectOfType<TaskManager>().Tasks[count];
        slider.SetActive(false);
        Invoke("TurnOff", 2);
    }
    void TurnOff()
    {
        startingcanvas.SetActive(false);
        slider.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
