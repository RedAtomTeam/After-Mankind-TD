using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Module", menuName = "Entities/Module")]
public class Module : ScriptableObject
{
    public string nameEng;
    public string nameRus;
    public int ID;
    public int cost;
    public string type;
    public string descriptionEng;
    public string descriptionRus;
    public int levelUpCost;
    public string imageName;

    public float mass;
    public float maxMass;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Energy;
    public float Radius;
    public float Damage;

    public float DamageKinetic;
    public float DamageThermal;
    public float DamageEm;

    public float Reload;
    public float TargetType;
    public float GunCount;
}
