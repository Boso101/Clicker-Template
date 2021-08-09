using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UpgradeLoad : MonoBehaviour
{
    [SerializeField] protected Upgrade prefab;
    [SerializeField] protected Transform buttonHolder;

    private void Awake()
    {
        //Load
        LoadAllUpgrades();
    }
    

    public void LoadAllUpgrades()
    {
        string targDir = Application.streamingAssetsPath + "/Upgrades";
        Upgrade spawned;
        
        foreach(string file in Directory.GetFiles(targDir, "*.json"))
        {
            string fName = Path.GetFileName(file);
        spawned = Instantiate(prefab, buttonHolder);
        spawned.LoadJson(targDir + "/" + fName);
        }
    }
}
