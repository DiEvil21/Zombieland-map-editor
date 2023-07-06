using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private Sprite sprite; // Спрайт, который нужно назначить
    private string nameObject;
    private string SpritePath;

    public void setSpritePath(string spritePath) 
    {
        // получили путь к спрайту, можно отправлять в objectSettings.cs
        SpritePath = spritePath;
    }
    public void setSprite(Sprite Csprite)
    {
        sprite = Csprite;
        // для сортировки по Y нужен pivot внизу объекта, это вот его делаем
        Sprite adjustedSprite = Sprite.Create(sprite.texture, sprite.rect, new Vector2(0.5f, 0.1f));
        sprite = adjustedSprite;
    }

    public void setName(string name)
    {
        nameObject = name;
    }

    public void SpawnObject()
    {
        // Создание пустого игрового объекта
        GameObject newObj = new GameObject(nameObject);
        

        // Создание дочернего объекта для спрайта
        GameObject spriteObj = new GameObject("Sprite");

        // Добавление компонента SpriteRenderer на дочерний объект
        SpriteRenderer spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();

        // Проверка, что компонент SpriteRenderer существует и спрайт не является null
        if (spriteRenderer != null && sprite != null)
        {
            // Назначение спрайта на компонент SpriteRenderer
            spriteRenderer.sprite = sprite;

            // Устанавливаем родителя для дочернего объекта
            spriteObj.transform.SetParent(newObj.transform);
            // а вот и ставим сортировку по pivot
            spriteObj.GetComponent<SpriteRenderer>().spriteSortPoint = SpriteSortPoint.Pivot;
            newObj.AddComponent<SpriteTransparency>();
            newObj.AddComponent<FollowMouse>();
            newObj.GetComponent<FollowMouse>().setPngPath(SpritePath);
        }
        else
        {
            Debug.LogError("Failed to assign sprite to the object.");
        }
    }

    




}



