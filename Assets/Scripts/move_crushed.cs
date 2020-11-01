using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_crushed : MonoBehaviour
{
    Rigidbody m_rigid;
    public float speed = 800f;
    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.AddForce(Vector3.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
