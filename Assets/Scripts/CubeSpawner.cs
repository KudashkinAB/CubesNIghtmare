using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Спавнер кубов
/// </summary>
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube cubePrefab;
    [SerializeField] private Transform spawnPoint;
    public UnityEvent OnSpawnerEnabled;
    public UnityEvent OnSpawnerDisabled;

    private float timer = 0.5f;
    private float movementSpeed = 1f;
    private float maxDistance = 10f;
    private float spawnCooldown = 0.5f;
    private bool spawnInProgress = true;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
            Debug.Log("Set Movement Speed: " + movementSpeed);
        }
    }
    public float MaxDistance
    {
        get
        {
            return maxDistance;
        }
        set
        {
            maxDistance = value;
            Debug.Log("Set Max Distance: " + maxDistance);
        }
    }
    public float SpawnCooldown
    {
        get
        {
            return spawnCooldown;
        }
        set
        {
            spawnCooldown = value;
            Debug.Log("Set Spawn Cooldown: " + spawnCooldown);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnCooldown && spawnInProgress)
        {
            SpawnCube();
            timer = 0;
        }
    }

    /// <summary>
    /// Включает/выключает работу спавнера
    /// </summary>
    public void Toggle()
    {

        spawnInProgress = !spawnInProgress;
        if (spawnInProgress)
        {
            OnSpawnerEnabled?.Invoke();
        }
        else
        {
            OnSpawnerDisabled?.Invoke();
        }

        Debug.Log("Toggle Spawner: " + spawnInProgress);
    }

    /// <summary>
    /// Спавнит куб
    /// </summary>
    private void SpawnCube()
    {
        if (!spawnPoint)
        {
            Debug.LogError("Missing SpawnPoint");
            return;
        }
        Cube cube = Instantiate(cubePrefab, spawnPoint.position, new Quaternion());
        cube.SetSettings(movementSpeed, maxDistance);
    }
}
