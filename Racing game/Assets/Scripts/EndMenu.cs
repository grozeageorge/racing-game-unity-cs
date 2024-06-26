using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject endMenuUI;
    public CheckpointsAndLaps playerCar;
    public CheckpointsAndLaps AICar;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI PlayerTimeText;
    public TextMeshProUGUI AITimeText;
    public TextMeshProUGUI PlayerBestLapText;


    // Update is called once per frame
    void Update()
    {
        if (playerCar.finished)
        {
            Finished();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Finished()
    {
        if (playerCar.finished == true && AICar.finished == false)
        {
            //string formattedCurrentTime = $"Current: {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000}
            TitleText.SetText("YOU WON!");
            PlayerTimeText.SetText($"Time: {Mathf.FloorToInt(playerCar.endTime / 60)}:{playerCar.endTime % 60:00.000}");
            PlayerBestLapText.SetText($"Best Lap: {playerCar.bestLap}");
            AITimeText.SetText("AI Didn't finish the race.");
        }

        if (playerCar.finished == true && AICar.finished == true)
        {
            if (playerCar.endTime < AICar.endTime)
            {
                TitleText.SetText("YOU WON");
                PlayerTimeText.SetText($"Time: {Mathf.FloorToInt(playerCar.endTime / 60)}:{playerCar.endTime % 60:00.000}");
                PlayerBestLapText.SetText($"Best Lap: {playerCar.bestLap}");
                AITimeText.SetText($"AI Time: {Mathf.FloorToInt(AICar.endTime / 60)}:{AICar.endTime % 60:00.000}");
            }
            else
            {
                TitleText.SetText("YOU LOST");
                PlayerTimeText.SetText($"Time: {Mathf.FloorToInt(playerCar.endTime / 60)} : {playerCar.endTime % 60:00.000}");
                PlayerBestLapText.SetText($"Best Lap: {playerCar.bestLap}");
                AITimeText.SetText($"AI Time: {Mathf.FloorToInt(AICar.endTime / 60)} : {AICar.endTime % 60:00.000}");
            }
        }

        endMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
