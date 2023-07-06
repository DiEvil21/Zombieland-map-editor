using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject ObjectSaver;
    public GameObject TileSaver;
    private void Update()
    {
        // Проверяем, нажата ли клавиша "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TileSaver.GetComponent<TileMapSaver>().SaveTileData();
            ObjectSaver.GetComponent<ObjectsSaver>().SaveObjectSettings();
            // Вызываем метод для выхода из игры
            QuitGame();
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        // Если игра запущена в редакторе Unity, останавливаем игровой процесс
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Если игра запущена в сборке, завершаем приложение
            Application.Quit();
#endif
    }
}
