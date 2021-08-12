using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using System;

public class Upgrade : MonoBehaviour, IComparable
{
    public class UpgradeEvent : UnityEvent<PlayerData> { }

    protected Button btn;
    protected Text text;

    [SerializeField] protected string upgradeName;
    [SerializeField] protected string upgradeDescription;
    [SerializeField] protected float upgradeCost;
    [SerializeField] protected float cooldown;

    #region Specific Stats
    [SerializeField] private float cashPerClickIncrease; // Does this increase player click value
    [SerializeField] private float cashPerTickIncrease; // Does this incraese player automation value

    #endregion

    public UpgradeEvent OnPurchase = new UpgradeEvent();
    public float UpgradeCost { get => upgradeCost; set => upgradeCost = value; }
    public string UpgradeName { get => upgradeName; set => upgradeName = value; }
    public string UpgradeDescription { get => upgradeDescription; set => upgradeDescription = value; }
    public float CashPerClickIncrease { get => cashPerClickIncrease; set => cashPerClickIncrease = value; }
    public float CashPerTickIncrease { get => cashPerTickIncrease; set => cashPerTickIncrease = value; }
    protected PlayerData player;


    private void Awake()
    {
        btn = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        player = GameObject.FindObjectOfType<PlayerData>();
    }

    public bool CanAfford()
    {
        return player.Cash >= upgradeCost || player.BillionAmount > 0;
    }

    public void Purchase()
    {
        if(CanAfford())
        {
        if(player.BillionAmount > 0)
            {
                //Use billion backup
                player.BillionAmount--;
                player.Cash = PlayerData.MAX_INT - upgradeCost;

            }
        else
            {
                player.Cash -= upgradeCost;

            }



        player.CashPerClick += CashPerClickIncrease;
        player.CashPerTick += CashPerClickIncrease;


        StartCoroutine("ResetCD");
        }

    }

    public IEnumerator ResetCD()
    {
        btn.interactable = false;
        yield return new WaitForSeconds(cooldown);
        btn.interactable = true;
    }
    
    public void LoadJson(string dir)
    {
   
      
         try
        {

            JsonUtility.FromJsonOverwrite(File.ReadAllText(dir), this);
        }
        catch
        {
            Debug.LogError("Something went wrong reading the directory");
        }



        UpdateVisual();

    }


    [ContextMenu("Save")]
    public void SaveJson()
    {
        string file = JsonUtility.ToJson(this, true);
        string dir = Path.Combine(Application.streamingAssetsPath, $"Upgrades/{upgradeName}.json");
        File.WriteAllText(dir, file);
    }

    public void UpdateVisual()
    {
        text.text = upgradeCost.ToString("C0") + " " + upgradeName;
    }

    private void Update()
    {
        if (!CanAfford()) { btn.interactable = false; }
        else
            btn.interactable = true;
    }

    public int CompareTo(object obj)
    {
        Upgrade other = (Upgrade)obj;

        if (other.upgradeCost < upgradeCost) { return -1; }
        else if (other.upgradeCost > upgradeCost) { return 1; }
        return 0;
    }

}
