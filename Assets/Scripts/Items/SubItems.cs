using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    public Text subItemText;
    public int subItemAmount;

    public static SubItems instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        subItemAmount = PlayerPrefs.GetInt("arrowsAmount", 0);
        subItemText.text = "x " + subItemAmount.ToString();
    }

    public void subItem(int newSubItemAmount)
    {
        subItemAmount += newSubItemAmount;
        DataManager.instance.arrowsData(subItemAmount);
        subItemText.text = "x " + subItemAmount.ToString();
    }
}
