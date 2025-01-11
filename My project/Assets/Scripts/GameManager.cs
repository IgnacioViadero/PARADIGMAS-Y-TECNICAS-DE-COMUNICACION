using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private float score; // Puntuación del jugador

    void Update()
    {
        score += Time.deltaTime; // Incrementa la puntuación con el tiempo
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            PlayerPrefs.SetFloat("FinalScore", score); // Guarda la puntuación final en PlayerPrefs

            SceneManager.LoadScene("GameOverScene");
        }
    }
}
