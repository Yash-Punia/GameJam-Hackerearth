using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_element : MonoBehaviour
{
    Rigidbody m_rigid;
    public float speed = 800f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.AddForce(new Vector3(0, 0, -1) * speed);
    }
}
