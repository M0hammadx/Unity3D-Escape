using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsaw : MonoBehaviour
{
    public enum Blank_Type
    {
        SINGLE_BLANK, MULTI_BLANK
    }
    public Blank_Type blank_Type;
    public GameObject[] go;
    public Transform[,] matrix = new Transform[Constants.MaxColumns, Constants.MaxRows];
    public Transform[,] ans = new Transform[Constants.MaxColumns, Constants.MaxRows];
    public Transform moveFrom;
    public Vector3 sideSize;
    public bool Won;
    void Start()
    {
        sideSize.x *= transform.localScale.x;
        sideSize.y *= transform.localScale.y;
        sideSize.z *= transform.localScale.z;

        for (int i = 0; i < Constants.MaxColumns; i++)
        {
            for (int j = 0; j < Constants.MaxRows; j++)
            {
                go[i * Constants.MaxColumns + j].transform.position = new Vector3(j * sideSize.x, -i * sideSize.y, 0);
                ans[i, j] = go[i * Constants.MaxColumns + j].transform;
                matrix[i, j] = go[i * Constants.MaxColumns + j].transform;

                //add a box collider the the raycast to work properly
                if (go[i * Constants.MaxColumns + j].GetComponent<BoxCollider>() == null)
                    go[i * Constants.MaxColumns + j].AddComponent<BoxCollider>();

                if (go[i * Constants.MaxColumns + j].GetComponent<pieceTryMove>() == null)
                    go[i * Constants.MaxColumns + j].AddComponent<pieceTryMove>();


            }
        }
        //Shuffle();

        InvokeRepeating("chechWin", 2, 10);
    }

    bool chechWin()
    {
        for (int i = 0; i < Constants.MaxColumns; i++)
        {
            for (int j = 0; j < Constants.MaxRows; j++)
            {
                if (matrix[i, j] != ans[i, j])
                {
                    return false;
                }

            }
        }
        onWin();
        return true;
    }
    void onWin()
    {
        Won = true;
    }
    private void Shuffle()
    {
        //shuffle
        for (int i = 0; i < Constants.MaxColumns; i++)
        {
            for (int j = 0; j < Constants.MaxRows; j++)
            {

                int random_i = Random.Range(0, Constants.MaxColumns);
                int random_j = Random.Range(0, Constants.MaxRows);
                //swap'em
                Swap(i, j, random_i, random_j);
            }
        }
    }
    private void Swap(int i, int j, int random_i, int random_j)
    {
        Vector3 temp = matrix[i, j].position;
        matrix[i, j].position = matrix[random_i, random_j].position;
        matrix[random_i, random_j].position = temp;

        Transform tempp = matrix[i, j];
        matrix[i, j] = matrix[random_i, random_j];
        matrix[random_i, random_j] = tempp;
    }

    int[] dx = { -1, +1, 0, 0 }, dy = { 0, 0, -1, +1 };

    bool valid(int i, int j)
    {
        if (i >= 0 && j >= 0 && i < Constants.MaxRows && j < Constants.MaxColumns) return true;
        return false;
    }
    public void tryMoveSingle(Transform curr)
    {
        int currI = 0, currJ = 0;

        for (int i = 0; i < Constants.MaxColumns; i++)
        {
            for (int j = 0; j < Constants.MaxRows; j++)
            {
                if (matrix[i, j] == curr)
                {
                    currI = i;
                    currJ = j;
                    break;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            int _x, _y;
            _x = currI + dx[i];
            _y = currJ + dy[i];
            if (valid(_x, _y) && matrix[_x, _y].name == "blank")
            {
                Swap(currI, currJ, _x, _y);
            }
        }
    }

    public void tryMoveMulti(Transform moveTo)
    {
        int currI = 0, currJ = 0;

        for (int i = 0; i < Constants.MaxColumns; i++)
        {
            for (int j = 0; j < Constants.MaxRows; j++)
            {
                if (matrix[i, j] == moveFrom)
                {
                    currI = i;
                    currJ = j;
                    break;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            int _x, _y;
            _x = currI + dx[i];
            _y = currJ + dy[i];
            if (valid(_x, _y) && matrix[_x, _y].name == "blank" && matrix[_x, _y] == moveTo)
            {
                Swap(currI, currJ, _x, _y);
            }
        }

        moveFrom = null;
    }
    void Update()
    {

    }
}
