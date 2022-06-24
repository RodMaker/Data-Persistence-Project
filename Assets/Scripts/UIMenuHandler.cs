using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIMenuHandler : MonoBehaviour
{
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor); // added to load the saved color
        ScoreText.text = "Best Score: " + MainManager.Instance.playerText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SavePlayerNameAndScore();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SavePlayerNameAndScore()
    {
        MainManager.Instance.SavePlayerNameAndScore();
    }

    public void LoadPlayerNameAndScore()
    {
        MainManager.Instance.LoadPlayerNameAndScore();
        ScoreText.text = MainManager.Instance.ScoreText;
        playerText.text = MainManager.Instance.playerText;
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
