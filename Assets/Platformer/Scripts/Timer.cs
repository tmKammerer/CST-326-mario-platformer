using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float accumilatedTime = 0f;
    private float totalTime = 360f;
    public TextMeshProUGUI timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        timerDisplay.text = $"{totalTime}";
    }

    // Update is called once per frame
    void Update()
    {
        accumilatedTime += Time.deltaTime;

       
        if (accumilatedTime > 1f)
        {
            totalTime -= 1f;
            accumilatedTime = 0f;
            timerDisplay.text = $"{totalTime}";
        }
        
    }
}
