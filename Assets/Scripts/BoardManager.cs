using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    int mapWidth = 8;
    [SerializeField]
    int mapHeight = 8;

    [SerializeField]
    GameObject[] floors;
    [SerializeField]
    GameObject[] outerWalls;
    [SerializeField]
    GameObject[] walls;
    [SerializeField]
    GameObject[] foods;
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    GameObject exit;
    [SerializeField]
    GameObject player;

    List<Vector2> coordinates = new List<Vector2>();

    void Awake()
    {
        Init();
    }

    void Init()
    {
        SpawnBoard();
        SpawnObjects();
    }

    void SpawnBoard()
    {
        GameObject enviroment = new GameObject("Environment");
        GameObject floor;
        GameObject outerWall;

        for (int i = 0; i <= mapWidth + 1; i++)
        {
            for (int j = 0; j <= mapHeight + 1; j++)
            {
                if (i == 0 || j == 0 || i == mapWidth + 1 || j == mapHeight + 1)
                {
                    outerWall = outerWalls[Random.Range(0, outerWalls.Length)];
                    Instantiate(outerWall, new Vector3(i, j, 0f), Quaternion.identity).transform.parent = enviroment.transform;
                }
                else
                {
                    floor = floors[Random.Range(0, floors.Length)];
                    Instantiate(floor, new Vector3(i, j, 0f), Quaternion.identity).transform.parent = enviroment.transform;
                }
            }
        }
    }

    void SpawnObjects()
    {
        coordinates.Clear();

        for (int i = 2; i <= 7; i++)
        {
            for (int j = 2; j <= 7; j++)
            {
                coordinates.Add(new Vector2(i, j));
            }
        }

        GameObject interactiveObject = new GameObject("InteractiveObjects");
        GameObject wall;
        GameObject food;
        GameObject enemy;

        for (int i = 0; i < Random.Range(5, 9); i++)
        {
            wall = walls[Random.Range(0, walls.Length)];
            Vector2 pos = coordinates[Random.Range(0, coordinates.Count)];
            Instantiate(wall, new Vector3(pos.x, pos.y, 0f), Quaternion.identity).transform.parent = interactiveObject.transform;
            coordinates.Remove(pos);
        }

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            food = foods[Random.Range(0, foods.Length)];
            Vector2 pos = coordinates[Random.Range(0, coordinates.Count)];
            Instantiate(food, new Vector3(pos.x, pos.y, 0f), Quaternion.identity).transform.parent = interactiveObject.transform;
            coordinates.Remove(pos);
        }

        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            enemy = enemies[Random.Range(0, enemies.Length)];
            Vector2 pos = coordinates[Random.Range(0, coordinates.Count)];
            Instantiate(enemy, new Vector3(pos.x, pos.y, 0f), Quaternion.identity).transform.parent = interactiveObject.transform;
            coordinates.Remove(pos);
        }

        Instantiate(exit, new Vector3(8f, 8f, 0f), Quaternion.identity).transform.parent = interactiveObject.transform;

        Instantiate(player, new Vector3(1f, 1f, 0f), Quaternion.identity);
    }


}
