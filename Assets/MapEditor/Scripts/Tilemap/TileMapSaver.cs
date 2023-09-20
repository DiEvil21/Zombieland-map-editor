using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Text;
using System;

public class TileMapSaver : MonoBehaviour
{
    [System.Serializable]
    public class TileData
    {
        public string name;
        public Vector3Int position;
    }

    public Tilemap tilemap;

    public void Start()
    {
        LoadTileData();
    }
    // Save tile data to JSON
    public void SaveTileData()
    {
        StringBuilder stringBuilder = new StringBuilder();
        List<TileData> tileDataList = new List<TileData>();
        string data = null;
        foreach (Vector3Int cellPosition in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(cellPosition);

            if (tile != null)
            {
                TileData tileData = new TileData();
                tileData.name = tile.name;
                tileData.position = cellPosition;
                
                data += stringBuilder.AppendFormat("%@#$% {0}%%%%% {1} %@#$%", tileData.name, tileData.position).ToString();
                //Debug.Log(data);
            }
        }
        PlayerPrefs.SetString("TileData", data);
        PlayerPrefs.Save();

    }

    public void LoadTileData()
    {
        if (PlayerPrefs.HasKey("TileData"))
        {
            string data = PlayerPrefs.GetString("TileData");

            // Разделите строку данных на отдельные записи
            string[] records = data.Split(new[] { "%@#$%" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string record in records)
            {
                // Разделите каждую запись на tileData.name и tileData.position
                string[] parts = record.Split(new[] { "%%%%%" }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    TileData tileData = new TileData();
                    tileData.name = parts[0];
                    tileData.position = ParseVector3Int(parts[1]);
                    spawnTile(tileData.name, tileData.position);
                    // Используйте tileData.name и tileData.position по вашему усмотрению
                    //Debug.Log("Name: " + tileData.name + ", Position: " + tileData.position);
                }
            }
        }
    }
    // спавним сохраненные тайлы передается путь до спрайта(он записывается в имя тайла ) и его координаты
    public void spawnTile(string name, Vector3Int pos)
    {
        Sprite tileSprite = LoadSpriteFromFile(name);
        Tile tile = ScriptableObject.CreateInstance<Tile>();

        // Устанавливаем спрайт в тайл
        tile.sprite = tileSprite;
        tile.name = name;
        // Устанавливаем тайл на карте
        tilemap.SetTile(pos, tile);
    }
    // Вспомогательный метод для разбора строки в Vector3Int
    private Vector3Int ParseVector3Int(string vectorString)
    {
        vectorString = vectorString.Replace("(", "").Replace(")", "");
        //Debug.Log(vectorString);
        string[] parts = vectorString.Split(',');

        if (parts.Length == 3)
        {
            int x = int.Parse(parts[0].Trim());
            int y = int.Parse(parts[1].Trim());
            int z = int.Parse(parts[2].Trim());

            return new Vector3Int(x, y, z);
        }

        return Vector3Int.zero;
    }

    Sprite LoadSpriteFromFile(string filePath)
    {
        //Почему-то один / перевернулся по пути, возвращаем на место этого предателя
        // плюс в начале строки пробел, убираем еще одного предателя
        filePath = filePath.Replace("\\", "/").Replace(" ", "");
        Texture2D texture = new Texture2D(2, 2);
        texture.filterMode = FilterMode.Point;
        byte[] data = File.ReadAllBytes(filePath);
        //Debug.Log(filePath);
        if (texture.LoadImage(data))
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            return sprite;
        }
        return null;
    }
}
