using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuel : MonoBehaviour
{
    [SerializeField]
    float combustivel = 500f;

    [SerializeField]
    float turnVelocity = 1f;
    [SerializeField]
    float thurstVelocity = 1f;
    [SerializeField]
    float combustivelGasto = 10f;
    [SerializeField]
    float combustivelGastoTorque = 5f;
    public Rigidbody2D RigidBody;


    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (combustivel > 0)
            {
                RigidBody.AddForce(transform.up * thurstVelocity * Time.deltaTime);
                combustivel -= combustivelGasto * Time.deltaTime;
                Debug.Log(combustivel.ToString());
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (combustivel > 0)
            {
                RigidBody.AddTorque(-turnVelocity * Time.deltaTime);
                combustivel -= combustivelGastoTorque * Time.deltaTime;
                Debug.Log(combustivel.ToString());
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (combustivel > 0)
            {
                RigidBody.AddTorque(turnVelocity * Time.deltaTime);
                combustivel -= combustivelGastoTorque * Time.deltaTime;
                Debug.Log(combustivel.ToString());
            }
        }
        if (combustivel <= 0 && combustivel > -1)
        {
            Debug.Log("GAME OVER");

        }

    }

}

