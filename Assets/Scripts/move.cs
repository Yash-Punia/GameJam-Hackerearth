using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody m_rigid;
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigid.MovePosition(transform.position + (Vector3.right * Time.deltaTime * speed));
    }
}
