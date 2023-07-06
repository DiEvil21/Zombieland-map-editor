using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class ResourceFolderLister : MonoBehaviour
{
    private string resourceFolderPath = "Resources";
    public List<string> folderList;



    public bool IsFolderListReady { get; private set; }

    

    private IEnumerator GetResourceFoldersAsync()
    {
        folderList = GetResourceFolders(resourceFolderPath);
        foreach (string folder in folderList)
        {
            //Debug.Log("Folder: " + folder);
        }

        IsFolderListReady = true;

        yield return null;
    }




    private void Start()
    {
        StartCoroutine(GetResourceFoldersAsync());
        folderList = GetResourceFolders(resourceFolderPath);
        foreach (string folder in folderList)
        {
            //Debug.Log("Folder: " + folder);
        }

        
    }

    private List<string> GetResourceFolders(string rootFolderPath)
    {
        List<string> folderList = new List<string>();

        string[] folderPaths = Directory.GetDirectories(Application.dataPath + "/" + rootFolderPath, "*", SearchOption.AllDirectories);
        foreach (string folderPath in folderPaths)
        {
            string relativeFolderPath = folderPath.Replace(Application.dataPath + "/" + rootFolderPath + "/", "");
            folderList.Add(relativeFolderPath);
        }

        return folderList;
    }

    private List<string> GetResourceFiles(string rootFolderPath)
    {
        List<string> fileList = new List<string>();

        string[] filePaths = Directory.GetFiles(Application.dataPath + "/" + rootFolderPath, "*", SearchOption.AllDirectories);
        foreach (string filePath in filePaths)
        {
            string relativeFilePath = filePath.Replace(Application.dataPath + "/" + rootFolderPath + "/", "");
            fileList.Add(relativeFilePath);
        }

        return fileList;
    }


}




