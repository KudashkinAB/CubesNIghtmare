using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������������� ����� �� Image
/// </summary>
public class ColorChangerUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color color1, color2;

    private void Awake()
    {
        image.color = color1;
    }

    /// <summary>
    /// ������������ ����� Image
    /// </summary>
    public void ChangeColor()
    {
        image.color = image.color == color1 ? color2 : color1;
    }
}
