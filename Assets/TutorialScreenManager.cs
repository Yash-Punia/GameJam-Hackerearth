using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreenManager : MonoBehaviour
{
    [SerializeField] GameObject[] textUI;
    private int index = 0;
    bool isChangeAllowed = true;
    private void Start()
    {
        for(int i=0;i<6;i++)
        {
            textUI[i].SetActive(false);
        }
        StartCoroutine(SHOWUI());
    }
    IEnumerator SHOWUI()
    {
        yield return new WaitForSeconds(4f);
        textUI[0].SetActive(true);
    }
    public void ShowNextUI()
    {if (isChangeAllowed)
        {
            textUI[index].SetActive(false);
            index++;
            StartCoroutine(Waiting());
        }
    }
    public void AllUIText()
    { if (isChangeAllowed)
        {
            textUI[4].SetActive(false);
            StartCoroutine(LastUI());
        }
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        textUI[index].SetActive(true);
    }
    IEnumerator LastUI()
    {
        textUI[5].SetActive(true);
        isChangeAllowed = false;
        yield return new WaitForSeconds(7f);
        textUI[5].SetActive(false);
    }
}
