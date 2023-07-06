using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfClick : MonoBehaviour
{
    private Button button;
    //������ ���������� ��� ����, ����� ������� �� ��������������� ������
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
        // ���������� ������ ��������������� ���������
        string path = GetComponent<FolderPath>().getFolderPath();
        GameObject objectsPanel = GameObject.FindGameObjectWithTag("ui_objects_panel").gameObject;
        objectsPanel.GetComponent<ObjectIconsSpawner>().GenerateOjectsIcons(path);
    }
}
