using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NotificationPrompt : MonoBehaviour
{
    //LISTS
    public List<Anomoly> Treasure;
    public List<Anomoly> Shop;
    public List<Anomoly> IntersectionPaths;

    public PlayerManager player;
    public GameObject NotificationPanel;
    public TextMeshProUGUI NotificationText;
    public GameObject OutcomePrompt;
    public TextMeshProUGUI OutcomeText;
    public LootSkillTable Loot;
    public Button Button1;
    public Button Button3;
    public string type;
    public bool finished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableAllPrompts()
    {
        NotificationPanel.SetActive(false);
        OutcomePrompt.SetActive(false);
        finished = true;
    }

    public void EnablePrompt(string type)
    {
        finished = false;
        this.type = type;
        NotificationPanel.SetActive(true);


        //Anything with a "" is only temporary
        int EffectNum = Mathf.FloorToInt(Random.value * Treasure.Count);
        if (type=="Intersection")
        {
            //NotificationText.text = IntersectionPaths[EffectNum].GetFluff();
            //EFFECT MANAGER: CauseEffect(EffectNum, 5);
            NotificationText.text = "There is a hidden path up ahead, is it worth the risk to venture into the unknown? Or is it better to stay to the roads?";
        }
        else if (type=="Treasure")
        {
            //NotificationText.text = Treasure[EffectNum].GetFluff();
            NotificationText.text = "You see a glisten within the darkness; a chest. Do you wish to open it?";
        }
        else if (type=="CursedTreasure")
        {
            //NotificationText.text = Treasure[EffectNum].GetFluff();
            NotificationText.text = "You see a glisten within the darkness; a chest. Do you wish to open it?";
        }
        else if (type=="Shop")
        {
            //NotificationText.text = Shop[EffectNum].GetFluff();
            NotificationText.text = "You approach hospitable shop, do you wish to buy any items?";
        }
        Button1.Select();
    }

    public void Option1()
    {
        EnableOutcomePrompt(type, 1);
    }
    public void Option2()
    {
        EnableOutcomePrompt(type, 2);
    }

    public void EnableOutcomePrompt(string type, int option)
    {
        NotificationPanel.SetActive(false);
        OutcomePrompt.SetActive(true);
        Button3.Select();
    }

    public void Option3()
    {
        //ACCEPT
        DisableAllPrompts();
        player.PromptedAlready = true;
    }

    public bool GetNotificationStatus()
    {
        return finished;
    }
}
