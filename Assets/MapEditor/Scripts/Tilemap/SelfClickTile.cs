using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfClickTile : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private void OnClick()
    {
        Debug.Log("Clicked on self");
        // Добавьте свой код для выполнения действий при клике на себя

        GameObject tilemap = GameObject.FindGameObjectWithTag("tilemap").gameObject;
        tilemap.GetComponent<PlayerTilePainter>().playerSprite = gameObject.transform.GetChild(0).GetComponent<Image>().sprite;

        
    }
}
