using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class production : MonoBehaviour
{
    int element_num;
    GameObject elements;
    public GameObject Task_Manager;
    public Transform pos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "element")
        {
            elements = other.gameObject;
            element_num = other.gameObject.GetComponent<element_>().element_number;
            Task_Manager.GetComponent<TaskManager>().change_number(element_num);
        }
    }


    public void wrong()
    {
        elements.GetComponent<move_element>().speed = 800;
        Instantiate(elements, pos.position, Quaternion.identity);
    }
}
