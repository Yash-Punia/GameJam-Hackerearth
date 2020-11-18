using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GarbageObject : MonoBehaviour
{
    private GameManager gameManager;
    private int garbageInfoNumber;

    [Header("MovingLocationMachine1")]
    public bool movePos1 = false,started1 = false;
    [SerializeField] Transform startPosition1;
    [SerializeField] Transform endPosition1;

    [Header("MovingLocationMachine2")]
    public bool movePos2 = false,started2 = false;
    [SerializeField] Transform startPosition2;
    [SerializeField] Transform endPosition2;

    [Header("MovingLocationMachine3")]
    public bool movePos3 = false,started3 = false;
    [SerializeField] Transform startPosition3;
    [SerializeField] Transform endPosition3;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        garbageInfoNumber = gameManager.GetRandomElements();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Crusher" && started1==false)
        {
            garbageMovementManager();
            started1 = true;
        }
        if(collision.gameObject.name == "Extractor" && started2==false)
        {
            //gameManager.GarbageInstantiator(garbageInfoNumber);
            extractorMovementManager();
            started2 = true;
        }
        if(collision.gameObject.name == "Production" && started3 == false)  // this is wrong method for production of elements further need to managed
        {
            // gameManager.ProductInstantiator(garbageInfoNumber);
            productionMovementManager();
            started3 = true;
        }
    }

    private void Update()
    {
        if(movePos1)
        {
            //transform.position = Vector3.MoveTowards(startPosition1.position, endPosition1.position, 2 * Time.fixedDeltaTime);
            transform.position += new Vector3(0f, 0f, 2f) * Time.deltaTime;
            if(transform.position.z >= endPosition1.position.z)
            {
                movePos1 = false;
            }
        }
        if (movePos2)
        {
            transform.position += new Vector3(0f, 0f, 2f) * Time.deltaTime;
            if (transform.position.z >= endPosition2.position.z)
            {
                movePos2 = false;
            }
        }
        if (movePos3)
        {
            transform.position += new Vector3(0f, 0f, 2f) * Time.deltaTime;
            if (transform.position.z >= endPosition3.position.z)
            {
                movePos3 = false;
            }
        }
    }
    private void garbageMovementManager()
    {
        StartCoroutine(ProcessDelay(value => movePos1 = value));
    }
    private void extractorMovementManager()
    {
        StartCoroutine(ProcessDelay(value => movePos2 = value));
    }
    private void productionMovementManager()
    {
        StartCoroutine(ProcessDelay(value => movePos3 = value));
    }
    
    IEnumerator ProcessDelay(Action<bool> action)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newObject = gameManager.CrushedGarbageInstantiator(garbageInfoNumber);
        Debug.Log(newObject.name);
        action(true)
    }
}
