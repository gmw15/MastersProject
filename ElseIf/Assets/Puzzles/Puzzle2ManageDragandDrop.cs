using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2ManageDragandDrop : MonoBehaviour
{
    Vector3 initialPosition;
    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position; //we save the initial position of the object
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Drag()
    {
        //The image position will become the mouse position
        GameObject.Find("Image").transform.position = Input.mousePosition;
        print("we are dragging the mouse");
    }
    public void Drop()
    {
        //The image position will snap to the position of the placeholder
        //loop through the placeholders
        for (int i = 1; 1 <= 4; i++)
        {
            GameObject ph1 = GameObject.Find("Placeholder" + i); //placeholder 1-2-3
            float distance = Vector3.Distance(GameObject.Find("Image").transform.position, ph1.transform.position);
            print("distance + distance");
            if (distance < 50)
            {
                if (ph1.tag == "match")
                {
                    GameObject.Find("Image").transform.position = ph1.transform.position;
                    print("Correct Code");
                }
                else
                {
                    GameObject.Find("image").transform.position = initialPosition;
                    print("INCORRECT CODE");
                }
                }
            else
            {
                GameObject.Find("image").transform.position = initialPosition;
            }
        }
    }
}
