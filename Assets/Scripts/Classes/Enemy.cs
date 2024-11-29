using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Entities/Enemy")]
public class Enemy : ScriptableObject
{
    public int ID;
    public int status;

    public string nameRus;
    public string nameEng;
    public int type;    // 0 - Ground; 1 - Air
    public int healthPoints;
    public int damage;
    public float speed;

    public int defenseKinetic;
    public int defenseThermal;
    public int defenseEM;

    public string descriptionRus;
    public string descriptionEng;

    public Dictionary<string, int> issuesPercent;
    public int treat;
    public string backgroundImageName;
    public string iconImageName;
}
