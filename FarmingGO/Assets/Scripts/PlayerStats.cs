using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public static int Money { get; private set; }

    public const string CURRENCY = "G";

    public static void Spend(int Cost)
    {
        if(Cost > Money)
        {
            Debug.Log("���� �����մϴ�");
        }
        Money -= Cost;
        UIManager.Instance.RenderPlayerStats();
    }

    public static void Earn(int Income)
    {
        Money += Income;
        UIManager.Instance.RenderPlayerStats();
    }
}

