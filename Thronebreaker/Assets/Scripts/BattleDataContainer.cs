using UnityEngine;

public class BattleDataContainer : MonoBehaviour
{
    public int battleEnviornment; //for styling of the background. If unassigned, this always returns '0'
    public int[] enemiesInFight = {0, 2, 5, 5}; //ID's of each enemy in the fight
    public float[] playerPartyLevels = {199.5f, 59, 3.141568f}; //the levels for every party member
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject); //make the object persist thru level changes
    }
}
