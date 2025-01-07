using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownStart : MonoBehaviour
{
    public Text counterStartText;
    public static float timeStartCouter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timeStartCouter = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStartCouter > 0)
        {
            timeStartCouter -= 1 * Time.deltaTime;
            counterStartText.text = timeStartCouter.ToString("00");
        }
        else
        {
            counterStartText.text = "";
        }
    }
}
