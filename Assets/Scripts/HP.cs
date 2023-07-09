using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //total HP
    public int Health;
    public int maxHealth = 100;

    SpriteRenderer m_SpriteRenderer;
    public Color OG_Color;
    public Color Hurt_Color;
    private ScoreManager scoreManager;
    GameManager m_gameManager;
    Animator animator;
    Scuttle m_scuttle;
    private Fish m_fish;
    public Renderer healthBar;

    void Start()
    {
        m_fish = GetComponent<Fish>();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        OG_Color = m_SpriteRenderer.color;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Health = maxHealth;
        healthBar = GameObject.Find("Health").GetComponent<Renderer>();
    }

    private void Update() {
        if (healthBar != null) {
            float healthRatio = (float)Health / (float)maxHealth;
            healthBar.sharedMaterial.SetFloat("_Health", healthRatio);
        }
    }

    //instantiate when you take damage
    public void TakeDamage (int damage, string killer)
    {
        
        Health -= damage;
        StartCoroutine(Ouch());
       
        if (Health <= 0 && !(name == "Fish"))
        {
            Die();
        }

        if (name == "Fish") 
        {
            if (Health <= 0)
            {
                m_fish.Disable(true);
                m_gameManager.GameOver("You were killed by " + killer);

            }
            //scoreManager.ComboBreak();
        }
    }

    IEnumerator Ouch()
    {

        m_SpriteRenderer.color = Hurt_Color;

        yield return new WaitForSeconds(0.2f);
        
        m_SpriteRenderer.color = OG_Color;

        yield return new WaitForSeconds(0.2f);

        m_SpriteRenderer.color = Hurt_Color;

        yield return new WaitForSeconds(0.2f);

        m_SpriteRenderer.color = OG_Color;

        yield return new WaitForSeconds(0.2f);

        m_SpriteRenderer.color = Hurt_Color;

        yield return new WaitForSeconds(0.2f);

        m_SpriteRenderer.color = OG_Color;

    }
    void Die ()
    {
        //death animation
        if (m_scuttle != null)
        {
            m_scuttle.ScuttleBoat();
        }

        //destroy
        Destroy(gameObject);
        
    }
   
}
