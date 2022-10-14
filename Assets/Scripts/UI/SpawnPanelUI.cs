using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Интерфейс спавнера кубов
/// </summary>
public class SpawnPanelUI : MonoBehaviour
{
    [SerializeField] private CubeSpawner cubeSpawner;
    [Header("Speed")]
    [SerializeField] private TMP_InputField speedField;
    [SerializeField] private float minSpeed = 0.1f;
    [SerializeField] private float maxSpeed = 5f;
    [Header("Distance")]
    [SerializeField] private TMP_InputField distanceField;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 10f;
    [Header("Time Delay")]
    [SerializeField] private TMP_InputField timeField;
    [SerializeField] private float minDelay = 0.1f;
    [SerializeField] private float maxDelay = 30f;

    private void Awake()
    {
        SetSpeed();
        SetDistance();
        SetTime();
    }

    /// <summary>
    /// Скорость кубов
    /// </summary>
    public void SetSpeed()
    {
        if (float.TryParse(speedField.text, out float speed))
        {
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            speedField.text = speed.ToString();
            cubeSpawner.MovementSpeed = speed;
        }
        else
        {
            speedField.text = cubeSpawner.MovementSpeed.ToString();
        }
    }

    /// <summary>
    /// Установка дистанции движения кубов
    /// </summary>
    public void SetDistance()
    {
        if (float.TryParse(distanceField.text, out float distance))
        {
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            distanceField.text = distance.ToString();
            cubeSpawner.MaxDistance = distance;
        }
        else
        {
            distanceField.text = cubeSpawner.MaxDistance.ToString();
        }
    }

    /// <summary>
    /// Установка промежутка времени между спавнами кубов
    /// </summary>
    public void SetTime()
    {
        if (float.TryParse(timeField.text, out float delay))
        {
            delay = Mathf.Clamp(delay, minDelay, maxDelay);
            timeField.text = delay.ToString();
            cubeSpawner.SpawnCooldown = delay;
        }
        else
        {
            timeField.text = cubeSpawner.SpawnCooldown.ToString();
        }
    }

    /// <summary>
    /// Переключение тумблера спавнера
    /// </summary>
    public void Toggle()
    {
        cubeSpawner.Toggle();
    }
}
