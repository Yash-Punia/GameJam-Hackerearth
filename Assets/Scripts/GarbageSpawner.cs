using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField] int garbageQuantity = 250;
    [SerializeField] GameObject garbagePrefab;
    [SerializeField] Transform positionOfProduction;
    [SerializeField] GameObject garbageParentHolder;
    [SerializeField] float value =1.5f;
    public float speedOfProduction = 0.3f;
    bool garbageRequired = true;
    float time = 0.3f;
    float currentTime = 0f;



    private void Update()
    {
        StartCoroutine(startProduction());
        IEnumerator startProduction()
        {
            if (garbageRequired)
            {
                speedOfProduction += 0.1f;
                if (garbageQuantity <= 0)
                {
                    garbageRequired = false;
                }
            }
            yield return new WaitForSeconds(speedOfProduction);
            if (garbageRequired)
            {
                float positionX = Random.Range(-value, value);
                Vector3 positionFinal = new Vector3(positionX*2 + positionOfProduction.position.x,positionOfProduction.position.y + positionX, positionOfProduction.position.z + positionX);
                if (Time.time > currentTime)
                {
                    time = time + currentTime;
                    GameObject garbage = Instantiate(garbagePrefab, positionFinal, Quaternion.identity);
                    garbage.transform.SetParent(garbageParentHolder.transform);
                    garbageQuantity--;
                }
            }

        }
        
    }
}
