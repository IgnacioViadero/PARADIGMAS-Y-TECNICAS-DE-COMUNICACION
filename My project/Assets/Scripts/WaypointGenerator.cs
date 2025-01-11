using System.Collections.Generic;
using UnityEngine;

public class WaypointGenerator : MonoBehaviour
{
    public GameObject waypointPrefab; // Prefab del waypoint
    public float waypointInterval = 2.0f; // Intervalo entre waypoints (en segundos)
    public Transform waypointsParent; // Padre para organizar los waypoints en la jerarquía

    private float timer = 0f;
    private List<Transform> waypoints = new List<Transform>(); // Lista de waypoints generados

    void Update()
    {
        // Incrementa el tiempo
        timer += Time.deltaTime;

        // Si el tiempo supera el intervalo, genera un nuevo waypoint
        if (timer >= waypointInterval)
        {
            CreateWaypoint();
            timer = 0f; // Reinicia el temporizador
        }
    }

    private void CreateWaypoint()
    {
        // Crea un waypoint en la posición actual del taxi
        GameObject newWaypoint = Instantiate(waypointPrefab, transform.position, Quaternion.identity, waypointsParent);
        waypoints.Add(newWaypoint.transform); // Añádelo a la lista

        Debug.Log("Waypoint creado en: " + transform.position);
    }

    public List<Transform> GetWaypoints()
    {
        return waypoints; // Retorna la lista de waypoints para otros scripts (como el vehículo de policía)
    }
}
