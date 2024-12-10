using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ArrayExamples : MonoBehaviour
{
    #region  Values
    
    private const int ArraySize = 10;
    private int[] playerScores= new int[ArraySize];
    
    //private int[] playerScores = new int[5];

    // 아이템 이름을 저장하는 배열
    private string[] itemNames = { "검", "방패", "포션", "활", "마법서" };

    // 적 프리팹을 저장하는 배열
    public GameObject[] enemyPrefabs;

    // 맵의 타일 타입을 저장하는 2D 배열
    private int[,] mapTiles = new int[10, 10];

    public GameObject Cube;

    public GameObject cube2;
    
    private GameObject[,] CubeTiles = new GameObject[10, 10];
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerScoresExample();
        //ItemInventoryExample();
        //EnemySpawnExample();
        MapGenerationExample();
    }
    /// <summary>
    ///  아이템 인벤토리 예시
    /// </summary>
    void ItemInventoryExample()
    {
        // 랜덤 아이템 선택
        int randomIndex = Random.Range(0, itemNames.Length);
        string selectedItem = itemNames[randomIndex];
        Debug.Log($"선택된 아이템: {selectedItem}");

        string itemName = "포션";
        
        // Contains 직접 구현
        bool hasPotion1 = Contains(itemName);
        Debug.Log($"포션 보유 여부: {hasPotion1}");

        // 특정 아이템 검색
        string searchItem = "방패";
        bool hasPotion2 = itemNames.Contains(searchItem);
        Debug.Log($"포션 보유 여부: {hasPotion2}");
    }

    private bool Contains(string itemName)
    {
        // Array의 Contains을 구현하는 방법
        for (var i = 0; i < itemNames.Length; i++)
        {
            if (itemNames[i] == itemName)
            {
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void PlayerScoresExample()
    {
        for (int i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = Random.Range(100, 1000);
        }

        Highest();

        Average();
        
        // 평균 점수 계산
       double averageScore = playerScores.Average();
        Debug.Log($"평균 점수: {averageScore:F2}");
    }

    private void Highest()
    {
        int maxValue = 0;
        for (int i = 0; i < playerScores.Length; i++)
        {
            if (playerScores[i] > maxValue)
            {
                maxValue = playerScores[i];
            }
        }
        
        Debug.Log($"Max Value: {maxValue}");
        // 최고 점수 찾기
        int highestScore = playerScores.Max();
        Debug.Log($"최고 점수: {highestScore}");
    }

    private void Average()
    {
        int totalValue = 0;
        float averageValue = 0;

        for (int i = 0; i < playerScores.Length; i++)
        {
            totalValue += playerScores[i];
        }
        
        averageValue = totalValue/= playerScores.Length;
        Debug.Log($"평균 점수: {averageValue:F2}");
    }

    void EnemySpawnExample()
    {
        if (enemyPrefabs != null && enemyPrefabs.Length > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f));
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
            Debug.Log($"적생성: {enemyPrefabs[randomEnemyIndex].name}");
        }
        else
        {
            {
                Debug.LogWarning("프리팹 없음");
            }
        }
    }

    void MapGenerationExample()
    {
        
        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
            {
                mapTiles[x, y] = Random.value > 0.8f ? 1 : 0;
            }
        }
        

        string mapString = "생성된맵:\n";
        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
               //CubeTiles[x,y] = mapTiles[x,y] ==1? Instantiate(Cube):null;
                //mapString += mapTiles[x, y] == 1 ? "■ " : "□ ";
            //mapString += "\n";
                if (mapTiles[x, y] == 1)
                {
                    CubeTiles[x, y] = Instantiate(Cube, new Vector3(x - 5, 0, y - 5), Quaternion.identity);
                }
                else
                {
                    CubeTiles[x, y] = Instantiate(cube2, new Vector3(x - 5,  0, y-5), Quaternion.identity);
                }
        }
        Debug.Log(mapString);

    }
    
}
