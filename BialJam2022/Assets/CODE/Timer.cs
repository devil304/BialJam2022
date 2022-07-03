using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float etapTime;
    [SerializeField] private GameObject timeoutScreen;

    public float GameTime => _gameTime;

    private float _gameTime = 0;
    private bool _timeout;

    void Update()
    {
        if(_gameTime < etapTime) _gameTime += Time.deltaTime;
        if(_gameTime >= etapTime && !_timeout)
        {
            _timeout = true;
            timeoutScreen.SetActive(true);
            StartCoroutine(TimeoutWait());
        }
    }

    private IEnumerator TimeoutWait()
    {
        yield return new WaitForSeconds(3f);
        if (SceneManager.GetActiveScene().buildIndex+1 < 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
