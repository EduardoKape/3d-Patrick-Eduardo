using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce;
    public float gravityModifier;
    public bool isonGround = true;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump");
        if (space != 0 && isonGround && !GameController.gameOver) {
            playerAnim.SetTrigger("Jump_trig");
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameController.gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();

            Invoke("GoGameOver", 2f);
        }
    }

    void GoGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}