using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    public Slider healthBar;
    PlayerMovement playerMovementRef;
    Animator anim;
    //changing the control UI
    public GameObject[] weapons;
    public int currentWeapon = 0;
    private int changeWeapon;

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool damaged;
    bool dead;
    GameObject button;

    // Use this for initialization

    void Start ()
    {
        playerMovementRef = GetComponent<PlayerMovement>();
        anim = GameObject.Find("player").GetComponent<Animator>();
        button = GameObject.Find("Game Over");
        //weapon switcher
        currentHealth = maxHealth;
        changeWeapon = weapons.Length;
        SwitchWeapon(currentWeapon);
        StartCoroutine(DeathScene());
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 1; i <= changeWeapon; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;

                SwitchWeapon(currentWeapon);

            }
        }
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        StartCoroutine(DeathScene()); 

    }
    IEnumerator DeathScene()
    {
        if (dead == true)
        {
            anim.SetBool("dead", true);
            yield return new WaitForSeconds(3f);
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        damaged = true;

        currentHealth -= damage;

        healthBar.value = currentHealth;

        if (currentHealth <= 0 && !dead)
        {
            Death();
        }
    }

    void Death()
    {
        dead = true;
        playerMovementRef.enabled = false;
    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < changeWeapon; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
