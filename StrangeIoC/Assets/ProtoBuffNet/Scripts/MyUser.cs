using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

/// <summary>
/// 
/// </summary>
[ProtoContract]
public class MyUser
{
    [ProtoMember(1)]
    public int ID { get; set; }
    [ProtoMember(2)]
    public string UserName { get; set; }
    [ProtoMember(3)]
    public string PassWord { get; set; }
    [ProtoMember(4)]
    public int level { get; set; }
    [ProtoMember(5)]
    public UserType _UserType { get; set; }

     public enum UserType
    {
        Master,
        Warrior
    }
}
