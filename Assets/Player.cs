using System.Transactions;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float jump = 10f;
    public string CurrentColor;
    public Rigidbody2D circle;

    public SpriteRenderer sr;
    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;
    public static int score = 0;
    public Text scoreText;
   
   
    public GameObject colorchanger;
    // public AudioSource audioSource;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem particles1;
    [SerializeField] ParticleSystem particles2;
    [SerializeField] ParticleSystem particles3;
    [SerializeField] ParticleSystem particles4;



    void Start()
    {
        setRandomColor();

    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.up * jump;
            jumpSound.Play();
        }

        scoreText.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.tag);

        if (collision.tag == "Score")
        {
            score++;
            particles.Play();
            Destroy(collision.gameObject);
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)

                Instantiate(obstical[0], new Vector2(transform.position.x, transform.position.y + 9f), transform.rotation);

            // if (randomNumber == 1)

            //     Instantiate(obstical[1], new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
            else
                Instantiate(obstical[1], new Vector2(transform.position.x, transform.position.y + 20f), transform.rotation);
            return;
        }


        if (collision.tag == "ColorChanger")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorchanger, new Vector2(transform.position.x, transform.position.y + 9f), transform.rotation);
            return;

        }
        if (collision.tag != CurrentColor )
        {
            Debug.Log("You Died");
            //trigger level3
            SceneManager.LoadScene("Level3");

            score = 0;
       


        }

        //make a exception for collision with other sprites     


    }

    void setRandomColor()
    {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:

                CurrentColor = "Blue";
                sr.color = blue;
                particles1.Play();
                break;

            case 1:
                CurrentColor = "Yellow";
                sr.color = yellow;
                particles2.Play();
                break;

            case 2:
                CurrentColor = "Pink";
                sr.color = pink;
                particles4.Play();
                break;

            case 3:
                CurrentColor = "Purple";
                sr.color = purple;
                particles3.Play();
                break;
        }
    }

    //change color of particles
    // public void ChangeColor()
    // {
    //     var main = particles.main;
    //     main.startColor = sr.color;
    // }

}
