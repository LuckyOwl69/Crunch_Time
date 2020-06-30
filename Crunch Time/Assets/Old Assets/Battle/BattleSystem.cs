using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public static int enemiesOnCurrentFloor;
    //public int enemyPrefabsSize = Random.Range(0, 50);


    public GameObject playerPrefab;
    //public GameObject enemyPrefab;

    //public Object CurrentFloorScene;

    public string hallwayScene;

    public Button NAButton;

    public Button AttackButton;
    public Button Magic1Button;
    public Button Magic4Button;

    //first menu
    public GameObject AttackButtonObject;
    public GameObject MagicButtonObject;
    public GameObject TalkButtonObject;
    //second menu
    public GameObject Magic1ButtonObject;
    public GameObject Magic2ButtonObject;
    public GameObject Magic3ButtonObject;
    public GameObject BackButton1Object;
    public GameObject NextButton1Object;
    //third menu
    public GameObject Magic4ButtonObject;
    public GameObject BackButton2Object;

    public List<GameObject> enemyPrefabs;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;    

    Unit playerUnit;
    Unit enemyUnit;


    public Text playerHealthText;
    public Text dialogueText;
    public Text playerNameText;

    public BattleHUD playerHUD;

    public BattleState state;

    bool MagicUsed;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        playerNameText.text = playerUnit.unitName;


        AttackButtonObject.transform.gameObject.SetActive(true);
        MagicButtonObject.transform.gameObject.SetActive(true);

        //magic spells
        Magic1ButtonObject.transform.gameObject.SetActive(false);

    }

    private void Update()
    {
        //show player health in text form
        playerHealthText.text = playerUnit.currentHP.ToString() + " / " + playerUnit.maxHP.ToString() + " HP";

    }
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        //flavour text as soon as battle begins
        //dialogueText.text = enemyUnit.unitName + " " + enemyUnit.unitJob + "!";
        dialogueText.text = enemyUnit.unitName + " Needs your help with something!";

        playerHUD.SetHUD(playerUnit);
        playerHUD.SetEnemyHUD(enemyUnit);

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack() 
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        playerHUD.SetEnenmyHP(enemyUnit.currentHP);


        dialogueText.text = "The attack is successful! "+ enemyUnit.unitName+ " takes " + playerUnit.damage + " damage!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            dialogueText.text = "You won the battle!";
            yield return new WaitForSeconds(2f);

            EndBattle();
        }
        else
        {

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    
    IEnumerator PlayerMagicAttack(string affinity) 
    {
        if(affinity == enemyUnit.weakness)
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 2);
            playerHUD.SetEnenmyHP(enemyUnit.currentHP);

            dialogueText.text = "The attack is successful! " + enemyUnit.unitName + " takes " + playerUnit.damage * 2 + " damage!";

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WON;
                dialogueText.text = "You won the battle!";
                yield return new WaitForSeconds(2f);

                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 0);
            playerHUD.SetEnenmyHP(enemyUnit.currentHP);

            dialogueText.text = "The attack is unsuccessful... " + enemyUnit.unitName + " takes no damage!";

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WON;
                dialogueText.text = "You won the battle!";
                yield return new WaitForSeconds(2f);

                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
    }

    public void PlayerMagic()
    {
        MagicUsed = false;
        //BattleMenuChoice();
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks! You take " + enemyUnit.damage + " damage!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            //SceneManager.LoadScene(CurrentFloorScene.name);
            SceneManager.LoadScene(hallwayScene);

        }
        else if(state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        //dialogueText.text = "Your turn: ";
        dialogueText.text = enemyUnit.unitName + " " + enemyUnit.unitJob + "! How will you help?";

        //dialogueText.text = enemyUnit.unitName + " Health = " + enemyUnit.currentHP;
        AttackButton.Select();
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        NAButton.Select();
        StartCoroutine(PlayerAttack());
    }


    public void OnMagic1Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerMagicAttack("Scissors"));
    }
    public void OnMagic2Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerMagicAttack("Stapler"));
    }
     public void OnMagic3Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerMagicAttack("PaperClip"));
    }

    public void DefaultBattleMenu ()
    {
        //main menu objects
        AttackButtonObject.transform.gameObject.SetActive(true);
        MagicButtonObject.transform.gameObject.SetActive(true);
        TalkButtonObject.transform.gameObject.SetActive(true);

        //magic spells
        Magic1ButtonObject.transform.gameObject.SetActive(false);
        Magic2ButtonObject.transform.gameObject.SetActive(false);
        Magic3ButtonObject.transform.gameObject.SetActive(false);
        Magic4ButtonObject.transform.gameObject.SetActive(false);

        //next buttons 
        NextButton1Object.transform.gameObject.SetActive(false);

        //back buttons
        BackButton1Object.transform.gameObject.SetActive(false);
        BackButton2Object.transform.gameObject.SetActive(false);

        AttackButton.Select();
    }
    public void AltDefaultBattleMenu ()
    {
        //main menu objects
        AttackButtonObject.transform.gameObject.SetActive(true);
        MagicButtonObject.transform.gameObject.SetActive(true);
        TalkButtonObject.transform.gameObject.SetActive(true);


        //magic spells
        Magic1ButtonObject.transform.gameObject.SetActive(false);
        Magic2ButtonObject.transform.gameObject.SetActive(false);
        Magic3ButtonObject.transform.gameObject.SetActive(false);
        Magic4ButtonObject.transform.gameObject.SetActive(false);

        //next buttons 
        NextButton1Object.transform.gameObject.SetActive(false);

        //back buttons
        BackButton1Object.transform.gameObject.SetActive(false);
        BackButton2Object.transform.gameObject.SetActive(false);

    }

    public void MagicMenu1 ()
    {
        //main menu objects
        AttackButtonObject.transform.gameObject.SetActive(false);
        MagicButtonObject.transform.gameObject.SetActive(false);
        TalkButtonObject.transform.gameObject.SetActive(false);


        //magic spells
        Magic1ButtonObject.transform.gameObject.SetActive(true);
        Magic2ButtonObject.transform.gameObject.SetActive(true);
        Magic3ButtonObject.transform.gameObject.SetActive(true);
        Magic4ButtonObject.transform.gameObject.SetActive(false);

        //next buttons 
        NextButton1Object.transform.gameObject.SetActive(true);

        //back buttons
        BackButton1Object.transform.gameObject.SetActive(true);
        BackButton2Object.transform.gameObject.SetActive(false);

        Magic1Button.Select();
    }
    
    public void MagicMenu2 ()
    {
        //main menu objects
        AttackButtonObject.transform.gameObject.SetActive(false);
        MagicButtonObject.transform.gameObject.SetActive(false);
        TalkButtonObject.transform.gameObject.SetActive(false);



        //magic spells
        Magic1ButtonObject.transform.gameObject.SetActive(false);
        Magic2ButtonObject.transform.gameObject.SetActive(false);
        Magic3ButtonObject.transform.gameObject.SetActive(false);
        Magic4ButtonObject.transform.gameObject.SetActive(true);

        //next buttons 
        NextButton1Object.transform.gameObject.SetActive(false);

        //back buttons
        BackButton1Object.transform.gameObject.SetActive(false);
        BackButton2Object.transform.gameObject.SetActive(true);

        Magic4Button.Select();
    }
}
