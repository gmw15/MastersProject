using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2ManageDragandDrop : MonoBehaviour
{
    Vector3 initialPosition = new Vector3(470,220,0);
    Vector3 initialPosition2 = new Vector3(470, 180, 0);
    Vector3 initialPosition3 = new Vector3(470, 140, 0);
    Vector3 initialPosition4 = new Vector3(470, 100, 0);
    int correctCount;
    int wrongCount;
    //private var spawnPos : Vector3;
    // Use this for initialization
    void Start()
    {
        //initialPosition = gameObject.transform.position;
        //initialPosition = (233,0,0);//we save the initial position of the object
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        //initialPosition = transform.position;
    }

    public void Drag()
    {
        //The image position will become the mouse position
        GameObject.Find("Image").transform.position = Input.mousePosition;
        //print("we are dragging the mouse");
    }
    public void Drag2()
    {
        //The image position will become the mouse position
        GameObject.Find("Image2").transform.position = Input.mousePosition;
        //print("we are dragging the mouse");
    }
    public void Drag3()
    {
        //The image position will become the mouse position
        GameObject.Find("Image3").transform.position = Input.mousePosition;
        //print("we are dragging the mouse");
    }
    public void Drag4()
    {
        //The image position will become the mouse position
        GameObject.Find("Image4").transform.position = Input.mousePosition;
        //print("we are dragging the mouse");
    }
    public void Drop()
    {
        //The image position will snap to the position of the placeholder
        //loop through the placeholders
        for (int i = 1; i <= 4; i++)
        {
            GameObject ph1 = GameObject.Find("Placeholder" + i); //placeholder 1-2-3
            float distance = Vector3.Distance(GameObject.Find("Image").transform.position, ph1.transform.position);
           // print("distance + distance");

            if (distance < 50)
            {
                if (ph1.tag == "Match")
                {
                    GameObject.Find("Image").transform.position = ph1.transform.position;
                    print("Correct Code");
                    correctCount++;
                    CheckPuzzleComplete();
                }
                else
                {
                    GameObject.Find("Image").transform.position = initialPosition;
                    print("INCORRECT CODE");
                    wrongCount++;
                }
            }
        }
    }
    public void Drop2()
    {
        //The image position will snap to the position of the placeholder
        //loop through the placeholders
        for (int i = 1; i <= 4; i++)
        {
            GameObject ph1 = GameObject.Find("Placeholder" + i); //placeholder 1-2-3
            float distance = Vector3.Distance(GameObject.Find("Image2").transform.position, ph1.transform.position);
            //print("distance + distance");

            if (distance < 50)
            {
                if (ph1.tag == "Match2")
                {
                    GameObject.Find("Image2").transform.position = ph1.transform.position;
                    print("Correct Code");
                    correctCount++;
                    CheckPuzzleComplete();
                }
                else
                {
                    GameObject.Find("Image2").transform.position = initialPosition2;
                    print("INCORRECT CODE");
                    wrongCount++;
                }
            }
        }
    }

    public void Drop3()
    {
        //The image position will snap to the position of the placeholder
        //loop through the placeholders
        for (int i = 1; i <= 4; i++)
        {
            GameObject ph1 = GameObject.Find("Placeholder" + i); //placeholder 1-2-3
            float distance = Vector3.Distance(GameObject.Find("Image3").transform.position, ph1.transform.position);
           // print("distance + distance");

            if (distance < 50)
            {
                if (ph1.tag == "Match3")
                {
                    GameObject.Find("Image3").transform.position = ph1.transform.position;
                    print("Correct Code");
                    correctCount++;
                    CheckPuzzleComplete();
                }
                else
                {
                    GameObject.Find("Image3").transform.position = initialPosition3;
                    print("INCORRECT CODE");
                    wrongCount++;
                }
            }
        }
    }

    public void Drop4()
    {
        //The image position will snap to the position of the placeholder
        //loop through the placeholders
        for (int i = 1; i <= 4; i++)
        {
            GameObject ph1 = GameObject.Find("Placeholder" + i); //placeholder 1-2-3
            float distance = Vector3.Distance(GameObject.Find("Image4").transform.position, ph1.transform.position);
            //print("distance + distance");

            if (distance < 50)
            {
                if (ph1.tag == "Match4")
                {
                    GameObject.Find("Image4").transform.position = ph1.transform.position;
                    print("Correct Code");
                    correctCount++;
                    CheckPuzzleComplete();
                }
                else
                {
                    GameObject.Find("Image4").transform.position = initialPosition4;
                    print("INCORRECT CODE");
                    wrongCount++;
                }
            }
        }
    }
    void CheckPuzzleComplete()
    {
        int overallCount = correctCount + wrongCount;
        if(correctCount == 4)
        {
            print("PUZZLE COMPLETED IN "+ overallCount + " GUESSES");
        }
        else if (correctCount == 3)
        {
            print("1 MORE TO GO");
        }
        else if (correctCount == 2)
        {
            print("2 MORE TO GO");
        }
        else if (correctCount == 1)
        {
            print("3 MORE TO GO");
        }
    }
}
