using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler instante;

    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject tutorialScreenSecond;

    [SerializeField] private Button[] buttons;

    void Awake()
    {
        instante = this;
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        tutorialScreen.SetActive(true);
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
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
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }
    }

    public void Exit(){
        Application.Quit();
    }
}
