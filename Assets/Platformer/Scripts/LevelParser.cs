using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();

            
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                var dirt = Instantiate(rockPrefab);
                var brick = Instantiate(brickPrefab);
                var question = Instantiate(questionBoxPrefab);
                var stone = Instantiate(stonePrefab);
                // Todo - Position the new GameObject at the appropriate location by using row and column
                if(letter== 'x')
                {
                    dirt.transform.position = new Vector3(column, row, 0f);
                    dirt.transform.parent = environmentRoot;
                }else if(letter== '?')
                {
                    question.transform.position = new Vector3(column, row, 0f);
                    question.transform.parent = environmentRoot;
                }
                else if(letter== 'b')
                {
                    brick.transform.position = new Vector3(column, row, 0f);
                    brick.transform.parent = environmentRoot;
                }
                else if (letter == 's')
                {
                    stone.transform.position = new Vector3(column, row, 0f);
                    stone.transform.parent = environmentRoot;
                }
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
