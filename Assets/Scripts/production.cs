using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class production : MonoBehaviour
{
    public static int n = 0;
    int mul = 1;
    public bool on;
    public GameObject[] final_products;
    public Transform pos;
    static int k = 0;
    void Start()
    {
        on = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="element")
        {
            n++;
            mul *= other.gameObject.GetComponent<element_>().element_number;
            if (other.gameObject.GetComponent<element_>().element_number==2)
                k++;
            if (n % 2 == 0)
                final_product(mul);
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "garbage")
        {
            n++;
            elements = collision.gameObject;
            mul *= collision.gameObject.GetComponent<extractor>().element_number;
            if (mul == 2)
                k++;
            if (n % 2 == 0)
                final_product(mul);
        }
    }*/
    void final_product(int n)
    {
        switch (n)
        {
            case 2:
                Debug.Log(mul);
                Debug.Log("Gun");
                Instantiate(final_products[0], pos.position, Quaternion.identity);
                mul = 1;
                k = 0;
                //GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                break;
            case 3:
                Debug.Log(mul);
                Debug.Log("Car");
                Instantiate(final_products[5], pos.position, Quaternion.identity);
                mul = 1;
                k = 0;
                //GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.2f);
                break;
            case 4:
                if (k == 2)
                {
                    Debug.LogError("Wrong Pair");
                    k = 0;
                    break;
                }
                Debug.Log(mul);
                Debug.Log("Laptop");
                Instantiate(final_products[6], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                break;
            case 5:
                Debug.Log(mul);
                Debug.Log("Horse_Toy");
                Instantiate(final_products[4], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
                break;
            case 6:
                Debug.Log(mul);
                Debug.Log("Bottle");
                Instantiate(final_products[2], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 0.5f, 0.5f);
                break;
            case 8:
                Debug.Log(mul);
                Debug.Log("Microcontroller");
                Instantiate(final_products[3], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                break;
            case 10:
                Debug.Log(mul);
                Debug.Log("Almirah");
                Instantiate(final_products[1], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.2f);
                break;
            case 12:
                Debug.Log(mul);
                Debug.Log("Mobile");
                Instantiate(final_products[9], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                break;
            case 15:
                Debug.Log(mul);
                Debug.Log("Vase");
                Instantiate(final_products[7], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
                break;
            case 20:
                Debug.Log(mul);
                Debug.Log("Fancy Door");
                Instantiate(final_products[8], pos.position, Quaternion.identity);
                k = 0;
                mul = 1;
                //GetComponent<MeshRenderer>().material.color = new Color(0, 0.5f, 0.5f);
                break;
            default:
                Debug.Log(mul);
                Debug.LogError("Wrong Pair");
                mul = 1;
                k = 0;
                break;
        }
    }
    public void finish_product()
    {

    }
    /*// Update is called once per frame
    *//*void Update()
    {
        check();
    }*//*
    private void check()
    {
        if(n%2==0 && n!=0 && on)
        {
            //GetComponent<BoxCollider>().enabled = false;
            Invoke("timer_control", 0.3f);
        }
        else
        {
            on = true;
            //GetComponent<BoxCollider>().enabled = true;
        }
    }
    void timer_control()
    {
        k = 0;
        mul = 1;
        on = false;
    }*/
}
