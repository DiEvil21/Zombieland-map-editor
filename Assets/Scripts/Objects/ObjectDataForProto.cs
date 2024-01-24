using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System;
[Serializable]
[ProtoContract]

public class ObjectsProto
{
    [ProtoMember(1)]   
    public string MapName;
    [ProtoMember(2)]
    public ObjectProto[] objectProto;
}
[Serializable]
[ProtoContract]
public class ObjectProto 
{
    [ProtoMember(1)]
    public string spritePath;
    [ProtoMember(2)]
    public Vector2 position;
    [ProtoMember(3)]
    private bool isInteractable;
    [ProtoMember(4)]
    private bool isNpc;
    [ProtoMember(5)]
    private bool isHaveCustoms;
}
