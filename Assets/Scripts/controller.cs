using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controller : MonoBehaviour
{
    public List<AudioClip> clips;
    public float speed = 50f;
    public Camera ccamera;
    public bool canHold = true;
    GameObject garbage;
    public GameObject view;
    public Transform guide;
    bool interactable = false;
    bool thrown = false;
    void playaudio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
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
        if (interactable && canHold)
        {
            playaudio(clips[0]);
            thrown = false;
            Pickup(garbage);
        }
        else
        {
            thrown = true;
            Invoke("thrown_false", 1.5f);
            throw_drop(garbage);
        }
        if (!canHold)
            garbage.transform.position = guide.position;
    }
    void thrown_false()
    {
        thrown = false;
    }

    private void gaze()
    {
        RaycastHit hitt;
        Ray rayy = ccamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayy, out hitt, 10))
        {
            if ((hitt.transform.CompareTag("garbage") || hitt.transform.CompareTag("crushed") || hitt.transform.CompareTag("element")) && canHold  && !thrown)
            {
                interactable = true;
                garbage = hitt.transform.gameObject;
                view.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                interactable = false;
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
        playaudio(clips[1]);
        garbage.GetComponent<Rigidbody>().useGravity = true;
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = (new Vector3(0, 0.35f, 0) + ccamera.transform.forward) * speed;
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}
