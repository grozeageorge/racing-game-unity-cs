using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsAndLaps : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject start;
    public GameObject end;
    public GameObject[] checkpoints;

    [Header("Settings")]
    public float laps = 1;
    public bool visibleUI = false;

    [Header("Information")]
    private float currentCheckpoint;
    private float currentLap;
    private bool started;
    public bool finished;

    public float endTime;
    private float currentLapTime;
    private float bestLapTime;
    public float bestLap;

    private void Start()
    {
        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;

        endTime = 0;
        currentLapTime = 0;
        bestLapTime = 0;
        bestLap = 0;
    }

    private void Update()
    {
        if (started && !finished)
        {
            currentLapTime += Time.deltaTime;

            if (bestLap == 0)
            {
                bestLap = 1;
            }
        }

        if (started)
        {
            if (bestLap == currentLap)
            {
                bestLapTime = currentLapTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            GameObject thisCheckpoint = other.gameObject;

            // RACE STARTED

            if (thisCheckpoint == start && !started)
            {
                print("Started");
                started = true;
            }
            // ENDED THE LAP OR RACE
            else if (thisCheckpoint == end && started)
            {
                // CHECK IF LAPS ARE FINISHED
                if (currentLap == laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        if (currentLapTime < bestLapTime)
                        {
                            bestLap = currentLap;
                        }
                        endTime += currentLapTime;
                        finished = true;
                        print("Finished");
                    }
                    else
                    {
                        print("Did not go through all checkpoints");
                    }
                }

                //IF LAPS ARE NOT FINISHED START NEW LAP

                else if (currentLap < laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        if (currentLapTime < bestLapTime)
                        {
                            bestLap = currentLap;
                            bestLapTime = currentLapTime;
                        }

                        currentLap++;
                        currentCheckpoint = 0;
                        endTime += currentLapTime;
                        currentLapTime = 0;
                        print($"Started Lap {currentLap} - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000}");
                    }
                }
                else
                {
                    print("Did not go through all checkpoints");
                }
            }

            // LOOP CHECKPOINTS -> COMPARE AND CHECK WHICH CHECKPOINT THE PLAYER PASSED THROUGH

            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                    return;

                // CHECKPOINT CORRECT?

                if (thisCheckpoint == checkpoints[i] && i == currentCheckpoint)
                {
                    print($"Correct checkpoint - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000}");
                    currentCheckpoint++;
                }

                // CHECKPOINT IS INCORRENT

                else if (thisCheckpoint == checkpoints[i] && i != currentCheckpoint)
                {
                    print("Incorrect checkpoint");
                }
            }
        }
    }

    public static string ColorString(string text, Color color)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + text + "</color>";
    }

    private void OnGUI()
    {
        if (visibleUI)
        {
            //CURRENT TIME
            string formattedCurrentTime = $"Current: {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000} - (Lap {currentLap})";
            GUI.Label(new Rect(50, 10, 250, 100), ColorString(formattedCurrentTime, Color.blue));

            //BEST TIME
            string formattedBestTime = $"Best: {Mathf.FloorToInt(bestLapTime / 60)}:{bestLapTime % 60:00.000} - (Lap {bestLap})";
            GUI.Label(new Rect(250, 10, 250, 100), ColorString(formattedBestTime, Color.blue));
        }
    }
}
