using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI nameText;

    void Start()
    {
        bestScoreText.text = ScoreManager.Instance.BestToText();
    }
    void Update()
    {
        
    }
    public void OnNameValueChanged()
    {
        ScoreManager.Instance.name = nameText.text;
    }
    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
