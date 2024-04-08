using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer1 : MonoBehaviour
{
    public TMP_Text tex;
    float countdown = 121;
    float time_elapsed;
    float initial_value;

    void Start()
    {
        initial_value = countdown;
    }

    void Update()
    {
        if (countdown > 1)
        {
            countdown -= Time.deltaTime;
            time_elapsed = initial_value - countdown;
        }


        else if (countdown < 1)
        {
            SceneManager.LoadScene("Thanks For Playing");
        }

        float min = Mathf.FloorToInt(countdown / 60);
        float sec = Mathf.FloorToInt(countdown % 60);
        tex.text = string.Format("{0,00}:{1,00}", min, sec);
        float min_e = Mathf.FloorToInt(time_elapsed / 60);
        float sec_e = Mathf.FloorToInt(time_elapsed % 60);
    }
}
