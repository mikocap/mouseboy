using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public GameObject character;
    public GameObject text;
    Animator animator;
    Animator animator1;
    bool keyPressed = false;
    bool isIdle = false;
    public static bool isTalking = false;
    bool Talking = false; 

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        animator = this.GetComponent<Animator>();
        animator1 = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks if idle
        if (animator1.GetFloat("Speed") == 0)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
        // checks button press
        if (Input.GetKeyDown(KeyCode.F))
        {
            keyPressed = true;
        }
        // checks button release
        if (Input.GetKeyUp(KeyCode.F))
        {
            keyPressed = false;
        }
        if (keyPressed == true && Vector3.Distance(character.transform.position, this.transform.position) < 2 && isTalking == false && isIdle == true)
        {
            animator.SetTrigger("TalkTrigger");
            isTalking = true;
            Talking = true;
            character.GetComponent<Player>().enabled = false;
            keyPressed = false;
            text.SetActive(true);
        }
        // stands up 
        if (keyPressed == true && Talking == true)
        {
            animator.SetTrigger("DoneTrigger");
            Debug.Log("Stand!");
            isTalking = false;
            Talking = false;
            character.GetComponent<Player>().enabled = true;
            keyPressed = false;
            text.SetActive(false);
        }
    }
}
