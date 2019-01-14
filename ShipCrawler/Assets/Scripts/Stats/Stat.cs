using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    // Starting value
    [SerializeField]
    int baseValue;

    // List of modifiers that change the baseValue
    private List<int> modifiers = new List<int>();

    public int Getvalue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }


    // Add new modifier
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }
}
