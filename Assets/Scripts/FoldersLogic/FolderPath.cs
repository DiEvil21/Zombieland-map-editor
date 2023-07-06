using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderPath : MonoBehaviour
{
    public string folder_path;

    public void setFolderPath(string path) 
    {
        folder_path = path;
    }

    public string getFolderPath() 
    {
        return folder_path;
    }
}
