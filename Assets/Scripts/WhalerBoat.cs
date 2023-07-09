using System.Collections;
using System.Collections.Generic;
using UnityEditor;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhalerBoat : MonoBehaviour
{
    public float speed = 6;
    private Shooter m_shoooter;
    private AvoidRocks m_avoidRocks;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_shoooter = GetComponent<Shooter>();
        m_avoidRocks = GetComponentInChildren<AvoidRocks>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Boat")
        {
                //scoreManager.BoatCrash(transform);
                animator.SetTrigger("WhalerDestroyed");

            Destroy(gameObject, 1f);
        }
    }
}
