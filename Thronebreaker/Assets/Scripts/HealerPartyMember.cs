using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HealerPartyMember : PartyMemberUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    public override IEnumerator DoTurn()
    {
        Debug.Log("Healer party member prepares.");

        // Action logic here

        yield return base.DoTurn();
    }

    public void BaseAttack(EnemyUnit target)
    {
        int damage = physAttack;
        target.TakeDamage(damage);
        Debug.Log("Healer Party Member: Base Attack");
    }

    public void Heal(PartyMemberUnit partyMember)
    {
        Debug.Log("Healer Party Member: Heavy Attack");
    }
}
