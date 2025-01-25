using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class PartyMemberUnit : MonoBehaviour
{
    public UnitSO unitData;

    [NonSerialized]
    public BattleManager manager;

    [SerializeField] private int currentHealth;
    [SerializeField] private int physAttack;
    [SerializeField] private int magicAttack;

    [SerializeField] private int defense;

    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = unitData.maxHealth;
        physAttack = unitData.physAttack;
        magicAttack = unitData.magicAttack;
        defense = unitData.defense;

        healthBar.SetMaxHealth(currentHealth);

        //manager = GameObject.FindAnyObjectByType<BattleManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"{manager.gameObject.name}", manager.gameObject);
        Debug.Log($"{unitData.unitName} has {unitData.maxHealth} health");
    }
}
