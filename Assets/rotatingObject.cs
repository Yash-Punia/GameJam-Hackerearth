using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,1f*Time.deltaTime);
    }

}