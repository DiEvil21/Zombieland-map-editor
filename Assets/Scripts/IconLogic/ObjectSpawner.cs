using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private Sprite sprite; // ������, ������� ����� ���������
    private string nameObject;
    private string SpritePath;

    public void setSpritePath(string spritePath) 
    {
        // �������� ���� � �������, ����� ���������� � objectSettings.cs
        SpritePath = spritePath;
    }
    public void setSprite(Sprite Csprite)
    {
        sprite = Csprite;
        // ��� ���������� �� Y ����� pivot ����� �������, ��� ��� ��� ������
        Sprite adjustedSprite = Sprite.Create(sprite.texture, sprite.rect, new Vector2(0.5f, 0.1f));
        sprite = adjustedSprite;
    }

    public void setName(string name)
    {
        nameObject = name;
    }

    public void SpawnObject()
    {
        // �������� ������� �������� �������
        GameObject newObj = new GameObject(nameObject);
        

        // �������� ��������� ������� ��� �������
        GameObject spriteObj = new GameObject("Sprite");

        // ���������� ���������� SpriteRenderer �� �������� ������
        SpriteRenderer spriteRenderer = spriteObj.AddComponent<SpriteRenderer>();

        // ��������, ��� ��������� SpriteRenderer ���������� � ������ �� �������� null
        if (spriteRenderer != null && sprite != null)
        {
            // ���������� ������� �� ��������� SpriteRenderer
            spriteRenderer.sprite = sprite;

            // ������������� �������� ��� ��������� �������
            spriteObj.transform.SetParent(newObj.transform);
            // � ��� � ������ ���������� �� pivot
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



