using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeysPanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    public void panelSwitcher() 
    {
        panel.active = !panel.active;
    }
}
