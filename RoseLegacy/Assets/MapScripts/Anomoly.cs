using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomoly : MonoBehaviour
{
    private string FluffText = "Not Configured";
    private int effectIndex = 0;

    /*EFFECT INDEX EXPLAINED
        
        There are too many effects for us to individually program into the game, 
        the best way to approach this sort of thing is to start a list of universal functions
        and their relation to an int value so that we can easily associate an effect with any anomoly

        1 - random loot
        2 - random cursed loot
        3 - random buff
        4 - random debuff
        5 - random Strength trait gain
        6 - random Weakness trait gain
        7 - movement one tile backwards
        8 - movement one tile forwards
        9 - reset randomness of tile (say that the scenery of the dungeon has changed, or that the player fell through a trap door, etc)
        10 - Combonation of any 2 or 3 of the above

        *** MUST HAVE EQUAL NUMBERS OF EACH OF THESE, EFFECT #10 IS MEANT TO BE FOR SPECIAL SCRIPTED EVENTS

    */

    public Anomoly(string fluff, int effect)
    {
        FluffText = fluff;
        effectIndex = effect;
    }

    public string GetFluff()
    {
        return FluffText;
    }

    public void SetFluff(string fluff)
    {
        FluffText=fluff;
    }

    public void SetEffect(int effect)
    {
        effectIndex = effect;
    }

    public int GetEffect()
    {
        return effectIndex;
    }
}
