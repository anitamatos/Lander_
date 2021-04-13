using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 15f;

    void Update()
    {
        // Clicar as duas teclas ao mesmo tempo 

        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
        }
    }


    // Como saber se bati?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma") // Quando toca na plataforma
        {
            Debug.Log("Aterrei"); //-> Só para ver como funciona, que aterra corretamente 
            Debug.Log(collision.relativeVelocity);
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("...Mas Expoldi");
            }

        }
        else
        {
            Debug.Log("Expoldir");    // Quando toca na Lua
        }
    }
}


