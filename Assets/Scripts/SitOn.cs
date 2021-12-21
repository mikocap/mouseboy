using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOn : MonoBehaviour
{
    public GameObject character;
    public GameObject chair;
    Animator animator;
    public static bool isSitting = false;
    bool Sit = false;
    bool isIdle = false;
    bool keyPressed = false;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
        collider = chair.GetComponent<BoxCollider>();
    }
    // stand animation and transform
    IEnumerator Stand()
    {
        animator.SetTrigger("StandTrigger");
        yield return new WaitForSeconds(1.417f);
        character.transform.Translate(Vector3.back * 0.55f);
        yield return new WaitForSeconds(0.01f);
        character.transform.Rotate(Vector3.up, 180f);
    }
    // Update is called once per frame
    void Update()
    {
        // checks if idle
        if (animator.GetFloat("Speed") == 0)
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
        // sits down
        if (keyPressed == true && Vector3.Distance(character.transform.position, this.transform.position) < 2 && isSitting == false && isIdle == true)
        {
            collider.enabled = false;
            character.transform.Translate(Vector3.forward * 0.4f);
            animator.SetTrigger("SitTrigger");
            Debug.Log("Sit!");
            isSitting = true;
            Sit = true;
            character.GetComponent<Player>().enabled = false;
            keyPressed = false;
        }
        // stands up 
        if (keyPressed == true && Sit == true)
        {
            StartCoroutine("Stand");
            Debug.Log("Stand!");
            isSitting = false;
            Sit = false;
            character.GetComponent<Player>().enabled = true;
            keyPressed = false;
            collider.enabled = true;
        }
    }

}
