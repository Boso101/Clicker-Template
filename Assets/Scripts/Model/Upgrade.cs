using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected string upgradeName;
    [SerializeField] protected string upgradeDescription;
    [SerializeField] protected float upgradeCost;

    public float UpgradeCost { get => upgradeCost; set => upgradeCost = value; }
    public string UpgradeName { get => upgradeName; set => upgradeName = value; }
    public string UpgradeDescription { get => upgradeDescription; set => upgradeDescription = value; }


    public bool CanAfford()
    {

    }

    public void Purchase()
    {

    }

}
