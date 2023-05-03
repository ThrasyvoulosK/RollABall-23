using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static float time = 0;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponentInChildren<TMP_Text>();

        //reset timeText
        time = 0;
        timeText.text = "null";

        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        //based on code from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
        time += Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float decSeconds = time % 1*100;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}",minutes,seconds,decSeconds);
    }
}
