using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterSwitcher : MonoBehaviour
{
    public GameObject tilemap;

    // включаем рисование тайлами
    private void OnEnable()
    {
        // Действия при активации объекта
        tilemap.GetComponent<PlayerTilePainter>().enabled = true;
    }
    // выключаем
    private void OnDisable()
    {
        if (tilemap != null) 
        {
            tilemap.GetComponent<PlayerTilePainter>().enabled = false;
        }
        
    }
}
