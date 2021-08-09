using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class Upgrade : MonoBehaviour
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


    private void Awake()
    {
        btn = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        OnPurchase.AddListener(Purchase);
    }

    public bool CanAfford(PlayerData player)
    {
        return player.Cash >= upgradeCost;
    }

    public void Purchase(PlayerData data)
    {
        if(CanAfford(data))
        {

        data.CashPerClick += CashPerClickIncrease;
        data.CashPerTick += CashPerClickIncrease;
        data.Cash -= upgradeCost;
        StartCoroutine("RestCD");
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
        
    }

}
