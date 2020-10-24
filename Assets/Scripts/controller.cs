using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controller : MonoBehaviour
{
    public float speed = 20f;
    public Camera camera;
    public bool canHold = true;
    GameObject garbage;
    public GameObject view;
    public Transform guide;
    private void Start()
    {
        //garbage = GameObject.FindGameObjectWithTag("Interactable");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw_and_Drop();
        }
        gaze();
    }

    private void Throw_and_Drop()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5) && canHold)
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                garbage = hit.transform.gameObject;
                Pickup(garbage);
            }
        }
        else
            throw_drop(garbage);
        if (!canHold)
            garbage.transform.position = guide.position;
    }

    private void gaze()
    {
        RaycastHit hitt;
        Ray rayy = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayy, out hitt, 5) && canHold)
        {
            if (hitt.transform.CompareTag("Interactable"))
            {
                view.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                view.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void Pickup(GameObject garbage)
    {
        garbage.transform.SetParent(guide);
        garbage.GetComponent<Rigidbody>().useGravity = false;
        garbage.transform.localRotation = transform.rotation;
        garbage.transform.position = guide.position;
        canHold = false;
    }

    private void throw_drop(GameObject garbage)
    {
        if (canHold) return;
        garbage.GetComponent<Rigidbody>().useGravity = true;
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = camera.transform.forward * speed;
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}
