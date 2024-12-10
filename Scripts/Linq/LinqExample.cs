using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public struct MonsterTest
{
    public string name;
    public int health;
}



public class LinqExample : MonoBehaviour
{
    public List<MonsterTest> monsters = new List<MonsterTest>()
    {
        new MonsterTest() { name = "A", health = 100 },
        new MonsterTest() { name = "B", health = 100 },
        new MonsterTest() { name = "A", health = 10 },
        new MonsterTest() { name = "B", health = 10 },
        new MonsterTest() { name = "C", health = 100 },
        new MonsterTest() { name = "C", health = 10 },
        new MonsterTest() { name = "D", health = 100 },

    };
    
    // Start is called before the first frame update
    void Start()
    {
        List<MonsterTest> filters = new List<MonsterTest>();
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].name == "A" && monsters[i].health >=10)
            {
                filters.Add(monsters[i]);
            }
        }
        filters.Sort((l,r)=>l.health>= r.health ? -1 : 1);
        for (int i = 0; i < filters.Count; i++)
        {
            Debug.Log($"Name: {filters[i].name}, Health: {filters[i].health}");
        }

        List<MonsterTest> LinqFilter =monsters.Where(e => e.name == "A" && e.health >= 10)
            .OrderByDescending(e => e.health).ToList();

        for (int i = 0; i < LinqFilter.Count; i++)
        {
            Debug.Log($"Name: {LinqFilter[i].name}, Health: {LinqFilter[i].health}");   
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
