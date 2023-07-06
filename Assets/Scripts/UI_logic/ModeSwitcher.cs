using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    public GameObject object_panel;
    public GameObject tiles_panel;
    // переключаем режимы (спавнить объекты или рисовать тайлмапу)

    public void SetObjectMode() 
    {
        tiles_panel.SetActive(false);
        object_panel.SetActive(true);
    }

    public void SetTileMode()
    {
        tiles_panel.SetActive(true);
        object_panel.SetActive(false);
    }
}
