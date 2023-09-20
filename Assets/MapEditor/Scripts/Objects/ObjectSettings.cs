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

    

    // ������� ��� �������� �������
    // ������ ���� �� ��������������� �������
    public void setSpritePath(string path) 
    {
        spritePath = path;
    }
    // ������ ������������� �� ������, ���� �����, ��� ��� ����� ��� ��������� �������, ������� ����� ������������� ��� ��������������
    // ������ ����� ��������� ����� ����� ���������� ������� � ������������ ��������/��������� �������� 
    public void sIsInteractable(bool interactable) 
    {
        isInteractable = interactable;
    }
    // ��� ���� �������� ���������������, ��� �������������� ���������� ����� (� ���� � ������� ��� �������)
    public void setIsNpc(bool npc) 
    {
        isNpc = npc;
    }
    // ���� �� �������� �������(��������� ��� ����������� ������� ���� ������)
    public void setIsHaveCustoms(bool customs) 
    {
        isHaveCustoms = customs;
    }
}
