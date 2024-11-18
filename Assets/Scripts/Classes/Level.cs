using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Entities/Level")]
public class Level : ScriptableObject
{
    public string nameRus;
    public string nameEng;
    public int ID;
    public string descriptionRus;
    public string descriptionEng;
    public string imageName;
    public List<Level> levels;
    public int status;
}
