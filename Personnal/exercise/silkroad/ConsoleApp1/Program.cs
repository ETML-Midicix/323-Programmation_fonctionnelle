using System;
using System.Data;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

bool[,] silkyWay = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

char gridTab = ' ';
string gridHeader = $"{gridTab} 1 2 3 4 5 6 7 8";
string gridTop = $"{gridTab}┌─┬─┬─┬─┬─┬─┬─┬─┐";
string gridSeparationColumn = $"{gridTab}├─┼─┼─┼─┼─┼─┼─┼─┤";
string gridSeparationRow = "│";
string gridBottom = $"{gridTab}└─┴─┴─┴─┴─┴─┴─┴─┘";

//White Piece
char wKing = '♔';
char wQueen = '♕';
char wRook = '♖';
char wBishop = '♗';
char wKnight = '♘';
char wPawn = '♙';

//Black Piece
char bKing = '♚';
char bQueen = '♛';
char bRook = '♜';
char bBishop = '♝';
char bKnight = '♞';
char bPawn = '♟';

bool[,] rdmSilkyWay(bool[,] board)
{
    Random r = new Random();
    int nbMoreSilk = 0;
    while (nbMoreSilk < 30)
    {
        int row = r.Next(0, board.GetLength(0));
        int column = r.Next(0, board.GetLength(1));
        if (!board[row, column])
        {
            board[row, column] = true;
            nbMoreSilk++;
        }
    }
    return board;
}

void DrawBoard(bool[,] board)
{
    Console.WriteLine(gridHeader);
    Console.WriteLine(gridTop);
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + gridSeparationRow);
        for (int col = 1; col <= (gridTop.Length - 1) / 2; col++)
        {
            if (col - 1 == 0 && row == 'A')
            {
                Console.Write(wKing);
            }
            else if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(gridSeparationRow);
        }
        Console.WriteLine("");
        if (row != 'H')
        {
            Console.WriteLine(gridSeparationColumn);
        }
    }
    Console.WriteLine(gridBottom);
}

// [TODO] Put silk on 30 more squares
DrawBoard(rdmSilkyWay(silkyWay));

// TODO Create a data structure that allow us to remember which square has already been tested

// TODO Create a data structure that allow us to remember the successful steps

// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

// TODO Call the function and show the results

Console.ReadLine();