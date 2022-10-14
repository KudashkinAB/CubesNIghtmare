using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���
/// </summary>
public class Cube : MonoBehaviour
{
    [SerializeField] Transform cubeTransform;
    
    private float size = 1f;
    private float distance = 1f;
    private float movementSpeed = 0.04f;

    private void Awake()
    {
        if (!cubeTransform)
        {
            cubeTransform = transform;
        }
    }

    private void Update()
    {
        float deltaZ = movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, deltaZ);
        distance -= deltaZ;
        //����� ���� �������� �������� �������� ����� ����� �� �������� ��������� � ������������ ��������� � ����� ������ ��������, ����� ��������
        if (distance < (size * 0.5f))
        {
            if(distance < 0)
            {
                Destroy(gameObject);
                return;
            }
            transform.localScale = Vector3.one * Mathf.Lerp(size, 0f, 1f - distance / (size * 0.5f));
        }
    }

    /// <summary>
    /// ��������� ���������� ����
    /// </summary>
    /// <param name="movementSpeed">
    /// �������� �������� ����
    /// </param>
    /// <param name="maxDistance">
    /// ��������� ����� ������� ��� ��������
    /// </param>
    public void SetSettings(float movementSpeed, float maxDistance)
    {
        this.movementSpeed = movementSpeed;
        distance = maxDistance;
        size = transform.localScale.z;
    }
}
