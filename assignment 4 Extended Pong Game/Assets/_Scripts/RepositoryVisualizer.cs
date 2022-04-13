using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepositoryVisualizer : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite wallSprite;
    public Sprite ballSprite;
    public Sprite playerSprite;
    public Sprite brickSprite;

    Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        images = gameObject.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(BallMovement.repositoryDict.Count);

        UpdateRepositoryDisplay();
    }

    public void UpdateRepositoryDisplay()
    {
        // write the following line here will cause an out-of-range error
        // the length of images in first frame in this game is only 1 (the ball is added to the dictionary)
        //Image[] images = gameObject.GetComponentsInChildren<Image>();
        //Debug.Log("images lenghth: " + images.Length);

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

            images[i].sprite = currentSprite;
            images[i].gameObject.SetActive(true);
            List<Transform> list;
            BallMovement.repositoryDict.TryGetValue(key, out list);
            images[i].GetComponentInChildren<TextMeshProUGUI>().text = list.Count.ToString();
            i++;
        }
    }
}
