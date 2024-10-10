using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Entities/Enemy")]
public class Enemy : ScriptableObject
{
    public string name;
    public string type;
    public int healthPoints;
    public int damage;
    public float speed;
    public List<string> issues;
    public int treat;
    public string imageName;
}
