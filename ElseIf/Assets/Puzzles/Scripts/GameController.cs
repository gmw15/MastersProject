using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Sprite bgImage;

    //[SerializeField]
    //private Sprite bgImage2;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
    }

	void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i<objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
            //btns[0].image.sprite = bgImage2;
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i=0; i < looper; i++){

            //reset the image back to 0 to add the same image in twice
            //MIGHT BE WHERE TO CHANGE IT!!
            if (index == looper)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            index++;

        }
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log("Working! Yay! with name "+name);

        //GET THE NAME OF THE IMAGE AND CHECK IF THE IMAGE IS THE SAME AND IF SO MATCH
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //GET THE NAME OF THE IMAGE
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //GET THE NAME OF THE IMAGE
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        //IF WE GUESS CORRECTLY

        //HOW TO CHECK DIFFERENT PHOTOS ON TOP OF EACH OTHER!!! VP
        if (firstGuessPuzzle == "int" && secondGuessPuzzle == "number" || firstGuessPuzzle == "number" && secondGuessPuzzle == "int")
        {
            //disable buttons once guess is correct
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;

            btns[secondGuessIndex].interactable = false;

            //CHANGE BACKGROUNDS TO BE BLANK
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }

        if (firstGuessPuzzle == "string" && secondGuessPuzzle == "name" || firstGuessPuzzle == "name" && secondGuessPuzzle == "string")
        {
            //disable buttons once guess is correct
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;

            btns[secondGuessIndex].interactable = false;

            //CHANGE BACKGROUNDS TO BE BLANK
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }

        if (firstGuessPuzzle == "decimal" && secondGuessPuzzle == "double" || firstGuessPuzzle == "double" && secondGuessPuzzle == "decimal")
        {
            //disable buttons once guess is correct
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;

            btns[secondGuessIndex].interactable = false;

            //CHANGE BACKGROUNDS TO BE BLANK
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }

        if (firstGuessPuzzle == "boolean" && secondGuessPuzzle == "true" || firstGuessPuzzle == "true" && secondGuessPuzzle == "boolean")
        {
            //disable buttons once guess is correct
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;

            btns[secondGuessIndex].interactable = false;

            //CHANGE BACKGROUNDS TO BE BLANK
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }


        //if(firstGuessPuzzle == secondGuessPuzzle)
        //{
        //disable buttons once guess is correct
        //    yield return new WaitForSeconds(.5f);

        //    btns[firstGuessIndex].interactable = false;

        //    btns[secondGuessIndex].interactable = false;

        //    //CHANGE BACKGROUNDS TO BE BLANK
        //    btns[firstGuessIndex].image.color = new Color(0,0,0,0);
        //    btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

        //    CheckIfTheGameIsFinished();
        //}

        //IF ITS WRONG RETURN THEM BACK TO BE NORMAL IMAGE AGAIN
        else
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = false;
        secondGuess = false;



    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished");
            Debug.Log("It took you " + countGuesses + " to finish the game");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i=0; i<list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}
