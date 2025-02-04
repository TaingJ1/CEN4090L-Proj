using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MagicPartyMember : PartyMemberUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    public override IEnumerator DoTurn()
    {
        Debug.Log("Magic party member prepares.");

        // Action logic here

        yield return base.DoTurn();
    }

    public void BaseAttack(EnemyUnit target)
    {
        int damage = physAttack;
        target.TakeDamage(damage);
        Debug.Log("Magic Party Member: Base Attack");
    }

    public void Spell1(EnemyUnit target)
    {
        Debug.Log("Magic Party Member: Heavy Attack");
    }
}
