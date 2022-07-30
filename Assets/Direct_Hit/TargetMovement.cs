using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody rb;
    public GameObject menu;
    private int time = 10;
    public Text timerText;
    public static bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        isGameActive = true;
        StartCoroutine(Random_Directions());
        StartCoroutine(Count());
        rb = gameObject.GetComponent<Rigidbody>();
        timerText.text = "Time:" + time.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 3.5f) {
            transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
            speed *= -1;
        }
        else if (transform.position.x < -3.5f) {
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
            speed *= -1;
        }

        if (!isGameActive)
            return;

        rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            menu.SetActive(true);
            isGameActive = false;
        }
    }

    IEnumerator Random_Directions()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            if (transform.position.x > -2.5f && transform.position.x < 2.5f)
            {
                float direction = Random.Range(1, 10);
                if (direction < 8)
                    speed *= -1;
            }
        }
    }

    IEnumerator Count()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            timerText.text = "Time: " + time.ToString();
        }
        menu.SetActive(true);
        isGameActive = false;
    }

    public void Play()
    {
        SceneManager.LoadScene("Direct Hit");
    }
}
