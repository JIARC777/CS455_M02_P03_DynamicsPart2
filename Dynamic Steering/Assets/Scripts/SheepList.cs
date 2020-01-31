using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SheepList : MonoBehaviour
{
    public List<GameObject> sheepL;
    public int totalNumberOfSheep;
    public Text numSheep;
    // Start is called before the first frame update
    void Start()
    {
        // Create a list and populate it with all the sheep tagged objects in game
        sheepL = new List<GameObject>();
        foreach (GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep"))
        {
            sheepL.Add(sheep);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame update the count of sheep and check to see if the list is empty
        totalNumberOfSheep = sheepL.Count;
        numSheep.text = sheepL.Count.ToString();
        if (totalNumberOfSheep == 0)
            Restart();
    }
    
    // gets called on collision with a sheep
    public void DeleteSheep(GameObject sheepToDelete)
    {
        // If a sheep needs to be deleted, remove from list and destroy
        sheepL.Remove(sheepToDelete);
        Destroy(sheepToDelete);
    }

    // when wolf requests a new target
    public int AssignTarget()
    {
        // Generate a number within the total number of sheep left
        int targetNumber = Random.Range(0, totalNumberOfSheep);
        // Check to see if a sheep with that index exists in the list and assign the number
        targetNumber = sheepL[targetNumber] != null ? targetNumber : AssignTarget();
        return targetNumber;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
