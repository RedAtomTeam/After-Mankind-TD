using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuTechnologyInfoSystem : MonoBehaviour
{   
    // Менеджер сохранений
    GameManager gameManager;

    // Надсистемы
    [SerializeField] GameMenuInterfaceSystem interfaceSystem;

    // Внутренние переменные
    [SerializeField] TextMeshProUGUI techName;
    [SerializeField] TextMeshProUGUI techLevel;

    // Заголовки параметров 
    [SerializeField] TextMeshProUGUI techLabelMass;
    [SerializeField] TextMeshProUGUI techLabelMaxMass;
    [SerializeField] TextMeshProUGUI techLabelHorizontalSpeed;
    [SerializeField] TextMeshProUGUI techLabelVerticalSpeed;
    [SerializeField] TextMeshProUGUI techLabelEnergy;
    [SerializeField] TextMeshProUGUI techLabelRadius;
    [SerializeField] TextMeshProUGUI techLabelDamage;
    [SerializeField] TextMeshProUGUI techLabelDamageType;
    [SerializeField] TextMeshProUGUI techLabelReload;
    [SerializeField] TextMeshProUGUI techLabelTargetType;
    [SerializeField] TextMeshProUGUI techLabelGunCount;

    // Ячейки для параметров
    [SerializeField] TextMeshProUGUI techValueMass;
    [SerializeField] TextMeshProUGUI techValueMaxMass;
    [SerializeField] TextMeshProUGUI techValueHorizontalSpeed;
    [SerializeField] TextMeshProUGUI techValueVerticalSpeed;
    [SerializeField] TextMeshProUGUI techValueEnergy;
    [SerializeField] TextMeshProUGUI techValueRadius;
    [SerializeField] TextMeshProUGUI techValueDamage;
    [SerializeField] TextMeshProUGUI techValueDamageType;
    [SerializeField] TextMeshProUGUI techValueReload;
    [SerializeField] TextMeshProUGUI techValueTargetType;
    [SerializeField] TextMeshProUGUI techValueGunCount;

    [SerializeField] TextMeshProUGUI techDescryption;
    [SerializeField] TextMeshProUGUI techCost;

    // Цвета для активных и неактивных параметров
    [SerializeField] Color activeColor;
    [SerializeField] Color passiveColor;

    // Текст кнопки 
    [SerializeField] TextMeshProUGUI learnButtonText;

    // Кнопка изучения
    [SerializeField] GameObject learn;

    // Цена и текст цены
    [SerializeField] GameObject cost;
    [SerializeField] TextMeshProUGUI costText;

    [SerializeField] GameObject obj;

    [SerializeField] RawImage techImage;

    Technology targetTech = null;

    // Загрузка менеджера сохранений
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    // Загрузка данных о технологии
    public void LoadTechInfo(Technology tech)
    {
        targetTech = tech;

        if (targetTech.imageName != "")
        {
            techImage.texture = (Texture2D)Resources.Load(targetTech.imageName);
        }

        foreach (TechnologyData technology in gameManager.playerGameData.technologies) 
        {
            if (tech.ID == technology.ID)
            {
                if (technology.level == tech.maxLevel)
                {
                    learn.SetActive(false);
                    cost.SetActive(false);
                }
                else
                {
                    learn.SetActive(true);
                    cost.SetActive(true);
                }

                if (technology.level == 0)
                {
                    learnButtonText.text = "Изучить";
                    costText.text = tech.openCost.ToString();
                }
                else 
                { 
                    learnButtonText.text = "Улучшить";
                    costText.text = (tech.levelUpCost * technology.level).ToString();
                }
                
                techLevel.text = $"{technology.level}/{tech.maxLevel}";
                break;
            }
        }

        if (tech.module != null)
        {
            techName.text = tech.module.name;
            techValueMass.text = tech.module.mass.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " кг" : " k");
            techValueMaxMass.text = tech.module.maxMass.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " кг" : " k");
            techValueHorizontalSpeed.text = tech.module.HorizontalSpeed.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " град./с." : " deg./sec.");
            techValueVerticalSpeed.text = tech.module.VerticalSpeed.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " град./с." : " deg./sec.");
            techValueEnergy.text = ((tech.type == "Power Plant" ? tech.module.Energy : "-") + " / " + (tech.type == "Power Plant" ? "-" : tech.module.Energy)) + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " кВ" : "kV");
            techValueRadius.text = tech.module.Radius.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " м" : " m");
            techValueDamage.text = tech.module.Damage.ToString();
            techValueDamageType.text = $"K: {tech.module.DamageKinetic.ToString()}%; T: {tech.module.DamageThermal.ToString()}%; E: {tech.module.DamageEm.ToString()}%;";
            techValueReload.text = tech.module.Reload.ToString() + (PlayerPrefs.GetString("Language", "Rus") == "Rus" ? " сек." : " sec.");
            

            if (tech.module.TargetType == 0)
            {
                techValueTargetType.text = "-";
            }
            if (tech.module.TargetType == 1)
            {
                techValueTargetType.text = $"{(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "земля" : "ground")}: true; {(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "воздух" : "air")}: false;";
            }
            if (tech.module.TargetType == 2)
            {
                techValueTargetType.text = $"{(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "земля" : "ground")}: false; {(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "воздух" : "air")}: true;";
            }
            if (tech.module.TargetType == 3)
            {
                techValueTargetType.text = $"{(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "земля" : "ground")}: true; {(PlayerPrefs.GetString("Language", "Rus") == "Rus" ? "воздух" : "air")}: true;";
            }

            techValueGunCount.text = tech.module.GunCount.ToString();

            techValueMass.color = (tech.type == "Platform" || tech.type == "Corps" || tech.type == "Weapon") ? activeColor : passiveColor;
            techValueMaxMass.color = (tech.type == "Platform" || tech.type == "Corps") ? activeColor : passiveColor;
            techValueHorizontalSpeed.color = tech.type == "Platform" ? activeColor : passiveColor;
            techValueVerticalSpeed.color = tech.type == "Corps" ? activeColor : passiveColor;
            techValueEnergy.color = activeColor;
            techValueRadius.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techValueDamage.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueDamageType.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueReload.color = tech.type == "Weapon" ? activeColor : passiveColor;
            techValueTargetType.color = tech.type == "Ballistic Computer" ? activeColor : passiveColor;
            techValueGunCount.color = tech.type == "Corps" ? activeColor : passiveColor;

            techLabelMass.color = tech.type == "Platform" ? activeColor : passiveColor;
            techLabelMaxMass.color = tech.type == "Corps" ? activeColor : passiveColor;
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
            techValueMass.text = "-";
            techValueMaxMass.text = "-";
            techValueHorizontalSpeed.text = "-";
            techValueVerticalSpeed.text = "-";
            techValueEnergy.text = "-";
            techValueRadius.text = "-";
            techValueDamage.text = "-";
            techValueDamageType.text = "-";
            techValueReload.text = "-";
            techValueTargetType.text = "-";
            techValueGunCount.text = "-";

            techValueMass.color = passiveColor;
            techValueMaxMass.color = passiveColor;
            techValueHorizontalSpeed.color = passiveColor;
            techValueVerticalSpeed.color = passiveColor;
            techValueEnergy.color = passiveColor;
            techValueRadius.color = passiveColor;
            techValueDamage.color = passiveColor;
            techValueDamageType.color = passiveColor;
            techValueReload.color = passiveColor;
            techValueTargetType.color = passiveColor;
            techValueGunCount.color = passiveColor;

            techLabelMass.color = passiveColor;
            techLabelMaxMass.color = passiveColor;
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

    // Функция изучения выбранной технологии
    public void LearnOrLevelUpOpenedTech()
    {
        print(targetTech.ID);
        foreach (TechnologyData technology in gameManager.playerGameData.technologies)
        {
            if (targetTech.ID == technology.ID)
            {
                print(targetTech.ID);
                if (technology.status == 1)
                {
                    if (targetTech.openCost <= gameManager.playerGameData.balanceData.Balance)
                    {
                        
                        print(targetTech.ID);
                        gameManager.playerGameData.balanceData.Balance -= targetTech.openCost;

                        technology.status = 2;
                        technology.level = 1;

                        gameManager.FullUpdateTechnologyData();
                        interfaceSystem.FullUpdateTechTree();
                        LoadTechInfo(targetTech);
                        interfaceSystem.UpdateLearnPoints(gameManager.playerGameData.balanceData.Balance);



                    }
                }
                else
                {
                    if (technology.status == 2)
                    {
                        if (targetTech.levelUpCost <= gameManager.playerGameData.balanceData.Balance)
                        {
                            gameManager.playerGameData.balanceData.Balance -= targetTech.levelUpCost;
                            technology.level += 1;
                            LoadTechInfo(targetTech);
                            interfaceSystem.UpdateLearnPoints(gameManager.playerGameData.balanceData.Balance);
                        }
                    }
                }
                break;
            }
        }
    }

    // Функция выключения камеры
    public void cameraMovementOff()
    {
        interfaceSystem.cameraMovementOff();
    }

    // Функция включения камеры
    public void cameraMovementOn()
    {
        interfaceSystem.cameraMovementOn();
    }
}
