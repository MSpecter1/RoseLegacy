using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string SkillName = "NOSKILLNAME";
    public string SkillType;
    public int Modifier;

    public Skill(string name, string type, int mod)
    {
        SkillName = name;
        SkillType = type;
        Modifier = mod;
    }

    public int SkillDamage(int attackstat, int magicstat) //RETURNS DAMAGE DONE
    {
        if (SkillType=="attack")
        {
            return attackstat * Modifier + Mathf.FloorToInt(Random.value * 3) + 2;
        }
        else if (SkillType == "magic")
        {
            return attackstat * Modifier + Mathf.FloorToInt(Random.value * 6);
        }
        return 0;
    }

    //INSERT EFFECT MANAGER INTEGRATION

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
