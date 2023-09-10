using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemylife : MonoBehaviour

{ 

   private Animator Anim;
   private Rigidbody2D rb;
  [SerializeField] private AudioSource DeathSound;



    // Start is called before the first frame update
    void Start()
    {
       Anim = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Water"))
        Die();
        ShowEndGameScene();

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Anim.SetTrigger("IsDead");
        DeathSound.Play();
        StartCoroutine(ShowEndGameScene());
    }

   /* private void Restartlevel1()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    IEnumerator ShowEndGameScene()
    {
        // Wait for 6 seconds before loading the end game scene
        yield return new WaitForSeconds(3f);

        // Load the end game scene
        SceneManager.LoadScene("EndGame");
    }


}
