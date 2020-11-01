using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Sprite[] sceneTitleSprite;
    [SerializeField] Image backgroundImage;
    [SerializeField] int alphaValue = 0;
    int decreasingValue = 5;
    int imageIndex = 0;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    [SerializeField] int turn = 0;


    bool isFadeAllowed = true;
    void Start()
    {
        backgroundImage.GetComponent<Image>().sprite = sceneTitleSprite[imageIndex];
    }
    private void Update()
    {
        if (isFadeAllowed)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                alphaValue = alphaValue + decreasingValue;
                if (alphaValue > 255)
                {
                    alphaValue = 255;
                }
                backgroundImage.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alphaValue);

                if (alphaValue <= 0)
                {
                    decreasingValue = decreasingValue * -1;
                    turn = turn + 1;
                    if (turn % 2 == 0)
                    {
                        imageIndex++;
                        if (imageIndex >= 3)
                        {
                            imageIndex = 0;
                        }
                        backgroundImage.GetComponent<Image>().sprite = sceneTitleSprite[imageIndex];
                    }
                }
                else if (alphaValue >= 255)
                {
                    decreasingValue = decreasingValue * -1;
                    turn = turn + 1;
                }
            }
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadTitleScene()
    {
      SceneManager.LoadScene("Updated_Title");
    }
}