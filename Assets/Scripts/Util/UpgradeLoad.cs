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
        string targDir = Path.Combine(Application.streamingAssetsPath, "Upgrades");
        string[] directores = Directory.GetDirectories(targDir);
        Upgrade spawned;
        
        foreach(string file in directores)
        {
            spawned = Instantiate(prefab, buttonHolder);
            spawned.LoadJson(file + "/");
        }
    }
}
