using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FolderSpawner : MonoBehaviour
{
    public GameObject folder_ui_prefab;
    public GameObject resourcesFolderLister;

    void Start()
    {
        StartCoroutine(SpawnFoldersUI());
    }

    private IEnumerator SpawnFoldersUI()
    {
        ResourceFolderLister folderLister = resourcesFolderLister.GetComponent<ResourceFolderLister>();
        yield return new WaitUntil(() => folderLister.IsFolderListReady);

        foreach (string folder in folderLister.folderList)
        {
            string folderName = Path.GetFileName(Path.GetFileName(folder));
            if (folderName != "Tiles") 
            {
                GameObject folder_object = Instantiate(folder_ui_prefab, transform);
                folder_object.GetComponent<FolderPath>().setFolderPath(folder);
                folder_object.transform.GetChild(0).GetComponent<Text>().text = folderName;
            }
            
        }
        transform.GetChild(0).GetComponent<SelfClick>().OnClick();
    }
}
