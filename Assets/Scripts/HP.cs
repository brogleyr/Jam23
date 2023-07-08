using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //total HP
    public int Health = 100;

    SpriteRenderer m_SpriteRenderer;
    public Color OG_Color;
    public Color Hurt_Color;
    private ScoreManager scoreManager;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        OG_Color = m_SpriteRenderer.color;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        
        
    }

    //instantiate when you take damage
    public void TakeDamage (int damage)
    {
        
        Health -= damage;
        StartCoroutine(Ouch());
       
        if (Health <= 0)
        {
            Die();
        }

        if (name == "Fish") {
            scoreManager.ComboBreak();
        }
    }

    IEnumerator Ouch()
    {

        m_SpriteRenderer.color = Hurt_Color;

        yield return new WaitForSeconds(1);
        
        m_SpriteRenderer.color = OG_Color;

    }
    void Die ()
    {
        //death animation

        //destroy
        Destroy(gameObject);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
