using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlossaryEnemyInfoParametrsSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Type_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI HealthPoint_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI Kinetic_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI Thermal_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI EM_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI Speed_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI Damage_ValueTMP_Obj;
    [SerializeField] private TextMeshProUGUI Treat_ValueTMP_Obj;

    public void SetEnemiesParametrs(Enemy enemySO)
    {
        Type_ValueTMP_Obj.text = enemySO.type;
        HealthPoint_ValueTMP_Obj.text = enemySO.healthPoints.ToString();
        Kinetic_ValueTMP_Obj.text = enemySO.defenseKinetic.ToString();
        Thermal_ValueTMP_Obj.text = enemySO.defenseThermal.ToString();
        EM_ValueTMP_Obj.text = enemySO.defenseEM.ToString();
        Speed_ValueTMP_Obj.text = enemySO.speed.ToString();
        Damage_ValueTMP_Obj.text = enemySO.damage.ToString();
        Treat_ValueTMP_Obj.text = enemySO.treat.ToString();
    }
}
