using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Save", menuName = "Entities/Save")]
public class Save : ScriptableObject
{
    public string name;
    public string data;
    public string time;
    public List<InfoAboutTechnology> technologiesData;
    public List<InfoAboutLevel> levelsData;
    public int balance;
}

public struct InfoAboutTechnology
{
    public string name;
    public int status;
    public int level;
}

public struct InfoAboutLevel
{
    public string name;
    public int status;
}
