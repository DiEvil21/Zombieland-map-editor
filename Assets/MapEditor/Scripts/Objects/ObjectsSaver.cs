using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
public class ObjectsSaver : MonoBehaviour
{
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        LoadObjectSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveObjectSettings()
    {
        StringBuilder stringBuilder = new StringBuilder();
        List<GameObject> objectList = new List<GameObject>();
        foreach (Transform child in map.transform)
        {
            GameObject obj = child.gameObject;
            ObjectSettings objSettings = obj.GetComponent<ObjectSettings>();
            if (objSettings != null)
            {
                string spritePath = objSettings.GetSpritePath();
                Vector2 position = obj.transform.position;

                stringBuilder.AppendFormat("%@#$%{0}%%%%%{1} %@#$%", spritePath, position).AppendLine();
            }
        }
        PlayerPrefs.SetString("ObjectSettings", stringBuilder.ToString());
        PlayerPrefs.Save();
    }

    // Load object settings from PlayerPrefs
    public void LoadObjectSettings()
    {
        if (PlayerPrefs.HasKey("ObjectSettings"))
        {
            string data = PlayerPrefs.GetString("ObjectSettings");

            // Разделите строку данных на отдельные записи
            string[] records = data.Split(new[] { "%@#$%" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string record in records)
            {
                // Разделите каждую запись на spritePath и position
                string[] parts = record.Split(new[] { "%%%%%" }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    string spritePath = parts[0];
                    Vector2 position = ParseVector2(parts[1]);

                    // Создайте объект с использованием spritePath и position
                    CreateObject(spritePath, position);
                }
            }
        }
    }


    private void CreateObject(string spritePath, Vector2 position)
    {
        // Загрузите спрайт из указанного пути
        Sprite sprite = LoadSpriteFromFile(spritePath);

        // Создайте новый объект
        GameObject newObj = new GameObject(spritePath);

        // Создайте дочерний объект для спрайта
        GameObject spriteObj = new GameObject("Sprite");

        // Добавьте компонент SpriteRenderer на дочерний объект
        SpriteRenderer spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();

        // Проверьте, что компонент SpriteRenderer существует и спрайт не является null
        if (spriteRenderer != null && sprite != null)
        {
            sprite = Sprite.Create(sprite.texture, sprite.rect, new Vector2(0.5f, 0.1f));
            // Назначьте спрайт на компонент SpriteRenderer
            spriteRenderer.sprite = sprite;

            // Установите родителя для дочернего объекта
            spriteObj.transform.SetParent(newObj.transform);
            spriteObj.GetComponent<SpriteRenderer>().spriteSortPoint = SpriteSortPoint.Pivot;
            
            // Установите позицию объекта
            newObj.transform.position = position;
            // Добавьте необходимые компоненты и настройки объекта
            newObj.AddComponent<ObjectSettings>().setSpritePath(spritePath);
            newObj.transform.SetParent(map.transform);
            newObj.AddComponent<ObjectDeleter>();
            //newObj.AddComponent<SpriteTransparency>();
            //newObj.AddComponent<FollowMouse>();
            //newObj.GetComponent<FollowMouse>().setPngPath(spritePath);
        }
        else
        {
            Debug.LogError("Failed to create object: " + spritePath);
        }
    }



    private Sprite LoadSpriteFromFile(string filePath)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.filterMode = FilterMode.Point;
        byte[] data = File.ReadAllBytes(filePath);
        if (texture.LoadImage(data))
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            return sprite;
        }
        return null;
    }

    private Vector2 ParseVector2(string vectorString)
    {
        vectorString = vectorString.Replace("(", "").Replace(")", "").Replace(" ", "");
        string[] parts = vectorString.Split(',');
        Debug.Log("    :" + parts[0]+ ":   ");
        if (parts.Length == 2)
        {
            float x = float.Parse(parts[0].Replace(".",",").Trim() );
            float y = float.Parse(parts[1].Replace(".", ",").Trim());

            return new Vector2(x, y);
        }

        return Vector2.zero;
    }




}
