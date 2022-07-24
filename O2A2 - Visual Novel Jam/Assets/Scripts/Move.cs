using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();   
    }

   void MoveObject()
    {
        float movingHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float movingVertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(movingHorizontal, movingVertical, 0);
    }
}
