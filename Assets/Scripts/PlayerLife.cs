using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource dieEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        { 
         Death();
        }
       
    }
    private void Death()
    {
        dieEffect.Play();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("death");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
