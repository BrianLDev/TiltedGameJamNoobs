using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    public float speed = 2f;
    public float scaredDist = 6f;
    public GameObject fxPrefab;
    public GameObject santa;

    private Animator animator;
    private Rigidbody2D rb2D;
    private Vector2 forceToAdd;
    private float distFromSanta;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distFromSanta = Mathf.Abs(this.transform.position.x - (santa.transform.position.x * santa.transform.localScale.x));
        
        if (distFromSanta <=scaredDist && animator.GetBool("scared") == false) {
            Debug.Log("AHHHH!");
            animator.SetBool("scared", true);
        }
        else if (distFromSanta >= scaredDist && animator.GetBool("scared") == true) {
            Debug.Log("Phew...");
            animator.SetBool("scared", false);
        }
    }
    
    void FixedUpdate() {
        if(Random.Range(0,100) <= 2) {
            // xx% of the time, change the force and direction velocity of the elf to simulate moving running, jogging, slowing down
            speed = Random.Range(-1f, 0.5f) * 2.25f;  
            forceToAdd = new Vector2(speed, 0f);
        }
        rb2D.AddForce(forceToAdd);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.tag == "Player") {
            // NOTE: This block of code was used for gameplay if the elves are "collected" when rudolph hits them.  Trying out something different now but keep this in case I want to go back.
            // Instantiate(fxPrefab, this.transform.position, Quaternion.identity);
            // Destroy(fxPrefab, 3f);     // kill off the effect after 3 seconds
            // Destroy(this.gameObject);

            // NOTE: This is the nudge Velocity mechanic.  Trying out multiple options
            if (hitFromAbove) {
                if (hitFromLeft) {   this.transform.position += (Vector3.right * 1.1f);   }
                else {   this.transform.position += (Vector3.left * 1.1f);   }
            }
            else {
                // if (hitFromLeft) {   rb2D.velocity += Vector2.right;   }
                // else {   rb2D.velocity += Vector2.right;   }
            }
        }
        else if (coll.collider.tag == "Santa") {
            Debug.Log("Mmmmmm... elves");
            animator.SetBool("eaten", true);
            GameObject bloodFX = Instantiate(fxPrefab, transform.position, Quaternion.identity);
            bloodFX.transform.parent = GameObject.Find("_Dynamic").transform;
            Destroy(this.gameObject);
            Destroy(bloodFX.gameObject, 3f);
        }
    }
}
