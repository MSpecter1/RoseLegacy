using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnBattleSystem : MonoBehaviour
{
    private List<Unit> TurnOrder = new List<Unit>();
    public Unit player;
    public Unit enemy;
    public TextMeshProUGUI battleText;

    public bool InBattle=true;
    // Start is called before the first frame update
    void Start()
    {
        CalculateTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Unit Speedcheck()
    {
        if (player.speed + Mathf.FloorToInt(Random.value*5) >= enemy.speed + Mathf.FloorToInt(Random.value * 5))
        {
            return player;
        }
        else
        {
            return enemy;
        }
    }

    void CalculateTurn()
    {
        player.CalculateNextTurn();
        enemy.CalculateNextTurn();

        if (Speedcheck() == player)
        {
            TurnOrder.Add(player);
        }
        else
        {
            TurnOrder.Add(enemy);
        }

        StartTurn();
    }
    void StartTurn()
    {
        for (int i = 0; i<2; i++ )
        {
            if (TurnOrder[i]==player)
            {
                battleText.text = "You take your turn";
                if (Input.GetButtonDown("Select"))
                {
                    player.AttackOtherUnit(enemy, player.NextTurnDmg);
                    battleText.text = "You use " + player.NextTurnSkill + "! You deal " + player.NextTurnDmg + " damage to the enemy!";
                }

            }
            else if (TurnOrder[i] == enemy)
            {
                battleText.text = "The enemy makes its move...";
                if (Input.GetButtonDown("Select"))
                {
                    enemy.AttackOtherUnit(player, enemy.NextTurnDmg);
                    battleText.text = "The enemy uses " + enemy.NextTurnSkill + "! You take " + enemy.NextTurnDmg + " damage!";
                }
            }
        }

        EndTurn();


    }
    void EndTurn()
    {
        if (player.health==0)
        {
            //Start GameOver Function
        }
        else if (enemy.health == 0)
        {
            //Start Victory Function
        }
        else
        {
            TurnOrder.Clear();
            CalculateTurn();
        }
    }


}
