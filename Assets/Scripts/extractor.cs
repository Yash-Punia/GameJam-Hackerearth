﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class extractor : MonoBehaviour
{
    public int element_number;
    public GameObject element;
    public GameObject pos;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("extractor"))
        {
            element_number = UnityEngine.Random.Range(1, 5);
            elements_product(element_number);
        }
        if(other.gameObject.CompareTag("elementgenerator"))
        {
            Invoke("instantiate", 2);
        }
    }
    void instantiate()
    {
        GameObject obj = Instantiate(element, pos.transform.position, Quaternion.identity);
        obj.GetComponent<element_>().element_number = element_number;
        Destroy(gameObject);
    }
    private void elements_product(int element)
    {
        switch (element)
        {
            case 1:
                Debug.Log("Iron");
                GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                break;
            case 2:
                Debug.Log("Aluminium");
                GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.2f);
                break;
            case 3:
                Debug.Log("Plastic");
                GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                break;
            case 4:
                Debug.Log("Silicon");
                GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
                break;
            case 5:
                Debug.Log("wood");
                GetComponent<MeshRenderer>().material.color = new Color(0, 0.5f, 0.5f);
                break;
        }

    }
}
