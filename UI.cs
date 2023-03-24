using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeElapsed;
    [SerializeField] private TextMeshProUGUI highScore;

    void Update()
    {
        if(GameLogic.instance.isGameRunning()) {
            timeElapsed.text = GameLogic.instance.timeElapsed.ToString("00000");
            //highScore.text = GameLogic.instance.highScore.ToString("00000");
        }
        else
        {
            highScore.text = GameLogic.instance.highScore.ToString("00000");
        }

    }
}
