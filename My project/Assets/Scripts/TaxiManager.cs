using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiManager : MonoBehaviour
{
    public float health = 100;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Building"))
        {
            health -= 20;
            Debug.Log("Vida restante: " + health);
       

        if (health <= 0)
            {
                Debug.Log("Game Over. Cambiando de escena...");
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

}
