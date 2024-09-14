using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuController : MonoBehaviour
{

    [Header("UI Element")]
    public Button startGameButton;
    public Button configButton;
    public Button quitButton;

    void Start()
    {
        startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        configButton.onClick.AddListener(OnConfigButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnQuitButtonClicked()
    {
        Debug.Log("Quti!");
    }

    private void OnConfigButtonClicked()
    {
        Debug.Log("Config!");
    }

    private void OnStartGameButtonClicked()
    {
        Debug.Log("Start!");
    }
}
