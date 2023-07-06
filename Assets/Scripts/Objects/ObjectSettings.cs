using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSettings : MonoBehaviour
{
    public string spritePath;
    private bool isInteractable;
    private bool isNpc;
    private bool isHaveCustoms;




    public void SaveCollision() 
    {
        
    }

    public void SaveIntaractableStates() 
    {
        
    }

    public string GetSpritePath() 
    {
        return spritePath;
    }

    

    // сеттеры для настроек объекта
    // задает путь до использующегося спрайта
    public void setSpritePath(string path) 
    {
        spritePath = path;
    }
    // задает интерактивный ли объект, пока думаю, что это будет два состояний объекта, которые будут переключаться при взаимодействии
    // скорее всего состояния будут двумя вариациями спрайта с возможностью включить/отключить коллизию 
    public void sIsInteractable(bool interactable) 
    {
        isInteractable = interactable;
    }
    // еще одна вариация интерактивности, при взаимодействии появляется текст (в чате и облаком над головой)
    public void setIsNpc(bool npc) 
    {
        isNpc = npc;
    }
    // есть ли дочерние объекты(украшения или специальные объекты типа костра)
    public void setIsHaveCustoms(bool customs) 
    {
        isHaveCustoms = customs;
    }
}
