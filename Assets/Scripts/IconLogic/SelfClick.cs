using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfClick : MonoBehaviour
{
    private Button button;
    //скрипт существует для того, чтобы кликать на сгенерированные иконки
    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        //Debug.Log("Clicked on self");
        // генерируем иконки соответствующей категории
        string path = GetComponent<FolderPath>().getFolderPath();
        GameObject objectsPanel = GameObject.FindGameObjectWithTag("ui_objects_panel").gameObject;
        objectsPanel.GetComponent<ObjectIconsSpawner>().GenerateOjectsIcons(path);
    }
}
