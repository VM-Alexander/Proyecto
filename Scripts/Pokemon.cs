using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase _base { get; set; }
    public int level { get; set; }

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pBase, int plevel)
    {
        _base = pBase;
        level = plevel;
        HP = MaxHp;

        Moves = new List<Move>();
        foreach (var move in _base.LearnableMoves)
        {
            if (move.Level <= level)
            {
                Moves.Add(new Move(move.Base));
            }
            if (Moves.Count >= 4)
            {
                break;
            }
        }
    }

    public int Ataque
    {
        get{return Mathf.FloorToInt((_base.Ataque*level)/100f)+5;}
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 10; }
    }

    public int Defensa
    {
        get { return Mathf.FloorToInt((_base.Defensa * level) / 100f) + 5; }
    }

    public int AtaqueESP
    {
        get { return Mathf.FloorToInt((_base.AtaqueESP * level) / 100f) + 5; }
    }

    public int DefensaESP
    {
        get { return Mathf.FloorToInt((_base.DefensaESP * level) / 100f) + 5; }
    }

    public int Velocidad
    {
        get { return Mathf.FloorToInt((_base.Velocidad * level) / 100f) + 5; }
    }

    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float critical=1f;
        if(Random.value*100f<=6.25f)
            critical=2f;

        float type = TypeChart.GetEffectiveness(move.Base.type1, this._base.type1) * TypeChart.GetEffectiveness(move.Base.type1, this._base.type1);

        var damageDetails = new DamageDetails()
        {
            Type = type,
            Critical = critical,
            Fainted = false
        };

        float modifiers = Random.Range(0.85f, 1f) *type*critical;
        float a = (2 * attacker.level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Ataque / Defensa + 2);
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }
        return damageDetails;
    }

    public Move GetRandoMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}

public class DamageDetails
{
    public bool Fainted{ get; set; }
    public float Critical { get; set; }
    public float Type { get; set; }
}