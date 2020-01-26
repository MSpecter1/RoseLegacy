using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{
    public GlobalStateManager globalstate;
    private int health;
    private int attack;
    private int speed;
    private int magic;
    public List<Skill> pskills = new List<Skill>();
    public Unit PlayerUnit;
    // Start is called before the first frame update
    void Start()
    {
        LoadGlobalStats();
        PlayerUnit.loadStats("Player", health, attack, speed, magic, pskills);
    }

    // Update is called once per frame
    void LoadGlobalStats()
    {
        health = globalstate.health;
        attack = globalstate.attack;
        magic = globalstate.magic;
        speed = globalstate.speed;
        pskills = globalstate.GlobalPlayerSkills;
    }
}
