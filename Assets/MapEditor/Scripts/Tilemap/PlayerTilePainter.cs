using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.Tilemaps;

public class PlayerTilePainter : MonoBehaviour
{
    public Sprite playerSprite; // ������ ������

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
            // ������������, ���� ���� ��� ������ �� UI-��������
            return;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = tilemap.WorldToCell(mouseWorldPos);

        if (Input.GetMouseButton(0))
        {
            // ���������, ���� �� ��� ���� � ������ �������
            if (tilemap.GetTile(tilePos) == null)
            {
                Tile tile = ScriptableObject.CreateInstance<Tile>();

                // ������������� ������ � ����
                tile.sprite = playerSprite;
                tile.name = playerSprite.name;
                // ������������� ���� �� �����
                tilemap.SetTile(tilePos, tile);
            }
        }
        else if (Input.GetMouseButton(1))
        {
            // ������� ���� �� ��������� �������
            tilemap.SetTile(tilePos, null);

            
        }
    }
}



