using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransparency : MonoBehaviour
{
    private Transform playerTransform;
    public float transparencyDistance = 0.5f;

    private SpriteRenderer spriteRenderer;
    private float spriteWidth;
    private float spriteHeight;
    private GameObject childSprite;

    private void Awake()
    {
        childSprite = transform.GetChild(0).gameObject;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = childSprite.GetComponent<SpriteRenderer>();
        CalculateSpriteSize();
    }

    private void CalculateSpriteSize()
    {
        // �������� ������� �������
        spriteWidth = spriteRenderer.bounds.size.x;
        spriteHeight = spriteRenderer.bounds.size.y;
    }

    private void Update()
    {
        // ������������ ���������� �� x � �� y ����� ������� � ��������
        float distanceX = Mathf.Abs(transform.position.x - playerTransform.position.x);
        float distanceY = Mathf.Abs(transform.position.y - playerTransform.position.y);

        // ���������, ��� ����� ��������� ���� �������
        if (playerTransform.position.y > transform.position.y)
        {
            
            // ��������� ����������������, ���� ���������� �� x � �� y ������ �������� �������� �������
            if (distanceX < spriteWidth / 2f && distanceY < spriteHeight / 2f )
            {
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.4f);
                spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }
            else
            {
                //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
                spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            }
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
        }
    }
}
