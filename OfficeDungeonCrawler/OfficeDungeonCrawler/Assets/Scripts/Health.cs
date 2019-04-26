/*
Author: Kevin P
Contributors: Myles Busig
Date Last Modified: 2/13/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject itemDrop;
    new public GameObject camera;
    public List<string> itemDrops = new List<string>();
    public List<int> itemDropCounts = new List<int>();
    public float dropDistance = 0.5f;

    // Max health of the entity
    public float maxHealth = 10;
    // Current health of the entity
    public float currentHealth;
    // Health bar used to display current health (if any)
    public GameObject healthBarAnchorObj;
    // The speed to change back to the normal color
    public float colorChangeSpeed = 1.0f;
    public float screenColorChangeSpeed = 2.0f;
    // The color when hurt
    public Color hurtColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    // The screen color when hurt
    public Color hurtScreenColor = new Color(1.0f, 1.0f, 0.0f, 85.0f);
    // The color when healed
    public Color healColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    // The normal color
    public Color normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    // The normal screen color
    public Color normalScreenColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    // The object to spawn when the entity dies
    public GameObject deathObject;
    public AudioClip deathSound;
    // two variables are used for passing to the screen shake script.
    public float shakeDuration = 0;
    public float shakeIntensity = 0;

	public static float staticHealth = 0.0f;
	public static bool alwaysLow = false;

    public GameObject healParticle;
    // The SpriteRenderer of the entity
    SpriteRenderer spriteRenderer;
    // The Bar of the health bar
    Bar healthBarAnchor;
	public float beatTime = 0.5f;
	float timeTillBeat = 0.0f;

    Image damageScreenIMG = null;

    public AudioClip hurtSound;
    AudioSource audioSource;
    public GameObject damageScreen;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // If the health bar is not null..
        if (healthBarAnchorObj != null)
        {
            // Get the Bar component of the health bar
            healthBarAnchor = healthBarAnchorObj.GetComponent<Bar>();
        }

		// Set the current health to the max health
		currentHealth = maxHealth;

		if (staticHealth > 0.0f && gameObject.tag == "Player")
			currentHealth = staticHealth;

        // Update the health bar
        UpdateHealthBar();

		if (alwaysLow && gameObject.tag == "Player")
			currentHealth = 1.0f;

        if (damageScreen != null)
            damageScreenIMG = damageScreen.GetComponent<Image>();
    }

    void Update()
    {
		if (gameObject.tag == "Player")
			staticHealth = currentHealth;

		timeTillBeat -= Time.deltaTime;

		if (timeTillBeat <= 0.0f && currentHealth <= 4.0f && gameObject.tag == "Player")
		{
			Damage(0.0f, true, 0.3f);
			timeTillBeat = beatTime;
		}

        if (Input.GetKeyDown(KeyCode.Minus) && gameObject.CompareTag("Player"))
            Damage(1.0f);
        //Debug.Log(gameObject.name + " health: " + currentHealth + "/" + maxHealth);

        // Lerp back to the normal color
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, normalColor, Time.deltaTime * colorChangeSpeed);

        if (damageScreenIMG != null)
            damageScreenIMG.color = Color.Lerp(damageScreenIMG.color, normalScreenColor, Time.deltaTime * screenColorChangeSpeed);
    }

    // Used to damage the entity
    public void Damage(float amount, bool noFlash = false, float alpha = -1.0f)
    {
        float vol = Random.Range(0.5f, 0.8f);
        // Decrease the current health
        currentHealth -= amount;

        // Set the entity color
		if (!noFlash)
		    spriteRenderer.color = hurtColor;

		if (damageScreenIMG != null)
		{
			Color c = hurtScreenColor;

			if (alpha != -1.0f)
				c.a = alpha;

			damageScreenIMG.color = c;
		}

        if (hurtSound != null && !noFlash)
            audioSource.PlayOneShot(hurtSound, vol);

        //if (camera != null)
        //camera.GetComponent<ScreenShake>().Shake(shakeIntensity, shakeDuration);

        // If the current health is less than 0..
        if (currentHealth <= 0)
        {
            // Kill the entity
            Death();
        }

        // Update the health bar
        UpdateHealthBar();
    }

    // Used to heal the entity
    public void Heal(float amount)
    {
        // Increase the currentHealth
        currentHealth += amount;

        // If the current health is greater than the max health
        if (currentHealth > maxHealth)
        {
            // Set the current health to the max health
            currentHealth = maxHealth;
        }

        // Set the entity color
        spriteRenderer.color = healColor;

        Instantiate(healParticle, transform.position, transform.rotation);

        // Update the health bar
        UpdateHealthBar();
    }

    // Used to update the health bar
    public void UpdateHealthBar()
    {
        // If the health bar is not null
        if (healthBarAnchor != null)
        {
            // Set the health bar max
            healthBarAnchor.max = maxHealth;
            // Set the health bar current
            healthBarAnchor.current = currentHealth;
        }
    }

    // Used to kill the entity
    public void Death()
    {
        Debug.Log("DESTROYING " + gameObject.name);

		if (gameObject.tag == "Player")
		{
			staticHealth = 0.0f;
			GetComponent<HPMeter>().Update();
		}

		if (Settings.memeMode)
		{
			for (int i = 0; i < itemDrops.Count; ++i)
			{
				if (itemDrops[i] == "pizza")
					itemDrops[i] = "potato";
				else if (itemDrops[i] == "watermelon" || itemDrops[i] == "avocado")
					itemDrops[i] = "gouda";
			}
		}

        for (int i = 0; i < itemDrops.Count; ++i)
        {
            ItemPickup drop = Instantiate(itemDrop, transform.position + new Vector3(Random.Range(-dropDistance, dropDistance), Random.Range(-dropDistance, dropDistance)), Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<ItemPickup>();

            drop.itemID = itemDrops[i];
            drop.itemAmount = itemDropCounts[i];
        }

        // Create the death entity
        if (deathObject != null)
        {
            GameObject newDeathObj = Instantiate(deathObject, transform.position, transform.rotation);

            newDeathObj.GetComponent<AudioSource>().PlayOneShot(deathSound);

			if (GetComponent<HealthBar>() != null)
			{
				GetComponent<HealthBar>().healthBarAnchor.transform.SetParent(newDeathObj.transform, true);
				GetComponent<HealthBar>().transform.Find("HealthbarBGAnchor").transform.SetParent(newDeathObj.transform, true);

				newDeathObj.GetComponent<HealthBar>().updateActive = false;
				newDeathObj.GetComponent<HealthBar>().healthBarAnchor = GetComponent<HealthBar>().healthBarAnchor;
				newDeathObj.GetComponent<HealthBar>().healthBar = GetComponent<HealthBar>().healthBar;
				newDeathObj.GetComponent<HealthBar>().Start();
				newDeathObj.GetComponent<HealthBar>().current = 0.0f;
				newDeathObj.GetComponent<HealthBar>().max = maxHealth;
				//newDeathObj.GetComponent<HealthBar>().healthBarAnchor = transform.Find("Healthbar").gameObject;
			}
		}

		// Destroy the entity
		Destroy(gameObject);
    }
}
