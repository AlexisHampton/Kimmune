using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("Time")]
    public TextMeshProUGUI timeText;

    public void UpdateTime(Clock clock)
    {
        timeText.text = clock.ToString();
    }


}
