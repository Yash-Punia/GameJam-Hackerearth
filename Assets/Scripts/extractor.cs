using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class extractor : MonoBehaviour
{
    public int element_number;
    public List<GameObject> element;
    public GameObject pos;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("elementgenerator"))
        {
            Invoke("elementsproduct", 2);
        }
    }
    void instantiate()
    {
        GameObject obj = Instantiate(element[element_number - 1], pos.transform.position, Quaternion.identity);
        obj.GetComponent<element_>().element_number = element_number;
        Destroy(gameObject);
    }
    void elementsproduct()
    {
        elements_product(element_number);
    }
    private void elements_product(int element)
    {
        switch (element)
        {
            case 1:
                Debug.Log("Iron");
                instantiate();
                break;
            case 2:
                Debug.Log("Aluminium");
                instantiate();
                break;
            case 3:
                Debug.Log("Plastic");
                instantiate();
                break;
            case 4:
                Debug.Log("Silicon");
                instantiate();
                break;
            case 5:
                Debug.Log("wood");
                instantiate();
                break;
        }
    }
}
