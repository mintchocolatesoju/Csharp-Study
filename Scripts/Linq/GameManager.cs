using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using UnityEngine.UIElements;

[Serializable]
public class PlayerData
{
   [NonSerialized]
    public float Distance;

    [NonSerialized]
    public int Rank;
    public string playerName;
}
public class GameManager : MonoBehaviour
{
    public float gameTime = 30.0f;
    private float battleDuration = 0f;
    
    public List<PlayerData> Players = new List<PlayerData>();

    public RaceButton raceButton;
    public Transform raceButtonParent;
    private List<RaceButton> raceButtons = new List<RaceButton>();
    
    IEnumerator GameTimer()
    {
          
        
        
        for (int i = 0; i < Players.Count; i++)
        {
            var newObj = Instantiate(raceButton.gameObject, raceButtonParent);
            raceButtons.Add(newObj.GetComponent<RaceButton>());
        }
        
        while (gameTime >= 0.0f)
        {
            Debug.Log("Game time: " + gameTime);
            yield return new WaitForSeconds(1.0f);

            foreach (PlayerData player in Players)
            {
                player.Distance += Random.Range(0.0f, 1.0f);
            }
           List<PlayerData> ranks =(from p in Players orderby p.Distance select p).ToList();
           for (int i = 0; i < ranks.Count; i++)
           {
               Debug.Log($"Rank {i+1} :{ranks[i].playerName}/distance: {ranks[i].Distance}");
               
               raceButtons[i].text.text = ranks[i].playerName;
           }
           gameTime -= 1.0f;
        }
    }
    
    public 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(0>= battleDuration)
            return;
        if (battleDuration >= 1.0f)
        {
            Debug.Log(battleDuration);
            
            gameTime -= 1.0f;
            battleDuration = 0.0f;
        }
        battleDuration += Time.deltaTime;
    }
}
