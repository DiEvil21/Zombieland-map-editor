using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.EventSystems;



public class FollowMouse : MonoBehaviour
{
    private GameObject childSprite;
    private bool isPipetka = true;
    private bool isMirrored = false;
    public string pngPath; // ���� � ����� PSB
    private List<string> spriteVariants = new List<string>();
    // ��� ������ ��������� �� ������


    public void setPngPath(string path) 
    {
        pngPath = path;
    }
    void Start()
    {
        
        //��� ������ ������ �������� ������ ��� ����� �������
        childSprite = transform.GetChild(0).gameObject;
        string hexColor = "#32B7FF";
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            // ���������� ����� ���� ���������� SpriteRenderer
            childSprite.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Debug.LogError("Invalid color format: " + hexColor);
        }

        //������� �������� �������
        string fileName = Path.GetFileNameWithoutExtension(pngPath);
        string fileExtension = Path.GetExtension(pngPath);

        string directoryPath = Path.GetDirectoryName(pngPath);
        string[] files = Directory.GetFiles(directoryPath);
        
        
        foreach (string file in files)
        {
            if (Path.GetExtension(file).Equals(".meta", StringComparison.OrdinalIgnoreCase))
                continue;
            if (Path.GetFileName(file).Contains(fileName))
            {
                
                
                spriteVariants.Add(file);
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
    bool isCodeExecuted = false;
    int index = 0;
    void Update()
    {
        // �������� ��������� ������ F � X/Y
        bool isFKeyPressed = Input.GetKey(KeyCode.F);
        bool isXKeyPressed = Input.GetKey(KeyCode.X);
        bool isYKeyPressed = Input.GetKey(KeyCode.Y);
        bool isVKeyPressed = Input.GetKeyDown(KeyCode.V);

        if (Input.GetKeyDown(KeyCode.V) && spriteVariants.Count > 0)
        {
            //Sprite sprite = childSprite.GetComponent<SpriteRenderer>().sprite;
            // psbFilePath Sprite sprite = Resources.Load<Sprite>(finalPath);
            
            
            index = (index + 1) % spriteVariants.Count;
            Debug.Log("path: " + spriteVariants[index]);
            Sprite sprite = LoadSpriteFromFile(spriteVariants[index]);
            pngPath = spriteVariants[index];
            //���������� ����� �� �����
            Sprite adjustedSprite = Sprite.Create(sprite.texture, sprite.rect, new Vector2(0.5f, 0.1f));
            sprite = adjustedSprite;

            childSprite.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        // ��������� ������� F+X ��� F+Y
        if (isFKeyPressed && (isXKeyPressed || isYKeyPressed) && !isMirrored)
        {
            // ������� ������ ��������� �������
            Vector3 scale = transform.localScale;
            if (isXKeyPressed)
            {
                // �������������� �� ��� X
                scale.x = -scale.x;
            }
            if (isYKeyPressed)
            {
                // �������������� �� ��� Y
                scale.y = -scale.y;
            }

            // ��������� ����� ������ �������� �������
            transform.localScale = scale;

            // ������������� ���� �������������� � true
            isMirrored = true;
        }

        // ���������� ���� ��������������, ���� ������� F ��� X/Y ��������
        if (!isFKeyPressed || (!isXKeyPressed && !isYKeyPressed))
        {
            isMirrored = false;
        }
        if (Input.GetMouseButton(1)) 
        {
            Destroy(gameObject);
            //isPipetka = false;
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Destroy(gameObject);
            }
            if (isPipetka && !EventSystem.current.IsPointerOverGameObject()) 
            {
                GameObject clone = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            }
            transform.SetParent(GameObject.FindGameObjectWithTag("map").gameObject.transform);
            transform.gameObject.AddComponent<ObjectDeleter>();
            ObjectSettings objectSettings = transform.gameObject.AddComponent<ObjectSettings>();
            objectSettings.setSpritePath(pngPath);
            enabled = false;
            string hexColor = "#FFFFFF";
            Color color;
            if (ColorUtility.TryParseHtmlString(hexColor, out color))
            {
                // ���������� ����� ���� ���������� SpriteRenderer
                childSprite.GetComponent<SpriteRenderer>().color = color;
                childSprite.AddComponent<BoxCollider2D>();
            }
            else
            {
                Debug.LogError("Invalid color format: " + hexColor);
            }
        }
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (Input.GetKey(KeyCode.Y))
        {
            // ������ ����������� ������ �� ��� X
            worldPosition.x = transform.position.x;
        }
        else if (Input.GetKey(KeyCode.X))
        {
            // ������ ����������� ������ �� ��� Y
            worldPosition.y = transform.position.y;
        }


        float gridSize = 0.01f; // ������ ����� ��� ���������� (����� ������ ����� ������ ��������)

        // ��������� ������� ���������� �� ���������� ��������, �������� gridSize
        float roundedX = Mathf.Round(worldPosition.x / gridSize) * gridSize;
        float roundedY = Mathf.Round(worldPosition.y / gridSize) * gridSize;

        Vector2 roundedPosition = new Vector2(roundedX, roundedY);
        transform.position = roundedPosition;


    }











}
