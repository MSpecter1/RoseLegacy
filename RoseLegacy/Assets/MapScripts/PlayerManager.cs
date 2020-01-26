using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public NodeManager NodeM;
    public NotificationPrompt notification;
    public int CurrentIndex = 0;
    public int TargetIndex;
    public bool Moving;
    public bool MovingEnabled=true;
    public bool InventoryOpen;
    public bool PromptedAlready;
    
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Enabled()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        CheckNode();

        if (MovingEnabled)
        {
            FixedNodeMove();
        }

        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("Select Button Down");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Cancel Button Down");
        }
        if (Input.GetButtonDown("Inventory"))
        {
            if (!InventoryOpen)
            {
                Debug.Log("Inventory Open");
                //INSERT LATER - OPEN INVENTORY IF NOT OPEN
                MovingEnabled = false;
                InventoryOpen = true;
            }
            else if (InventoryOpen)
            {
                Debug.Log("Inventory Closed");
                //INSERT LATER - CLOSE INVENTORY IF OPEN
                MovingEnabled = true;
                InventoryOpen = false; 
            }
        }
        if (Input.GetButtonDown("Temp"))
        {
            Debug.Log("Temp Button Down");
        }
        if (Input.GetButtonDown("PauseMenu"))
        {
            Debug.Log("PauseMenu Button Down");
            //OPEN PAUSE MENU
        }
    }

    void CheckNode()
    {
        if (NodeM.Nodes[CurrentIndex].tag == "NodeIntersection" && !PromptedAlready)
        {
            StartCoroutine(Notification(gameObject, "Intersection"));
            PromptedAlready = true;
        }
        else if (NodeM.Nodes[CurrentIndex].tag == "NodeTreasure" && !PromptedAlready)
        {
            StartCoroutine(Notification(gameObject, "Treasure"));
            PromptedAlready = true;
        }
        else if (NodeM.Nodes[CurrentIndex].tag == "NodeShop" && !PromptedAlready)
        {
            StartCoroutine(Notification(gameObject, "Shop"));
            PromptedAlready = true;
        }
        else if (NodeM.Nodes[CurrentIndex].tag == "NodeBattle" && !PromptedAlready)
        {
            //INSERT BATTLE MANAGER FUNCTIONS
        }
    }

    void FixedNodeMove()
    {
        if (Input.GetButtonDown("Right") && !Moving && CurrentIndex!=NodeM.Nodes.Count)
        {
            Debug.Log("Right Button Down");
            TargetIndex = CurrentIndex + 1;
            StartCoroutine(MoveToNode(gameObject, NodeM.Nodes[TargetIndex], 1));
            
        }
        else if (Input.GetButtonDown("Left") && !Moving && CurrentIndex!=0)
        {
            Debug.Log("Left Button Down");
            TargetIndex = CurrentIndex - 1;
            StartCoroutine(MoveToNode(gameObject, NodeM.Nodes[TargetIndex], 0));
            //CurrentIndex--;
        }
        //PromptedAlready = false;
    }

    public void ForceMove(int index)
    {
        //Forces Movement

        TargetIndex = index;
        StartCoroutine(MoveToNode(gameObject, NodeM.Nodes[TargetIndex], 0)); // doesnt matter what num you give to function at the end;
        CurrentIndex = index;
        //PromptedAlready = false;
    }

    IEnumerator MoveToNode(GameObject PlayerSprite, Transform TargetNode, int direction)
    {
        Moving = true;
        while (Vector2.Distance(PlayerSprite.transform.position, TargetNode.position) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(PlayerSprite.transform.position, TargetNode.position, 10.0f * Time.deltaTime);
            yield return null;
        }
        
        if (direction>0)
        {
            CurrentIndex++;
        }
        else if (direction == 0)
        {
            CurrentIndex--;
        }
        PromptedAlready = false;
        Moving = false;
    }

    IEnumerator Notification(GameObject PlayerSprite, string type)
    {
        bool prompted = false;
        bool prompted1 = false;
        MovingEnabled = false;

        while (!prompted)
        {
            if (prompted1!=true)
            {
                notification.EnablePrompt(type);
                prompted1 = true;
            }
            prompted = notification.GetNotificationStatus();
            //Prompted already activates when player has accepted outcome
            yield return null;
        }
        MovingEnabled = true;
    }


}
