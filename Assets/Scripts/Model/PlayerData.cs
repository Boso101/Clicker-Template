using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string cashName = "Money"; // What is our money called
    [SerializeField] private float cash = 0; // how much points we got
    [SerializeField] private float cashPerClick = 1f; // How much we get per click
    [SerializeField] private float tick= 1; // How many seconds until a tick passes
    [SerializeField] private float cashPerTick= 1; // How much cash we get per tick

    [System.NonSerialized] public UIManager ui;
    protected float tickCounter;


    public string CashName { get => cashName; set => cashName = value; }
    public float Cash
    {
        get => cash;

        set
        {
            cash = value;
            ui.UpdateCashAmount(Cash);
        }
    }
    public float CashPerClick { get => cashPerClick; set => cashPerClick = value; }
    public float Tick { get => tick; set => tick = value; }
    public float CashPerTick { get => cashPerTick; set => cashPerTick = value; }


    [ContextMenu("Save")]

    public void SaveData()
    {
        string file = JsonUtility.ToJson(this, true);
        string dir = Path.Combine(Application.streamingAssetsPath, "PlayerData/data.json");
        File.WriteAllText(dir, file);
    }
    private void Awake()
    {
        ui = GameObject.FindObjectOfType<UIManager>();
        LoadData(Application.streamingAssetsPath + "/PlayerData/" + "data.json");
        ui.UpdateCashAmount(cash);
        ui.UpdateCashName(cashName);
    }

    public void LoadData(string dir)
    {
        try
        {

            JsonUtility.FromJsonOverwrite(File.ReadAllText(dir), this);
        }
        catch
        {
            Debug.LogError("Something went wrong reading the directory");
        }
    }

    private void OnDisable()
    {
        SaveData();
    }

    public void GainCash()
    {
        Cash += cashPerClick;
       
    }


    private void Start()
    {
        tickCounter = tick;
    }

    private void Update()
    {
        tickCounter -= Time.deltaTime;
        if(tickCounter <= 0)
        {
            Cash += cashPerTick;
            tickCounter = tick;
        }
    }

}
