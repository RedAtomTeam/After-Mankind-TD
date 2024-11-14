using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuTechnologyInfoSystem : MonoBehaviour
{
    private GameManager gameManager;

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

    [SerializeField] private Color activeColor;
    [SerializeField] private Color passiveColor;

    [SerializeField] private GameObject obj;

    private Technology targetTech = null;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void LoadTechInfo(Technology tech)
    {
        targetTech = tech;

        foreach (TechnologyData technology in gameManager.playerGameData.technologies) 
        {
            if (tech.ID == technology.ID)
            {
                techLevel.text = $"{technology.level}/{tech.maxLevel}";
                break;
            }
        }

        if (tech.module != null)
        {
            techName.text = tech.module.name;
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


            techValuePlatformMass.color = tech.type == "Platform" ? activeColor : passiveColor;
            techValueCorpsMass.color = tech.type == "Corps" ? activeColor : passiveColor;
            techValueHorizontalSpeed.color = tech.type == "Platform" ? activeColor : passiveColor;
            techValueVerticalSpeed.color = tech.type == "Platform" ? activeColor : passiveColor;
            techValueEnergy.color = activeColor;
            techValueRadius.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techValueDamage.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueDamageType.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueReload.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueTargetType.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techValueGunCount.color = tech.type == "Corps" ? activeColor : passiveColor;

            techLabelPlatformMass.color = tech.type == "Platform" ? activeColor : passiveColor;
            techLabelCorpsMass.color = tech.type == "Corps" ? activeColor : passiveColor;
            techLabelHorizontalSpeed.color = tech.type == "Platform" ? activeColor : passiveColor;
            techLabelVerticalSpeed.color = tech.type == "Platform" ? activeColor : passiveColor;
            techLabelEnergy.color = activeColor;
            techLabelRadius.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techLabelDamage.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techLabelDamageType.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techLabelReload.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techLabelTargetType.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techLabelGunCount.color = tech.type == "Corps" ? activeColor : passiveColor;

            switch (tech.type)
            {
                case "Weapon":

                    break;
                case "Main Computer":
                    break;
                case "Ballistic Computer":
                    break;
                case "Power Plant":
                    break;
                case "Corps":
                    break;
                case "Platform":
                    break;
            }
        }
        else
        {
            techName.text = tech.name;
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

            techValuePlatformMass.color = passiveColor;
            techValueCorpsMass.color = passiveColor;
            techValueHorizontalSpeed.color = passiveColor;
            techValueVerticalSpeed.color = passiveColor;
            techValueEnergy.color = passiveColor;
            techValueRadius.color = passiveColor;
            techValueDamage.color = passiveColor;
            techValueDamageType.color = passiveColor;
            techValueReload.color = passiveColor;
            techValueTargetType.color = passiveColor;
            techValueGunCount.color = passiveColor;

            techLabelPlatformMass.color = passiveColor;
            techLabelCorpsMass.color = passiveColor;
            techLabelHorizontalSpeed.color = passiveColor;
            techLabelVerticalSpeed.color = passiveColor;
            techLabelEnergy.color = passiveColor;
            techLabelRadius.color = passiveColor;
            techLabelDamage.color = passiveColor;
            techLabelDamageType.color = passiveColor;
            techLabelReload.color = passiveColor;
            techLabelTargetType.color = passiveColor;
            techLabelGunCount.color = passiveColor;

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
