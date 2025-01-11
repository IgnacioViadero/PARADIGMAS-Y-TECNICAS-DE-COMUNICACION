using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText; // Referencia al texto de la puntuación

    void Start()
    {
        finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        float finalTime = PlayerPrefs.GetFloat("FinalScore", 0);
        finalScoreText.text = "Puntuación : " + finalTime.ToString("F2");
    }
    public void ReiniciarEasyGame()
    {
        SceneManager.LoadScene("EasyGameScene");
    }
    public void ReiniciarHardGame()
    {
        SceneManager.LoadScene("HardGameScene");
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
