using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class element_ : MonoBehaviour
{
    //public GameObject crushed_obj;
    public int element_number;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("extractor"))
        {
            elements_product(element_number);
        }
        if (other.gameObject.tag == "production")
        {
            Destroy(gameObject);
        }
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
