using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class ObjectIconsSpawner : MonoBehaviour
{
    public GameObject ObjectIcons;
    void Start()
    {
        
    }

    public void GenerateOjectsIcons(string rootFolderPath) 
    {

        RemoveAllChildren(transform);
        List<string> fileslist = GetResourceFiles(rootFolderPath);

        foreach (string file in fileslist)
        {
            // Пропуск файлов с расширением .meta
            if (Path.GetExtension(file).Equals(".meta", StringComparison.OrdinalIgnoreCase))
                continue;
            if (!Path.GetExtension(file).Equals(".png", StringComparison.OrdinalIgnoreCase))
                continue;
            string fileName = Path.GetFileNameWithoutExtension(file);
            string folderPath = Path.GetDirectoryName(file);
            string trimmedPath = folderPath.Substring(folderPath.IndexOf("Resources") + 10);
            string finalPath = Path.Combine(trimmedPath, fileName);
            //Debug.Log("iconSpawner filePath: " + file);
            Sprite sprite = LoadSpriteFromFile(file);
            sprite.name = file;
            //нужно отправить finalPath в ObjectSettings.cs для сохранения карты
            // сначала отправим в каждую кнопку свой путь
            if (fileName.Contains("_variant_"))
            {
                //Debug.Log(fileName);
                continue;
            }
            //Debug.Log(finalPath);

            if (sprite != null)
            {
                GameObject icon = Instantiate(ObjectIcons, transform);
                //отправим иконке путь к спрайту для сохранения
                icon.GetComponent<ObjectSpawner>().setSpritePath(file);
                // Установка спрайта в компонент Image
                icon.transform.GetChild(1).GetComponent<Image>().sprite = sprite;

                icon.GetComponent<ObjectSpawner>().setName(finalPath);
                icon.GetComponent<ObjectSpawner>().setSprite(sprite);
            }
            else
            {
                Debug.LogError("Failed to load sprite from path: " + file);
            }
        }

    }
    Sprite LoadSpriteFromFile(string filePath)
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

    void RemoveAllChildren(Transform parent)
    {
        int childCount = parent.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }
    }


    public static List<string> GetResourceFiles(string folderPath)
    {
        List<string> filePaths = new List<string>();

        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
        
        foreach (string file in files)
        {
            filePaths.Add(file);
        }

        return filePaths;
    }
}
