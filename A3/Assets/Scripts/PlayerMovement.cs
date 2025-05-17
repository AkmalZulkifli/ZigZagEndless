using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector3 dir;

    public GameObject particle;

    private bool isDead;

    public GameObject levelControl;

    public AudioSource coinFX;

    public LayerMask whatIsGround;

    private bool isPlaying = false; 

    public Transform contactPoint;
    public GameObject prompt;
    public GameObject leftPanel;
    public GameObject rightPanel;
    void Start()
    {
        isDead = false;
        Time.timeScale = 0;
        dir = Vector3.zero;
    }

    void Update()
    {

        if (!IsGrounded() && isPlaying)
        {
            isDead = true;
            levelControl.GetComponent<LevelDistance>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;

            if (transform.childCount > 0)
            {
                transform.GetChild(0).transform.parent = null;
            }
        }


        //if (Input.GetMouseButtonDown(0) && !isDead)
        //{
        //    isPlaying = true;
        //    prompt.SetActive(false);
        //    if (dir == Vector3.forward)
        //    {
        //        dir = Vector3.left;
        //    }
        //    else
        //    {
        //        dir = Vector3.forward;
        //    }
        //}

        //if (Input.touchCount > 0 & !isDead)
        //{
        //    isPlaying = true;
        //    prompt.SetActive(false);
        //    var touch = Input.touches[0];
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        if (dir == Vector3.forward)
        //        {
        //            dir = Vector3.left;
        //        }
        //        else
        //        {
        //            dir = Vector3.forward;
        //        }
        //    }
            //else if (touch.position.x > Screen.width / 2)
            //{
            //    if (dir == Vector3.forward)
            //    {
            //        dir = Vector3.zero;
            //    }
            //}
        //}

        if (Input.touchCount > 0 && !isDead)
        {
            isPlaying = true;
            Time.timeScale = 1;
            prompt.SetActive(false);
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);
            
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (dir == Vector3.forward)
                    {
                        dir = Vector3.left;
                    }
                    else
                    {
                        dir = Vector3.forward;
                    }
                }
            }
            else if (touch.position.x > Screen.width / 2)
            {
                if (Input.GetTouch(1).phase == TouchPhase.Stationary)
                {
                    if (dir == Vector3.forward)
                    {
                        dir = Vector3.zero;
                    }
                    else
                    {
                        dir = Vector3.forward;
                    }
                }
            }
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            CollectibleControl.coinCount += 1;
            other.gameObject.SetActive(false);
            coinFX.Play();
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            isDead = true;
            transform.GetChild(0).transform.parent = null;
            levelControl.GetComponent<LevelDistance>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, .5f, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
