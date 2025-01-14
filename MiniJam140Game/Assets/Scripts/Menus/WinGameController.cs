using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameController : MonoBehaviour
{
    public GameObject WinScreen;
    public DoorController DoorController;
    public TimerScript Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = FindAnyObjectByType<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    public void GoToNextLevel()
    {
        //go to the next scene in scenemanager
        //set timescale to 1
        //deactivate winscreen
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    public void GetWin()
    {
        Timer.timerOn = false;
        WinScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
