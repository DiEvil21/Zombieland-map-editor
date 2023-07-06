using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterSwitcher : MonoBehaviour
{
    public GameObject tilemap;

    // �������� ��������� �������
    private void OnEnable()
    {
        // �������� ��� ��������� �������
        tilemap.GetComponent<PlayerTilePainter>().enabled = true;
    }
    // ���������
    private void OnDisable()
    {
        if (tilemap != null) 
        {
            tilemap.GetComponent<PlayerTilePainter>().enabled = false;
        }
        
    }
}
