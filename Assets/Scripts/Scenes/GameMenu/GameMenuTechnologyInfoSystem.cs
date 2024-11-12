using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuTechnologyInfoSystem : MonoBehaviour
{
    [SerializeField] private GameMenuInterfaceSystem interfaceSystem;

    [SerializeField] private TextMeshProUGUI techName;
    [SerializeField] private TextMeshProUGUI techLevel;

    [SerializeField] private TextMeshProUGUI techLabelPlatformMass;
    [SerializeField] private TextMeshProUGUI techLabelCorpsMass;
    [SerializeField] private TextMeshProUGUI techLabelHorizontalSpeed;
    [SerializeField] private TextMeshProUGUI techLabelVerticalSpeed;
    [SerializeField] private TextMeshProUGUI techLabelEnergy;
    [SerializeField] private TextMeshProUGUI techLabelRadius;
    [SerializeField] private TextMeshProUGUI techLabelDamage;
    [SerializeField] private TextMeshProUGUI techLabelDamageType;
    [SerializeField] private TextMeshProUGUI techLabelReload;
    [SerializeField] private TextMeshProUGUI techLabelTargetType;
    [SerializeField] private TextMeshProUGUI techLabelGunCount;

    [SerializeField] private TextMeshProUGUI techValuePlatformMass;
    [SerializeField] private TextMeshProUGUI techValueCorpsMass;
    [SerializeField] private TextMeshProUGUI techValueHorizontalSpeed;
    [SerializeField] private TextMeshProUGUI techValueVerticalSpeed;
    [SerializeField] private TextMeshProUGUI techValueEnergy;
    [SerializeField] private TextMeshProUGUI techValueRadius;
    [SerializeField] private TextMeshProUGUI techValueDamage;
    [SerializeField] private TextMeshProUGUI techValueDamageType;
    [SerializeField] private TextMeshProUGUI techValueReload;
    [SerializeField] private TextMeshProUGUI techValueTargetType;
    [SerializeField] private TextMeshProUGUI techValueGunCount;

    [SerializeField] private TextMeshProUGUI techDescryption;
    [SerializeField] private TextMeshProUGUI techCost;

    [SerializeField] private GameObject obj;

    private Technology targetTech = null;

    public void LoadTechInfo(Technology tech)
    {
        targetTech = tech;

        if (tech.module != null)
        {
            techValuePlatformMass.text = tech.module.PlatformMass.ToString();
            techValueCorpsMass.text = tech.module.CorpsMass.ToString();
            techValueHorizontalSpeed.text = tech.module.HorizontalSpeed.ToString();
            techValueVerticalSpeed.text = tech.module.VerticalSpeed.ToString();
            techValueEnergy.text = tech.module.Energy.ToString();
            techValueRadius.text = tech.module.Radius.ToString();
            techValueDamage.text = tech.module.Damage.ToString();
            techValueDamageType.text = $"K: {tech.module.DamageKinetic.ToString()}%; T: {tech.module.DamageThermal.ToString()}%; E: {tech.module.DamageEm.ToString()}%;";
            techValueReload.text = tech.module.Reload.ToString();
            techValueTargetType.text = tech.module.TargetType.ToString();
            techValueGunCount.text = tech.module.GunCount.ToString();
        }
        else
        {
            techValuePlatformMass.text = "-";
            techValueCorpsMass.text = "-";
            techValueHorizontalSpeed.text = "-";
            techValueVerticalSpeed.text = "-";
            techValueEnergy.text = "-";
            techValueRadius.text = "-";
            techValueDamage.text = "-";
            techValueDamageType.text = "-";
            techValueReload.text = "-";
            techValueTargetType.text = "-";
            techValueGunCount.text = "-";
        }

        cameraMovementOff();

        obj.SetActive(true);
    }

    public void LearnOpenedTech()
    {

    }

    public void cameraMovementOff()
    {
        interfaceSystem.cameraMovementOff();
    }

    public void cameraMovementOn()
    {
        interfaceSystem.cameraMovementOn();
    }
}
