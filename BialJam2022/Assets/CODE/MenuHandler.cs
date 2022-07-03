using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject tutorialScreenSecond;

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void NextTutorialPage()
    {
        if(tutorialScreen.activeSelf)
        {
            tutorialScreen.SetActive(false);
            tutorialScreenSecond.SetActive(true);
        }
        else
        {
            tutorialScreen.SetActive(true);
            tutorialScreenSecond.SetActive(false);
        }
    }

    public void HideTutorial()
    {
        tutorialScreen.SetActive(false);
        tutorialScreenSecond.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
}
