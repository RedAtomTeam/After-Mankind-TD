using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Entities/Level")]
public class Level : ScriptableObject
{
    public string name;
    public int ID;
    public string description;
    public string imageName;
    public List<Level> levels;
}
