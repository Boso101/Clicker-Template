using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string cashName; // What is our money called
    [SerializeField] private float cash; // how much points we got
    [SerializeField] private float cashPerClick = 1f; // How much we get per click
    [SerializeField] private float tick; // How many seconds until a tick passes
    [SerializeField] private float cashPerTick; // How much cash we get per tick

    public string CashName { get => cashName; set => cashName = value; }
    public float Cash { get => cash; set => cash = value; }
    public float CashPerClick { get => cashPerClick; set => cashPerClick = value; }
    public float Tick { get => tick; set => tick = value; }
    public float CashPerTick { get => cashPerTick; set => cashPerTick = value; }
}
