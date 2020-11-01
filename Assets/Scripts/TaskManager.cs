using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public List<string> Tasks;
    public float time = 500;
    float maxtime;
    public static int iron = 0;
    public static int aluminium = 0;
    public static int plastic = 0;
    public static int silicon = 0;
    public static int wood = 0;
    public static int status = 0;
    public List<GameObject> product;
    public GameObject slider;
    public Slider sliderval;
    public TextMeshProUGUI task;
    public GameObject completed;
    public GameObject tryagain;
    public GameObject startingcanvas;
    public Transform pos;
    public GameObject wrong_entry;
    bool key = false;
    GUIStyle guistyle = new GUIStyle();

    public int Count = 0;

    private void OnGUI()
    {
        guistyle.fontSize = 25;
        guistyle.normal.textColor = Color.white;
        GUI.BeginGroup(new Rect(10, 10, 600, 150));
        GUI.Box(new Rect(0, 0, 140, 140), "  Iron : " + iron, guistyle);
        GUI.Label(new Rect(10, 25, 500, 30), "Aluminium : " + aluminium, guistyle);
        GUI.Label(new Rect(10, 50, 500, 30), "Plastic : " + plastic, guistyle);
        GUI.Label(new Rect(10, 75, 500, 30), "Silicon : " + silicon, guistyle);
        GUI.Label(new Rect(10, 100, 500, 30), "Wood : " + wood, guistyle);
        GUI.Label(new Rect(10, 125, 500, 30), "Time : " + (int)time, guistyle);
        GUI.Label(new Rect(10, 150, 500, 30), "Status : " + status, guistyle);
        GUI.EndGroup();
    }
    private void Start()
    {
        maxtime = time;
        completed.SetActive(false);
        tryagain.SetActive(false);
        Generate_Number();
    }

    private void Generate_Number()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = UnityEngine.Random.Range(1, 6);
            if (rand == 1)
            {
                ++iron;
            }
            else if (rand == 2)
            {
                ++aluminium;
            }
            else if (rand == 3)
            {
                ++plastic;
            }
            else if (rand == 4)
            {
                ++silicon;
            }
            else
            {
                ++wood;
            }
        }
    }
    public void change_number(int key)
    {
        if (key == 1 && iron > 0)
        {
            iron--;
        }
        else if (key == 2 && aluminium > 0)
        {
            aluminium--;
        }
        else if (key == 3 && plastic > 0)
        {
            plastic--;
        }
        else if (key == 4 && silicon > 0)
        {
            silicon--;
        }
        else if (key == 5 && wood > 0)
        {
            wood--;
        }
        else
        {
            wrong_entry.GetComponent<production>().wrong();
        }
    }
    private void FixedUpdate()
    {
        sliderval.value = time / maxtime;
        time -= Time.deltaTime;
        if (time <= 1)
        {
            time = 0;
            tryagain.SetActive(true);
            Invoke("scene_restart", 2);
        }
    }
    private void Update()
    {
        if ((iron + wood + silicon + plastic + aluminium) == 0 && !key)
        {
            status = 1;
            Instantiate(product[Count], pos.position, Quaternion.identity);
            key = true;
            Invoke("completecanvas", 1);
        }
    }
    void completecanvas()
    {
        completed.SetActive(true);
        Invoke("scene_next", 2);
    }
    void scene_restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void scene_next()
    {
        completed.SetActive(false);
        tryagain.SetActive(false);
        Generate_Number();
        Count++;
        task.text = Tasks[Count];
        startingcanvas.SetActive(true);
        slider.SetActive(false);
        Invoke("TurnOff", 2);
        time = 400;
        completed.SetActive(false);
        tryagain.SetActive(false);
        Generate_Number();
        key = false;
    }
    void TurnOff()
    {
        startingcanvas.SetActive(false);
        slider.SetActive(true);
    }
}
