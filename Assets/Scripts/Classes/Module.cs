using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Module", menuName = "Entities/Module")]
public class Module : ScriptableObject
{
    public string name;
    public int ID;
    public int cost;
    public string type;
    public string description;
    public int levelUpCost;
    public string imageName;
}
