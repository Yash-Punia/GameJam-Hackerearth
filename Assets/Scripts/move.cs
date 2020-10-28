using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody m_rigid;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.AddForce(new Vector3(1, 0, 0) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
