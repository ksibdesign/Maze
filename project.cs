using System;

public class Program
{

  public static void Main(string[] args)
  {
    var game = new MazeGame();
    game.mazeInit();
  }
}
class MazeGame
{

  int mazeWidth;
  int mazeHeight;
  int numRooms;
  int exitDistanceFromStart;

  string[,] maze;

  public void mazeInit()
  {
    // Created by Kevin Sibley
    //Console.Clear();

    mazeWidth = 20;
    mazeHeight = 20;
    numRooms = 6 - 1;
    exitDistanceFromStart = 10;

    maze = new string[mazeWidth, mazeHeight];


    //string[] maze = new string[mazeWidth*mazeHeight];
    //Console.WriteLine("List Length: " + listTest.Length);


    getDirections();



    //generateMaze(ref exitDistanceFromStart, ref mazeWidth, ref mazeHeight, ref maze, ref numRooms);
    //mazeClear(ref maze);

  }
  public static void getDirections()
  {
    string[] directions = new string[16] { "", "N", "E", "S", "W", "NE", "SE", "SW", "NW", "EW", "NS", "SEW", "NSW", "NEW", "NSE", "NSEW" };
    string[] directionsDec = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
    int count = 0;
    foreach (string element in directions)
    {
      Console.WriteLine("Direction[" + count + "]: " + element);
      count++;
    }
  }
  /*public static void getMazeExit(ref int mazeStartPOS, ref int mazeEndPOS, ref int exitDistanceFromStart, ref int mazeWidth, ref int mazeHeight, ref string[] maze)
  {
    int tempPOS; //Temporary position for parsing
    int x; //Finds amount remaining in row before new row
    int y; // Min number to find
    int z; // Max number to find

    //for (int count = 0; count < maze.Length; count++)
    {
    //  maze[count] = "X";
    //}
    //REFACTORED
    for (int countWidth = 0; countWidth <= mazeWidth; countWidth++)
    {
      for (int countHeight = 0; countHeight <= mazeHeight; countHeight++)
      {
        maze[countWidth, countHeight] = "X";
      }
    }
    x = (mazeStartPOS % mazeWidth);
    int temp = mazeStartPOS / mazeWidth;
    if (temp == (mazeStartPOS - exitDistanceFromStart) / mazeWidth && (mazeStartPOS - exitDistanceFromStart) / mazeWidth != 0)
    {
      y = mazeStartPOS - exitDistanceFromStart;
    }
    else if ((mazeStartPOS - x) >= 0)
    {
      y = mazeStartPOS - x;
    }
    else
    {
      y = mazeStartPOS;
    }
    if (temp == (mazeStartPOS + exitDistanceFromStart) / mazeWidth )
    {
      z = mazeStartPOS + exitDistanceFromStart;
    }
    else
    {
      z = mazeStartPOS + (mazeWidth - (x + 1));
    }

    for (int count = y; count <= z; count++)
    {
      maze[count] = " ";
    }


    for (int count2 = 0; count2 < 2; count2++)
    {
      for (int count = 1; count <= exitDistanceFromStart; count++)
      {
        if (count2 == 0)
        {
          tempPOS = mazeStartPOS - (count * mazeWidth);
        }
        else
        {
          tempPOS = mazeStartPOS + (count * mazeWidth);
        }

        temp = tempPOS / mazeWidth;
        if (tempPOS >= 0 && tempPOS <= maze.Length - 1)
        {
          if (temp == (tempPOS - (exitDistanceFromStart - count)) / mazeWidth )
          {
            y = tempPOS - exitDistanceFromStart + count;
          }
          else if (tempPOS - x >= 0)
          {
            y = tempPOS - x;
          }
          else
          {
            y = tempPOS;
          }

          if (temp == (tempPOS + (exitDistanceFromStart - count)) / mazeWidth )
          {
            // 0 == 0
            z = tempPOS + exitDistanceFromStart - count;
          }
          else if (tempPOS + (mazeWidth - (x + 1)) <= maze.Length - 1)
          {
            z = tempPOS + (mazeWidth - (x + 1));
          }
          else
          {
            z = tempPOS;
          }

          // Makes sure that only size of area gets touched and not out of bounds
          if (y < 0)
          {
            y = 0;
          }
          if (z >= maze.Length)
          {
            z = maze.Length - 1;
          }

          //Console.WriteLine(y + " - " + tempPOS + " - " + z);

          for (int a = y; a <= z; a++)
          {
            maze[a] = " ";
          }
        }
      }
    }
    Random rnd = new Random();
    mazeEndPOS = rnd.Next(mazeWidth*mazeHeight);
    while (maze[mazeEndPOS] != "X"){
      mazeEndPOS = rnd.Next(mazeWidth*mazeHeight);
    }
    maze[mazeStartPOS] = "#";
    maze[mazeEndPOS] = "*";

    printMaze(ref maze, ref mazeWidth);
    mazeClear(ref maze);

    maze[mazeStartPOS] = "#";
    maze[mazeEndPOS] = "*";

    printMaze(ref maze, ref mazeWidth);
  }*/
  /*public static void getMazeStart(ref int mazeStartPOS, ref int mazeWidth, ref int mazeHeight)
  {
    Random rnd = new Random();
    mazeStartPOS = rnd.Next(mazeWidth*mazeHeight);
  }*/
  /*public static void printMaze(ref string[] maze, ref int mazeWidth)
  {
    int count2 = 0;
    foreach (string element in maze)
    {
      Console.Write(maze[count2] + " ");
      if ((count2 + 1) % mazeWidth == 0)
      {
        Console.WriteLine();
      }
      count2++;
    }
  }*/
  /*public static void mazeClear(ref string[] maze)
  {
    for(int i = 0; i < maze.Length; i++)
    {
      maze[i] = " ";
    }
  }*/
  public static void generateMaze(ref int exitDistanceFromStart, ref int mazeWidth, ref int mazeHeight, ref string[,] maze, ref int numRooms)
  {
    string[] mazeStartPOS;
    string[] mazeEndPOS;
    //getMazeStart(ref mazeStartPOS, ref mazeWidth, ref mazeHeight);
    //getMazeExit(ref mazeStartPOS, ref mazeEndPOS, ref exitDistanceFromStart, ref mazeWidth, ref mazeHeight, ref maze);



    /*
    int tempPOS = mazeStartPOS;
    bool validN;
    bool validE;
    bool validS;
    bool validW;
    int validAmt = 3;


    int currentRoomWidth;
    int currentRoomHeight;

    for (int currentRoom = 0; currentRoom <= numRooms; currentRoom++)
    {
      Random rnd = new Random();
      int tempRoomStart;
      int tempRoom;
      bool validRoom;

      currentRoomHeight = rnd.Next(2, mazeWidth / 4 + 1);
      currentRoomWidth = rnd.Next(2, mazeWidth / 4 + 1);
      Console.WriteLine("Current Room " + currentRoom + " - Width: " + currentRoomWidth + " & Height: " + currentRoomHeight);
      tempRoomStart = rnd.Next(mazeWidth*mazeHeight);
      tempRoom = tempRoomStart;


      int tempRoomSize = 0;
      while (tempRoomSize < currentRoomHeight * currentRoomWidth)
      {
        if (tempRoom != mazeStartPOS && tempRoom != mazeEndPOS && tempRoom >= 0 && tempRoom < mazeWidth*mazeHeight)
        {
          validRoom = true;
          // I STILL NEED TO WRAP ROOM WITH AND CHECK
        }
        tempRoomSize++;
        tempRoom++;

      }
    }*/





    /*while (tempPOS != mazeEndPOS)
    {
      if (tempPOS + mazeWidth < maze.Length && maze[tempPOS + mazeWidth] == " ")
      {
        validS = true;
        validAmt++;
      }
      else
      {
        validS = false;
      }
      if (tempPOS + 1 < maze.Length && maze[tempPOS + 1] == " " && tempPOS + 1 < tempPOS + (mazeWidth - (tempPOS % mazeWidth)))
      {
        validE = true;
        validAmt++;
      }
      else
      {
        validE = false;
      }
      if (tempPOS - mazeWidth >= 0 && maze[tempPOS - mazeWidth] == " ")
      {
        validN = true;
        validAmt++;
      }
      else
      {
        validN = false;
      }
      if (tempPOS - 1 >= 0 && maze[tempPOS - 1] == " " && tempPOS - 1 >= tempPOS - (tempPOS % mazeWidth))
      {
        validW = true;
        validAmt++;
      }
      else
      {
        validW = false;
      }
      Random rnd = new Random();
      validAmt = rnd.Next(validAmt);

      if(validAmt == 0)
      {
        if(validN = true)
        {
          tempPOS = tempPOS - mazeWidth;
        }
        else if (validE == true)
        {
          tempPOS = tempPOS + 1;
        }
        else if (validS == true)
        {
          tempPOS = tempPOS + mazeWidth;
        }
        else if (validW == true)
        {
          tempPOS = tempPOS - 1;
        }


      }
      else if (validAmt == 1)
      {

      }
      else if (validAmt == 2)
      {

      }
      else if (validAmt == 3)
      {

      }
      else
      {
        Console.WriteLine("NOT A VALID DIRECTION");
      }
    }*/

  }
}
