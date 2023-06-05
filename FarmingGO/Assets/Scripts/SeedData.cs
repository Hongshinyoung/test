using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Seed")]
public class SeedData : ItemData
{
    public int daysToGrow;

    public ItemData cropToYield;

    public GameObject seeding;

    [Header("Regrowable")]

    public bool regrowable;

    public int dayToRegrow;
}
