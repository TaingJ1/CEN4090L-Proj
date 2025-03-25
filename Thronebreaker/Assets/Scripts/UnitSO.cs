using NUnit.Framework.Internal;
using UnityEngine;

// This is a script that defines the Scriptable Object that encommpasses a Unit object, meaning these are templates for stats and art that each Unit made will have by default
// We can likely use more scripts to actually spawn more units in the Game Manager script

[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
public class UnitSO : ScriptableObject
{
    public string unitName;
    public int unitID;
    public int maxHealth;
    public int maxMana;
    public int physAttack;
    public int magicAttack;
    public int defense;
    public bool isPlayerUnit;
    public int actionTimerCountdown;    // Only for enemies

    // Add more things that the party/enemy units will have
    // (Art, attack animations, damage multipliers for action commands, etc.)
}
