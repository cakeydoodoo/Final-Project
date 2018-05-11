using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;
    PlayerMovement playerMovementRef;


    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool damaged;
    bool dead;

	// Use this for initialization

	void Start ()
    {
        playerMovementRef = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
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
    
		
	}

    public void TakeDamage(int damage)
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
}
