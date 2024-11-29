using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlossaryEnemyInfoParametrsSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Type_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI HealthPoint_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI Kinetic_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI Thermal_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI EM_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI Speed_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI Damage_ValueTMP_Obj;
    [SerializeField] TextMeshProUGUI Treat_ValueTMP_Obj;

    public void SetEnemiesParametrs(Enemy enemySO)
    {
        string type = "Error";
        
        if (enemySO.type == 0)
        {
            type = PlayerPrefs.GetString("Language") == "�������" ? "��������" : "Ground";
        }
        if (enemySO.type == 1)
        {
            type = PlayerPrefs.GetString("Language") == "�������" ? "���������" : "Air";
        }

        Type_ValueTMP_Obj.text = type;
        HealthPoint_ValueTMP_Obj.text = enemySO.healthPoints.ToString();
        Kinetic_ValueTMP_Obj.text = enemySO.defenseKinetic.ToString();
        Thermal_ValueTMP_Obj.text = enemySO.defenseThermal.ToString();
        EM_ValueTMP_Obj.text = enemySO.defenseEM.ToString();
        Speed_ValueTMP_Obj.text = enemySO.speed.ToString();
        Damage_ValueTMP_Obj.text = enemySO.damage.ToString();
        Treat_ValueTMP_Obj.text = enemySO.treat.ToString();
    }
}
