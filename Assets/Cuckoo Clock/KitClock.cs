using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    //Coroutine moveClockHands;
    IEnumerator moveClockHands;

    void Start()
    {
        clockIsRunning = StartCoroutine(RunTheClock());
    }

    private IEnumerator RunTheClock()
    {
        while (true)
        {
            moveClockHands = MoveTheClockHandsOneHour();
            yield return moveClockHands;

            //yield return moveClockHands = StartCoroutine(MoveTheClockHandsOneHour());
        }
    }

    private IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0,0,-(360/timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour = (hour % 12) + 1;
        OnTheHour.Invoke(hour);
    }

    public void StopClock()
    {
        if (clockIsRunning != null)
            StopCoroutine(clockIsRunning);
        if (moveClockHands != null)
            StopCoroutine(moveClockHands);
    }
}
