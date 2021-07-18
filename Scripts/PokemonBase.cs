using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Pokemon", menuName="Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string descripcion;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] TipoPokemon Type1;
    [SerializeField] TipoPokemon Type2;

    [SerializeField] int maxHp;
    [SerializeField] int ataque;
    [SerializeField] int defensa;
    [SerializeField] int ataqueESP;
    [SerializeField] int defensaESP;
    [SerializeField] int velocidad;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name
    {
        get { return name; }
    }

    public string Descripcion
    {
        get { return descripcion; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public TipoPokemon type1
    {
        get { return Type1; }
    }

    public TipoPokemon type2
    {
        get { return Type2; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Ataque
    {
        get { return ataque; }
    }

    public int Defensa
    {
        get { return defensa; }
    }

    public int AtaqueESP
    {
        get { return ataqueESP; }
    }

    public int DefensaESP
    {
        get { return defensaESP; }
    }

    public int Velocidad
    {
        get { return velocidad; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]

public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

public enum TipoPokemon
{
    None,
    Normal,
    Fuego,
    Agua,
    Electrico,
    Hierba,
    Hielo,
    Lucha,
    Veneno,
    Tierra,
    Volador,
    Psiquico,
    Insecto,
    Roca,
    Fantasma,
    Dragon
}

public class TypeChart
{
    static float[][] chart =
    { //                     NO,FU,AG,EL,HI,HI,LU,VE,TI,VO,PS,IN,RO,FA,DR,DA,AC,FA 
    /*Normal*/  new float[] {1f,1f,1f,1F,1F,1f,1f,1f,1F,1F,1f,1f,0.5f,0f,1f,1f,0.5f,1f},
    /*Fuego*/   new float[] {1f,0.5f,0.5f,1F,2F,2f,1f,1f,1F,1F,1f,2f,0.5f,1f,0.5f,1f,2f,1f},
    /*Agua*/    new float[] {1f,2f,0.5f,1F,0.5F,1f,1f,1f,2F,1F,1f,1f,2f,1f,0.5f,1f,1f,1f},
   /*Electrico*/new float[] {1f,1f,2f,0.5F,0.5F,1f,1f,1f,0F,2F,1f,1f,1f,1f,0.5f,1f,1f,1f},
    /*Hierba*/  new float[] {1f,0.5f,2f,1F,0.5F,1f,1f,0.5f,2F,0.5F,1f,0.5f,2f,1f,0.5f,1f,0.5f,1f},
    /*Hielo*/   new float[] {1f,0.5f,0.5f,1F,2F,0.5f,1f,1f,2F,2F,1f,1f,1f,1f,2f,1f,0.5f,1f},
    /*Lucha*/   new float[] {2f,1f,1f,1F,2F,1f,0.5f,1f,0.5F,0.5F,0.5f,2f,0f,1f,2f,2f,1f,0.5f},
    /*Veneno*/  new float[] {1f,1f,1f,1F,2F,1f,1f,0.5f,0.5F,1F,1f,1f,0.5f,0.5f,1f,1f,0f,2f},
    /*Tierra*/  new float[] {1f,2f,1f,2F,0.5F,1f,1f,2f,1F,0F,1f,0.5f,2f,1f,1f,1f,2f,1f},
    /*Volador*/ new float[] {1f,1f,1f,0.5F,2F,1f,2f,1f,1F,1F,1f,2f,0.5f,1f,1f,1f,0.5f,1f},
    /*Psiquico*/new float[] {1f,1f,1f,1F,1F,1f,2f,2f,1F,1F,0.5f,1f,1f,1f,1f,0f,0.5f,1f},
    /*Insecto*/ new float[] {1f,0.5f,1f,1F,2F,1f,0.5f,0.5f,1F,0.5F,2f,1f,1f,0.5f,1f,2f,0.5f,0.5f},
    /*Roca*/    new float[] {1f,2f,1f,1F,1F,2f,0.5f,1f,0.5F,2F,1f,2f,1f,1f,1f,1f,0.5f,1f},
    /*Fantasma*/new float[] {0f,1f,1f,1F,1F,1f,1f,1f,1F,1F,2f,1f,1f,2f,1f,0.5f,1f,1f},
    /*Dragon*/  new float[] {1f,1f,1f,1F,1F,1f,1f,1f,1F,1F,1f,1f,1f,1f,2f,1f,0.5f,0f},
    /*DAR*/     new float[] {1f,1f,1f,1F,1F,1f,0.5f,1f,1F,1F,2f,1f,1f,2f,1f,0.5f,1f,0.5f},
    /*Ace*/     new float[] {1f,0.5f,0.5f,0.5F,1F,2f,1f,1f,1F,1F,1f,1f,2f,1f,1f,1f,0.5f,2f},
    /*FAI*/     new float[] {1f,0.5f,1f,1F,1F,2f,0.5f,1f,1F,1F,1f,1f,1f,1f,2f,2f,0.5f,1f}
    };

    public static float GetEffectiveness(TipoPokemon attackType, TipoPokemon defenseType)
    {
        if (attackType == TipoPokemon.None || defenseType == TipoPokemon.None)
        {
            return 1;
        }
        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}