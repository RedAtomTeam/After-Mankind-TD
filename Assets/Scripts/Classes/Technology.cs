using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Technology", menuName = "Entities/Technology")]
public class Technology : ScriptableObject
{
    public string name;
    public string type;
    public string description;
    public string moduleName;
    public int openCost;
    public int maxLevel;
    public int levelUpCost;
}
