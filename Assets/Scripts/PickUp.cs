using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject character;
    public GameObject hand;
    public GameObject ground;
    Animator animator;
    bool isIdle = false;
    bool keyPressed = false;
    public static bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
    }
    // picks up object
    IEnumerator Pick()
    {
        animator.SetTrigger("PickTrigger");
        yield return new WaitForSeconds(0.4f);
        this.transform.parent = hand.transform;
        this.transform.localEulerAngles = new Vector3(-0.144f, -90f, -83.171f);
        this.transform.localPosition = new Vector3(-0.00013f, 0.00109f, 0.00118f);
    }
    IEnumerator Drop()
    {
        animator.SetTrigger("PickTrigger");
        yield return new WaitForSeconds(0.4f);
        this.transform.parent = ground.transform;
        this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        this.transform.localPosition = new Vector3(100f, 100f, 100f);
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
        // picks up the flower
        if (keyPressed == true && Vector3.Distance(character.transform.position, this.transform.position) < 0.75 && isIdle == true && isHolding == false)
        {
            StartCoroutine("Pick");
            Debug.Log("Picked Up");
            isHolding = true;
            keyPressed = false;
        }
        // drops the flower
        if (keyPressed == true && Vector3.Distance(character.transform.position, this.transform.position) < 0.75 && isIdle == true && isHolding == true)
        {
            StartCoroutine("Drop");
            Debug.Log("Dropped");
            isHolding = false;
            keyPressed = false;
        }
    }

}
