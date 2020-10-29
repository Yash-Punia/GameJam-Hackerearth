using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterance_crusher : MonoBehaviour
{
    public GameObject garbage;
    public GameObject pos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="garbage")
        {
            Destroy(other.gameObject);
            Invoke("instantiate", 2);
        }
    }
    void instantiate()
    {
        Instantiate(garbage, pos.transform.position, Quaternion.identity);
        //garbage.GetComponent<move>().addforce();
    }
}
