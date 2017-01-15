using System;

namespace Maze
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var game = new MazeGame();
			game.mazeInit();
		}
	}
}


public class MazeGame
{

	int mazeWidth;
	int mazeHeight;
	int numRooms;
	int exitDistanceFromStart;

	string[,] maze;

	int[] mazeStartPOS = new int[2];
	int[] mazeEndPOS = new int[2];

	public void mazeInit()
	{
		// Created by Kevin Sibley
		//Console.Clear();

		mazeWidth = 20;
		mazeHeight = 20;
		numRooms = 6 - 1;
		exitDistanceFromStart = 10;

		maze = new string[mazeWidth, mazeHeight];


		generateMaze();
		//mazeClear(ref maze);

	}
	enum directions {
		None,
		North,
		East,
		South,
		West,
		NorthEast,
		SouthEast,
		SouthWest,
		NorthWest,
		EastWest,
		NorthSouth,
		SouthEastWest,
		NorthSouthWest,
		NorthEastWest,
		NorthSouthEast,
		NorthSouthEastWest
	}
	public void getMazeStart()
	{
		Random rnd = new Random();
		mazeStartPOS[0] = rnd.Next(mazeWidth);
		mazeStartPOS[1] = rnd.Next(mazeHeight);

		Console.WriteLine("mazeStartPOS[0] = " + mazeStartPOS[0]);
		Console.WriteLine("mazeStartPOS[1] = " + mazeStartPOS[1]);

	}
	public void getMazeExit()
	{
	  int x1;
		int x2;
		int y;

		for (int invert = 0; invert < 2; invert++)
		{
			for (int count = 0; count <= exitDistanceFromStart; count++)
			{
				if (invert == 0)
				{
					y = mazeStartPOS[1] - count;
				}
				else
				{
					y = mazeStartPOS[1] + count;
				}
				if (y >= 0 && y < mazeWidth)
				{
					if (mazeStartPOS[0] - exitDistanceFromStart + count >= 0 )
					{
						x1 = mazeStartPOS[0] - exitDistanceFromStart + count;
					}
					else
					{
						x1 = 0;
					}

					if (mazeStartPOS[0] + exitDistanceFromStart - count < mazeWidth )
					{
						x2 = mazeStartPOS[0] + exitDistanceFromStart - count;
					}
					else
					{
						x2 = mazeWidth - 1;
					}

					for (int count2 = x1; count2 <= x2; count2++)
				  {
						maze[count2, y] = " ";
				  }

				}
			}
		}

		Random rnd = new Random();
		mazeEndPOS[0] = rnd.Next(mazeWidth);
		mazeEndPOS[1] = rnd.Next(mazeHeight);

	  while (maze[mazeEndPOS[0], mazeEndPOS[1]] != "X"){
			mazeEndPOS[0] = rnd.Next(mazeWidth);
			mazeEndPOS[1] = rnd.Next(mazeHeight);
	  }

		mazeClear();
	}
	public void printMaze()
	{
		for (int y = 0; y < mazeHeight; y++)
		{
			for (int x = 0; x < mazeWidth; x++)
			{
				Console.Write(maze[x,y] + " ");
				if (x == mazeWidth - 1)
				{
					Console.WriteLine();
				}
			}
		}
	}
	public void mazeClear()
	{
		for (int countWidth = 0; countWidth < mazeWidth; countWidth++)
	  {
			for (int countHeight = 0; countHeight < mazeHeight; countHeight++)
			{
			  maze[countWidth, countHeight] = " ";
			}
	  }
	}
	public void generateMaze()
	{
		for (int countWidth = 0; countWidth < mazeWidth; countWidth++)
	  {
			for (int countHeight = 0; countHeight < mazeHeight; countHeight++)
			{
			  maze[countWidth, countHeight] = "X";
			}
	  }

		getMazeStart();
		getMazeExit();

		maze[mazeStartPOS[0], mazeStartPOS[1]] = "#";
	  maze[mazeEndPOS[0], mazeEndPOS[1]] = "*";

		mazePathfinding();

		printMaze();

	}
	public void mazePathfinding()
	{
		int[] tempPOS = new int[2] {mazeStartPOS[0],mazeStartPOS[1]};
		int availableDirections = 0;
		int tempDir;

		bool N = false;
		bool S = false;
		bool E = false;
		bool W = false;

		Random rnd = new Random();

		Console.WriteLine("TempPOS[0]: " + tempPOS[0]);
		Console.WriteLine("TempPOS[1]: " + tempPOS[1]);
		for(int temp = 0; temp < 10; temp++)
		{
			if (tempPOS[0] + 1 < mazeWidth && maze[tempPOS[0] + 1, tempPOS[1]] == " ")
			{
				availableDirections++;
				E = true;
			}
			if (tempPOS[0] - 1 >= 0 && maze[tempPOS[0] - 1, tempPOS[1]] == " ")
			{
				availableDirections++;
				W = true;
			}
			if (tempPOS[1] + 1 < mazeHeight && maze[tempPOS[0], tempPOS[1] + 1] == " ")
			{
				availableDirections++;
				S = true;
			}
			if (tempPOS[1] - 1 >=0 && maze[tempPOS[0], tempPOS[1] - 1] == " ")
			{
				availableDirections++;
				N = true;
			}
			Console.WriteLine("Avail Dir:" + availableDirections);

			//STARTING TO PATHFIND
			tempDir = rnd.Next(availableDirections);

			// THERE HAS TO BE A BETTER WAY

			if (tempDir == 0)
			{
				if (N == true)
				{

				}
				else if (S == true)
				{

				}
				else if (E == true)
				{

				}
				else
				{

				}
			}
			else if (tempDir == 1)
			{
				if (S == true)
				{

				}
				else if (E == true)
				{

				}
				else
				{

				}
			}
			else if (tempDir == 2)
			{
				if (E == true)
				{

				}
				else
				{

				}
			}
			else
			{

			}


		}
	}
}
