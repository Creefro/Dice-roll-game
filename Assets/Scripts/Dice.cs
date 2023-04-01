using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    public GameObject dice;

    bool hashLanded;
    bool thrown;

    Vector3 accelerationDir;

    Vector3 initPosition;

    public Text text;
    public string diceValue;

    public DiceSide[] diceSides;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        transform.rotation = Random.rotation;
        rb.useGravity = false;
    }

    private void Update()
    {
        accelerationDir = Input.acceleration;

        if (RollNumberTextScript.roll == 0)
        {
            Debug.Log("Hakkýnýz doldu");
            dice.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space)|| accelerationDir.sqrMagnitude >= 5f)
        {
            RollDice();
        }
        if (rb.IsSleeping() && !hashLanded && thrown)
        {
            hashLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;

            SideValueCheck();
        }
        else if(rb.IsSleeping() && hashLanded && diceValue == "")
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if (!thrown &&!hashLanded)
        {
            RollNumberTextScript.roll--;
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            rb.AddForce(transform.up * 20f);
        }
        else if(thrown &&hashLanded)
        {
            Reset();
        }
    }
    void Reset()
    {
        transform.position = initPosition;
        transform.rotation = Random.rotation;
        thrown = false;
        hashLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddForce(transform.up * 20f);


    }

    void SideValueCheck()
    {
        diceValue = "";
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                text.text = diceValue.ToString();
                Debug.Log(diceValue + " has been rolled");
            }
        }
    }
}
