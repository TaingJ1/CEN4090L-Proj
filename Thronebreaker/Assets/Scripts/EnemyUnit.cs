using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

// This script defines an actual Unit and is attached to each official actual Unit object in the scene.

public class EnemyUnit : MonoBehaviour
{
    public UnitSO unitData;
    public TextMeshProUGUI timerText;
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
        Debug.Log($"{unitData.unitName} has {currentHealth} health");

        if(timerText)
        {
            timerText.text = turnsUntilAttack.ToString();
        }
    }

    public int turnsUntilAttack = 5;

    public void DoTurn()
    {
        if (currentHealth == 0)
        {
            Debug.Log("Enemy died");
            //manager.enemyUnits.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            TakeDamage(4);
            turnsUntilAttack--;
            timerText.text = turnsUntilAttack.ToString();
        }
    }

    public void SetHealth()
    {
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth();
    }

    // More as time goes on
}
