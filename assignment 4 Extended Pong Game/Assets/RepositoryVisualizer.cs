using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepositoryVisualizer : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite wallSprite;
    public Sprite ballSprite;
    public Sprite playerSprite;
    public Sprite brickSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BallMovement.repositoryDict.Count);
    }

    public void UpdateRepositoryDisplay()
    {
        Image[] images = gameObject.GetComponentsInChildren<Image>();
        foreach(Image img in images)
        {
            img.gameObject.SetActive(false);
        }

        int i = 0;
        Sprite currentSprite = defaultSprite;

        foreach(string key in BallMovement.repositoryDict.Keys)
        {
            switch(key)
            {
                case "Wall": currentSprite = wallSprite; break;
                case "Ball": currentSprite = ballSprite; break;
                case "Player": currentSprite = playerSprite; break;
                case "Brick": currentSprite = brickSprite; break;
                default: currentSprite = defaultSprite; break;
            }
        }
    }
}
