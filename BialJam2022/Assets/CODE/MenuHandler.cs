using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void HideTutorial()
    {
        tutorialScreen.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
}
