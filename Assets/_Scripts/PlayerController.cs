using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string name = "David";
    public float speed;
    Rigidbody rb;
    public float life;
    public int score;
    public float jumpForce;
    public float time;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        //definir variables
        speed = 15;
        life =3f;
        score = 0;
        jumpForce = 10f;
        time = 60f;

        Debug.Log("Hello "+name+".");
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0,0);
        transform.Rotate(0,Input.GetAxis("Horizontal") / 2,0);

        //die
        if (life <= 0 || time <= 0)
        {
            SceneManager.LoadScene("Test");
        }

        //reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Test");
        }

        //go to main menu
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2f;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }

        //timer
        time -= Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            life--;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Coin")
        {
            score++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Potion" && life < 3)
        {
            life++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Death")
        {
            SceneManager.LoadScene("Test");
        }
        else if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            Destroy(door);

        }
    }
}
