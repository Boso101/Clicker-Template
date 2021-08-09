using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text cashName;
    public Text cashAmount;
    public Image image;





    public void UpdateCashName(string value)
    {
        cashName.text = value;
    }

    public void UpdateCashAmount(float amount)
    {
        cashAmount.text = amount.ToString("C");
    }

}
