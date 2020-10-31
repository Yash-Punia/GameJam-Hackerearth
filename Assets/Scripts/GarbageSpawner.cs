using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    private int garbageQuantity = 250;
    [SerializeField] GameObject garbagePrefab;
    [SerializeField] Transform positionOfProduction;
    [SerializeField] GameObject garbageParentHolder;
    public float speedOfProduction = 0.3f;
    bool garbageRequired = true;

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
                float positionX = Random.Range((float)(- 0.4), (float)(0.4));
                //float positionY = Random.Range((float)(-positionOfProduction.position.y - 0.5), (float)(positionOfProduction.position.y + 0.5));
                Vector3 positionFinal = new Vector3(positionX + positionOfProduction.position.x,positionOfProduction.position.y + positionX, positionOfProduction.position.z);
                GameObject garbage = Instantiate(garbagePrefab, positionFinal, Quaternion.identity);
                garbage.transform.SetParent(garbageParentHolder.transform);
                garbageQuantity--;
            }

        }
        
    }
}
