using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterance_crusher : MonoBehaviour
{
    public int element_number;
    public List<GameObject> crushedobject;
    public GameObject pos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="garbage")
        {
            Destroy(other.gameObject);
            FindObjectOfType<TutorialScreenManager>().ShowNextUI();
            Invoke("instantiate", 2);
        }
    }
    void instantiate()
    {
        element_number = UnityEngine.Random.Range(1, 6);
        elements_product(element_number);
    }
    private void elements_product(int element)
    {
        switch (element)
        {
            case 1:
                Debug.Log("Iron");
                GameObject obj= Instantiate(crushedobject[element_number - 1], pos.transform.position, Quaternion.identity);
                obj.GetComponent<extractor>().element_number = element_number;
                break;
            case 2:
                Debug.Log("Aluminium");
                GameObject objj=Instantiate(crushedobject[element_number - 1], pos.transform.position, Quaternion.identity);
                objj.GetComponent<extractor>().element_number = element_number;
                break;
            case 3:
                Debug.Log("Plastic");
                GameObject obje = Instantiate(crushedobject[element_number - 1], pos.transform.position, Quaternion.identity);
                obje.GetComponent<extractor>().element_number = element_number;
                break;
            case 4:
                Debug.Log("Silicon");
                GameObject objec = Instantiate(crushedobject[element_number - 1], pos.transform.position, Quaternion.identity);
                objec.GetComponent<extractor>().element_number = element_number;
                break;
            case 5:
                Debug.Log("wood");
                GameObject objr = Instantiate(crushedobject[element_number - 1], pos.transform.position, Quaternion.identity);
                objr.GetComponent<extractor>().element_number = element_number;
                break;
        }

    }
}
