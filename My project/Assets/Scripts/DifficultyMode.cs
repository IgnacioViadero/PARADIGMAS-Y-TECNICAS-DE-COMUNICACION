using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMode : MonoBehaviour
{
    public GameObject difficultyModePanel;

    public void EasyMode()
    {
        SceneManager.LoadScene("EasyGameScene");
    }
    public void HardMode()
    {
        SceneManager.LoadScene("HardGameScene");
    }
}
