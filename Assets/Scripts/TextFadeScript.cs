using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextFadeScript : MonoBehaviour
{
    private Text levelText;
    private float curTime;
    private Vector4 curColor;
    [SerializeField]
    private float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<Text>();
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        curTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, maxTime);
        curColor = new Color(1.0f, 1.0f, 1.0f, EaseInQuint(1.0f, 0.0f, curTime/maxTime));

        levelText.color = curColor;
    }

    private float EaseInQuint(float start, float end, float value)
    {
        end -= start;
        return end * value * value * value * value * value + start;
    }
}
