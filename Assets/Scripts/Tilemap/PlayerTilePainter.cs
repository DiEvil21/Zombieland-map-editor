using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.Tilemaps;

public class PlayerTilePainter : MonoBehaviour
{
    public Sprite playerSprite; // Спрайт игрока

    private Tilemap tilemap;
    private TilemapRenderer tilemapRenderer;
    

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Возвращаемся, если клик был сделан на UI-элементе
            return;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = tilemap.WorldToCell(mouseWorldPos);

        if (Input.GetMouseButton(0))
        {
            // Проверяем, есть ли уже тайл в данной позиции
            if (tilemap.GetTile(tilePos) == null)
            {
                Tile tile = ScriptableObject.CreateInstance<Tile>();

                // Устанавливаем спрайт в тайл
                tile.sprite = playerSprite;
                tile.name = playerSprite.name;
                // Устанавливаем тайл на карте
                tilemap.SetTile(tilePos, tile);
            }
        }
        else if (Input.GetMouseButton(1))
        {
            // Удаляем тайл из указанной позиции
            tilemap.SetTile(tilePos, null);

            
        }
    }
}



