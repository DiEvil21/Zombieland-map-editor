using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject ObjectSaver;
    public GameObject TileSaver;
    private void Update()
    {
        // ���������, ������ �� ������� "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TileSaver.GetComponent<TileMapSaver>().SaveTileData();
            ObjectSaver.GetComponent<ObjectsSaver>().SaveObjectSettings();
            // �������� ����� ��� ������ �� ����
            QuitGame();
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        // ���� ���� �������� � ��������� Unity, ������������� ������� �������
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ���� ���� �������� � ������, ��������� ����������
            Application.Quit();
#endif
    }
}
