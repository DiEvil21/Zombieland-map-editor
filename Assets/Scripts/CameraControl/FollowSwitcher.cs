using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSwitcher : MonoBehaviour
{
    public FollowPlayer followPlayerCS;
    public void switchCameraMod() 
    {
        followPlayerCS.enabled = !followPlayerCS.enabled;
    }

}
