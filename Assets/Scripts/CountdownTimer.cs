using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text counterRacingText;
    float timeRacingCounter = 0f;
    public static bool isLost = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeRacingCounter = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDownStart.timeStartCouter < 0)
        {
            if (timeRacingCounter > 0)
            {
                timeRacingCounter -= 1 * Time.deltaTime;
                counterRacingText.text = timeRacingCounter.ToString("00");
                isLost = false;
            }
            else
            {
                isLost = true;
            }
        }
        else
        {
            counterRacingText.text = "";
        }

    }

}
