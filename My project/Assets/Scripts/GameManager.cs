using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private float score; // Puntuaci�n del jugador

    void Update()
    {
        score += Time.deltaTime; // Incrementa la puntuaci�n con el tiempo
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            PlayerPrefs.SetFloat("FinalScore", score); // Guarda la puntuaci�n final en PlayerPrefs

            SceneManager.LoadScene("GameOverScene");
        }
    }
}
