using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam3rdPerson : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    [Range(0,1)]public float lerpValue;
    public float sens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, lerpValue); //Mover la pos de la camara hacia el personaje (+ la distancia al jugador) de forma suave, con una velocidad determianda (lerpValue)
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sens, Vector3.up) * offset;

        transform.LookAt(player);
    }
}
