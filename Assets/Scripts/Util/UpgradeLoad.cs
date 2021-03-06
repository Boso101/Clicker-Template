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
        List<Upgrade> upgrades = new List<Upgrade>();
        Upgrade spawned;

        foreach(string file in Directory.GetFiles(targDir, "*.json"))
        {
        string fName = Path.GetFileName(file);
        spawned = Instantiate(prefab, buttonHolder);
        spawned.LoadJson(targDir + "/" + fName);
        upgrades.Add(spawned);
        
        }

        upgrades.Sort();
        upgrades.Reverse();
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgrades[i].transform.SetSiblingIndex(i);
        }
        
    }
}
