using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectDeleter : MonoBehaviour
{
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Default");
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D collider = transform.gameObject.AddComponent<BoxCollider2D>();

        // Получить границы спрайта
        Bounds spriteBounds = spriteRenderer.bounds;

        // Установить размеры коллайдера
        collider.size = spriteBounds.size;
        collider.offset = spriteBounds.center - transform.position;
        //collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,layerMask);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("btn work");
                
                Destroy(gameObject);
            }
        }
    }
}
