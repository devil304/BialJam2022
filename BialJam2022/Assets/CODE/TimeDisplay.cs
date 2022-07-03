using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private TMPro.TextMeshProUGUI text;

    void Update()
    {
        text.text = timer.GameTime.ToString("0.0");
    }
}
