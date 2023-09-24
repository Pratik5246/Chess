using Chess.Scripts.Core;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    [SerializeField] ChessBoardPlacementHandler chessBoardHandle = ChessBoardPlacementHandler.Instance;
    private GameObject prevobj;
    private int row, col;
    void Update()
    {
        OnMouseClick();
    }
    void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (chessBoardHandle != null)
            {
                chessBoardHandle.ClearHighlights();
            }
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                // The object was clicked, return the GameObject
                GameObject currentobj = hit.collider.gameObject;
                ChessPlayerPlacementHandler chessplacement = currentobj.GetComponent<ChessPlayerPlacementHandler>();
                row = chessplacement.row;
                col = chessplacement.column;
                PawnPlacment(currentobj);
                Bishop(currentobj);
                Rook(currentobj);
                Knight(currentobj);
                Queen(currentobj);
                King(currentobj);
            }
        }
    }
    void PawnPlacment(GameObject currentobj)
    {
       
        if (currentobj.name == "Pawn")
        {
            if (row == 1)
            {
                for (int i = 2; i <= 3; i++)
                {
                    if (chessBoardHandle != null)
                    {
                        chessBoardHandle.Highlight(i, col);
                    }
                }
            }
            else
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(row + 1, col);
                }
            }

        }
    }
    private void Bishop(GameObject currentobj)
    {
        if (currentobj.name == "Bishop")
        {
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++, j++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 11.");
                }
            }

            //Highlight diagonally up and to the left
            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 12.");
                }
            }

            // Highlight diagonally down and to the right
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 13.");
                }
            }

            // Highlight diagonally down and to the left
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is 14.");
                }
            }
        }
    }
        private void Rook(GameObject currentobj)
        {
          if(currentobj.name=="Rook")
          {
            for(int i=0;i<8;i++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, col);
                }
            }
            for (int j = 0; j < 8; j++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(row, j);
                }
            }
        }
        }
    private void Knight(GameObject currentobj)
    {
        if (currentobj.name == "Knight")
        {
            int[] a = { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] b = { 2, 1, -1, -2, -2, -1, 1, 2 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + a[i];
                int newCol = col + b[i];

                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    if (chessBoardHandle != null)
                    {
                        chessBoardHandle.Highlight(newRow, newCol);
                    }
                }
                
            }
        }
    }

    private void Queen(GameObject currentobj)
    {
        if(currentobj.name =="Queen")
        {
            //Diagonal Movement of Queen
            for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++, j++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 11.");
                }
            }

            //Highlight diagonally up and to the left
            for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 12.");
                }
            }

            // Highlight diagonally down and to the right
            for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is null 13.");
                }
            }

            // Highlight diagonally down and to the left
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (chessBoardHandle != null)
                {
                    chessBoardHandle.Highlight(i, j);
                }
                else
                {
                    Debug.LogError("chessBoardHandle is 14.");
                }
            }

            //Horizontal Moment of Queen
                for (int i = 0; i < 8; i++)
                {
                    if (chessBoardHandle != null)
                    {
                        chessBoardHandle.Highlight(i, col);
                    }
                }
                for (int j = 0; j < 8; j++)
                {
                    if (chessBoardHandle != null)
                    {
                        chessBoardHandle.Highlight(row, j);
                    }
                }
            
        }
    }
    private void King(GameObject currentobj)
    {
        if (currentobj.name == "King")
        {
            int[] x = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] y = { 1, 0, -1, 1, -1, 1, 0, -1 };
            for (int i = 0; i < 8; i++)
            {
                int newRowx = row + x[i];
                int newColy = col + y[i];

                if (newRowx >= 0 && newRowx < 8 && newColy >= 0 && newColy < 8)
                {
                    if (chessBoardHandle != null)
                    {
                        chessBoardHandle.Highlight(newRowx, newColy);
                    }
                }
            }
        
            
        }
    }



}




