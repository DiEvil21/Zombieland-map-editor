using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class TileFolderLister : MonoBehaviour
{
    
    public GameObject ObjectIcons;
    // когда стал видымым генерируем список с иконками
    private void OnEnable()
    {
        GenerateOjectsIcons(Application.dataPath + "/Resources/Tiles");
    }
    // вызывается из SelfClick.cs (висит на кнопках папок - категорий)
    public void GenerateOjectsIcons(string rootFolderPath)
    {
        // очищаем от иконок предыдущей категории
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
            /*string trimmedPath = folderPath.Substring(folderPath.IndexOf("Resources") + 10);
            string finalPath = Path.Combine(trimmedPath, fileName);
            //Sprite sprite = Resources.Load<Sprite>(finalPath);*/
            Sprite sprite = LoadSpriteFromFile(file);
            sprite.name = file;

            if (sprite != null)
            {
                GameObject icon = Instantiate(ObjectIcons, transform);

                // Установка спрайта в компонент Image
                icon.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
                icon.AddComponent<SelfClickTile>();
                
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
