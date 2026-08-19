using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    internal static CharacterController instance;

    public float moveSpeed = 4f;
    Vector2 move = Vector2.right;
    Vector2 direction = Vector2.right;

    public InputAction moveAction;
    public InputAction throwAction;

    private Animator animator;

    public GameObject throwPreFab;
    internal float throwCooldown = 0.5f;
    private float throwCooldownTimer = 0f;

    //Leveling
    internal int XP = 0;
    private int level = 1;
    private float HP = 100;
    private float maxHP = 100;
    private float regeneration = 0;

    //Spawner for game starting
    public GameObject spawnerPrefab;

    //Hats!
    public GameObject hatPrefab;

    //POWEEEEEER!!!!
    internal class Power
    {
        internal string name;
        internal string presentation;
        internal string description;
        internal int level;
        internal Sprite sprite;
        internal GameObject gameObject;
        internal Action onLevelUp;

        internal Power(string newName, string newPresentation, string newDescription, Action newLevelUp, int newLevel = 0, Sprite newSprite = null)
        {
            name = newName;
            presentation = newPresentation;
            description = newDescription;
            level = newLevel;
            sprite = newSprite;
            onLevelUp = newLevelUp;
        }
    }

    internal List<Power> powers;
    public GameObject shoutSpawer;
    public GameObject skull;
    public GameObject shield;
    public GameObject cloud;


    void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        throwAction.Enable();
        animator = GetComponent<Animator>();
        throwCooldown = throwPreFab.GetComponent<Throwable>().reloadTime;
        Instantiate(spawnerPrefab, transform.position, Quaternion.identity);

        Spawner.instance.RiseTheStakes();
        HPViewController.instance.SetHealth(HP / (float)maxHP);

        //GET POWERS!
        powers = new List<Power>();
        powers.Add(new Power("Rock", "Throw rocks at your enemies", "Increase the damage of your rocks", PowerRock,0));
        powers.Add(new Power("Shout", "Shout away your enemies", "Increase Damage and range of your shouts", PowerShout,0));
        powers.Add(new Power("Skull", "Summon a damned skull to protect you", "Increase the damage and speed of the skull", PowerSkull,0));
        powers.Add(new Power("Shield", "Invoke a protective shield", "Increase the ammount of damage the shield can absorb", PowerShield,0));
        powers.Add(new Power("Regeneration", "Call forward your regeneration powers", "Increase rate of health regeneration", PowerRegeneration,0));
        powers.Add(new Power("Cloud of ruin", "Summon clouds of toxic fumes around you", "Increase the damage and size of your cloud", PowerCloud,0));
        powers.Add(new Power("Health", "You not dead, you?", "Increase you maximum health", PowerHealth,0));

        Debug.Log("My shouting device is " + shoutSpawer.name);
        Debug.Log("Has it a shout controller? "+ (shoutSpawer.GetComponent<ShoutController>()!=null?"yes":"no"));
        Debug.Log("And it itself has a " + shoutSpawer.GetComponent<ShoutController>().shoutDamage);

        //Reset stats of powers to start values
        throwPreFab.GetComponent<DamageEnemies>().damage = 10;
        throwPreFab.GetComponent<Throwable>().speed = 5f;
        throwPreFab.GetComponent<Throwable>().isAimable = true;
        cloud.GetComponent<CloudController>().cloudPower = 10;
        cloud.GetComponent<CloudController>().expirationTime = 2f;
        skull.GetComponent<DamageEnemies>().damage = 10;
        skull.GetComponent<MoveOrbiting>().orbitSpeed = 1f;
        shield.GetComponent<ShieldController>().MaxHP =20;
        shield.GetComponent<ShieldController>().reloadTime = 4f;
        shoutSpawer.GetComponent<ShoutController>().shoutDamage = 20;
        shoutSpawer.GetComponent<ShoutController>().shoutSpeed = 1f;
        shoutSpawer.GetComponent<ShoutController>().shoutTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Attacking
        if (throwAction.IsPressed() && throwCooldownTimer <= 0)
        {
            GameObject throwObject = Instantiate(throwPreFab, transform.position, Quaternion.identity);
            throwObject.GetComponent<Throwable>().throwDirection = direction;
            throwCooldownTimer = throwCooldown;
        }

        if (throwCooldownTimer > 0)
        {
            throwCooldownTimer -= Time.deltaTime;
        }

        //show Health
        HPViewController.instance.SetHealth(HP / (float)maxHP);
    }

    void FixedUpdate()
    {
        //Move
        move = moveAction.ReadValue<Vector2>();

        if (move.magnitude != 0)
        {
            direction = move;
        }

        Vector2 position = (Vector2)transform.position + move * moveSpeed * Time.deltaTime;

        transform.position = position;

        animator.SetFloat("MoveX", move.x);

        if (move.x < 0)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1);

        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }

        //Regenerate
        if(HP < maxHP)
        {
            HP + = regeneration * Time.deltaTime;
        }
    }

    internal void TakeXP(int amount)
    {
        XP += amount;

        if (XP >= 200 * level)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Debug.Log("LEVEL UP!!!");
        level++;
        XP = 0;
        Spawner.instance.RiseTheStakes();
        LevelUpController.instance.Pause();
        HP = maxHP;
        HPViewController.instance.SetHealth(HP / (float)maxHP);
    }

    internal void TakeDamage(int amount)
    {
        HP -= amount;

        if (HP <= 0)
        {
            Debug.Log("GAME OVER");
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        float restartDelay = 1f; // Delay before restarting the game

        float freezeEndTime = Time.realtimeSinceStartup + restartDelay;

        while (Time.realtimeSinceStartup < freezeEndTime)
        {

        }

        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MenuScene"); // Restart the current scene
    }

    //Methods for powers
    private void PowerRock()
    {
        Debug.Log("Rock powering up from " + powers[0].level);
        throwPreFab.GetComponent<DamageEnemies>().damage *= 2;
    }

    private void PowerShout()
    {
        Debug.Log("Shout Powering Up from " + powers[1].level);
        
        if (powers[1].level == 0)
        {
            Instantiate(shoutSpawer,Vector3.right,Quaternion.identity);
            powers[1].level++;
        }
        else
        {
            shoutSpawer.GetComponent<ShoutController>().shoutDamage += 10;
            shoutSpawer.GetComponent<ShoutController>().shoutSpeed += 0.2f;
            shoutSpawer.GetComponent<ShoutController>().shoutTime += 0.2f;
        }
    }

    private void PowerRegeneration()
    {
        regeneration += 1f;
        Debug.Log("More regen! now " + regeneration);
    }

    private void PowerShield()
    {
        Debug.Log("Powering up the shield");
        if (powers[3].level == 0)
        {
            Debug.Log("Creating Shield");
            Instantiate(shield, Vector3.right, Quaternion.identity);
            powers[3].level++;
        }
        else
        {
            shield.GetComponent<ShieldController>().MaxHP *= 2f;
            shield.GetComponent<ShieldController>().reloadTime *= 0.75f;
        }

    }

    private void PowerSkull()
    {
        Debug.Log("Powering up the skull");
        if (powers[2].level == 0)
        {
            Debug.Log("Creating new skull");
            Instantiate(skull, Vector3.right, Quaternion.identity);
            powers[2].level++;
        }
        else
        {
            Debug.Log("Improving the skull");
            skull.GetComponent<DamageEnemies>().damage *= 2;
            skull.GetComponent<MoveOrbiting>().orbitSpeed += 0.1f;
        }

    }

    private void PowerCloud()
    {
        Debug.Log("Powering the cloud from " + powers[5].level);
        if (powers[5].level == 0)
        {
            Debug.Log("New Cloud Controller.");
            Instantiate(cloud, Vector3.right, Quaternion.identity);
            powers[5].level++;
        }
        else
        {
            cloud.GetComponent<CloudController>().cloudPower*= 2;
            cloud.GetComponent<CloudController>().expirationTime += 0.5f;
        }
    }

    private void PowerHealth()
    {
        maxHP += 20f;
        Debug.Log("More HEalth! Now " + maxHP);
    }
}

