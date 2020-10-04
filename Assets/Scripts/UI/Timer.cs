using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float secondsPassed;

    private void Start()
    {
        secondsPassed = 0;
        StartCoroutine(CountUp());
    }

    private IEnumerator CountUp()
    {
        var ts = TimeSpan.FromSeconds(secondsPassed);
        timerText.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
        yield return new WaitForSeconds(1);
        secondsPassed++;
        StartCoroutine(CountUp());
    }
}
