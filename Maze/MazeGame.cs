using System;
using System.Collections.Generic;


public class MazeGame
{
	int mazeWidth;
	int mazeHeight;
	int numRooms;
	int exitDistanceFromStart;

	Tile[,] maze;

	int[] mazeStartPOS = new int[2];
	int[] mazeEndPOS = new int[2];

	Random rnd = new Random();

	public void mazeInit()
	{
		// Created by Kevin Sibley
		//Console.Clear();

		mazeWidth = 20;
		mazeHeight = 20;
		numRooms = 6 - 1;
		exitDistanceFromStart = 10;

		maze = new Tile[mazeWidth, mazeHeight];

		generateMaze();
	}
	public void getMazeStart()
	{
		mazeStartPOS[0] = rnd.Next(mazeWidth);
		mazeStartPOS[1] = rnd.Next(mazeHeight);
		Console.WriteLine("mazeStartPOS[" + mazeStartPOS[0] + "," + mazeStartPOS[1] + "]");
		maze[mazeStartPOS[0], mazeStartPOS[1]].placeStartPOS();
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
						if(maze[count2, y].TileDesc != TileDesc.Start)
						{
							maze[count2, y].placeInvalidExitLocation();
						}
				  }

				}
			}
		}

		mazeEndPOS[0] = rnd.Next(mazeWidth);
		mazeEndPOS[1] = rnd.Next(mazeHeight);


	  while (maze[mazeEndPOS[0], mazeEndPOS[1]].TileDesc == TileDesc.InvalidExit){
			mazeEndPOS[0] = rnd.Next(mazeWidth);
			mazeEndPOS[1] = rnd.Next(mazeHeight);
	  }
		maze[mazeEndPOS[0], mazeEndPOS[1]].placeExitPOS();
		//REMOVE INVALID EXITS
		for (int height = 0; height < mazeHeight; height++)
		{
			for (int width = 0; width < mazeWidth; width++)
			{
				if(maze[width, height].TileDesc == TileDesc.InvalidExit)
				{
					maze[width, height].setEmptyTile();
				}
			}
		}

		Console.WriteLine("mazeEndPOS[" + mazeEndPOS[0] + "," + mazeEndPOS[1] + "]");
	}
	public void printMaze()
	{
		for (int y = 0; y < mazeHeight; y++)
		{
			for (int x = 0; x < mazeWidth; x++)
			{
				if(maze[x,y].TileDesc == TileDesc.InvalidExit)
				{
					Console.Write("  ");
				}
				else if (maze[x,y].TileDesc == TileDesc.Start)
				{
					Console.Write("* ");
				}
				else if (maze[x,y].TileDesc == TileDesc.Exit)
				{
					Console.Write("# ");
				}
				else if (maze[x,y].TileDesc == TileDesc.Test)
				{
					Console.Write("X ");
				}
				else
				{
					Console.Write("  ");
				}

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
				maze[countWidth, countHeight].openAllDirections();
				maze[countWidth, countHeight].setEmptyTile();
				//Console.WriteLine(maze[countWidth, countHeight].Direction);
			}
		}
	}
	public void generateMaze()
	{
		for (int countWidth = 0; countWidth < mazeWidth; countWidth++)
		{
			for (int countHeight = 0; countHeight < mazeHeight; countHeight++)
			{
				maze[countWidth, countHeight] = new Tile();
				//Console.WriteLine(maze[countWidth, countHeight].Direction);
			}
		}

		mazeClear();

		getMazeStart();
		getMazeExit();

		mazePathfinding();

		printMaze();
	}
	public Direction getOpenDirections(int[] tempPOS, Direction openDirections)
	{
		openDirections = Direction.None;
		if (tempPOS[0] + 1 < mazeWidth && maze[tempPOS[0] + 1, tempPOS[1]].TileDesc == TileDesc.Empty)
		{
			openDirections = openDirections | Direction.East;
		}
		if (tempPOS[0] - 1 >= 0 && maze[tempPOS[0] - 1, tempPOS[1]].TileDesc == TileDesc.Empty)
		{
			openDirections = openDirections | Direction.West;
		}
		if (tempPOS[1] + 1 < mazeHeight && maze[tempPOS[0], tempPOS[1] + 1].TileDesc == TileDesc.Empty)
		{
			openDirections = openDirections | Direction.South;
		}
		if (tempPOS[1] - 1 >=0 && maze[tempPOS[0], tempPOS[1] - 1].TileDesc == TileDesc.Empty)
		{
			openDirections = openDirections | Direction.North;
		}
		//Console.WriteLine("openDirections: " + openDirections);
		return openDirections;
	}
	public Direction randomDirectionStep(Direction openDirections)
	{
		int count = 0;
		Direction directionToStep = Direction.None;

		if (openDirections.HasFlag(Direction.North))
		{
			count++;
		}
		if (openDirections.HasFlag(Direction.South))
		{
			count++;
		}
		if (openDirections.HasFlag(Direction.East))
		{
			count++;
		}
		if (openDirections.HasFlag(Direction.West))
		{
			count++;
		}

		while (directionToStep == Direction.None)
		{
			switch (rnd.Next(4))
			{
				case 0:
					//Console.WriteLine("Case 0 - North");
					if (openDirections.HasFlag(Direction.North))
					{
						directionToStep = Direction.North;
					}
					break;
				case 1:
					//Console.WriteLine("Case 1 - South");
					if (openDirections.HasFlag(Direction.South))
					{
						directionToStep = Direction.South;
					}
					break;
				case 2:
					//Console.WriteLine("Case 2 - East");
					if (openDirections.HasFlag(Direction.East))
					{
						directionToStep = Direction.East;
					}
					break;
				case 3:
					//Console.WriteLine("Case 3 - West");
					if (openDirections.HasFlag(Direction.West))
					{
						directionToStep = Direction.West;
					}
					break;
				default:
					Console.WriteLine("INVALID CASE");
					break;
			}
		}
		return directionToStep;
	}
	public void StepToNewTile(int[] tempPOS, Direction directionToStep)
	{
		if(directionToStep == Direction.North){
			maze[tempPOS[0], tempPOS[1]].setDirectionNorth();
			maze[tempPOS[0], tempPOS[1]].setTestTile();
			tempPOS[1]--;
		}
		else if (directionToStep == Direction.South)
		{
			maze[tempPOS[0], tempPOS[1]].setDirectionSouth();
			maze[tempPOS[0], tempPOS[1]].setTestTile();
			tempPOS[1]++;
		}
		else if (directionToStep == Direction.East)
		{
			maze[tempPOS[0], tempPOS[1]].setDirectionEast();
			maze[tempPOS[0], tempPOS[1]].setTestTile();
			tempPOS[0]++;
		}
		else if (directionToStep == Direction.West)
		{
			maze[tempPOS[0], tempPOS[1]].setDirectionWest();
			maze[tempPOS[0], tempPOS[1]].setTestTile();
			tempPOS[0]--;
		}
		else
		{
			Console.WriteLine("YOU DIDN'T HAVE A VALID DIRECTION");
		}
	}
	public void mazePathfinding()
	{
		List<int[]> pathRecord = new List<int[]>();

		int[] tempPOS = new int[2] {mazeStartPOS[0], mazeStartPOS[1]};

		//Console.WriteLine(tempPOS[0] + "," + tempPOS[1]);

		Direction openDirections = new Direction();
		Direction directionToStep = new Direction();


		while(true)
		{
			pathRecord.Add(new int[] { tempPOS[0], tempPOS[1] });

			//GET OPEN DIRECTION FOR CURRENT TILE

			openDirections = getOpenDirections(tempPOS, openDirections);
			if (openDirections == Direction.None){
				break;
			}
			else if (tempPOS[0] == mazeEndPOS[0] && tempPOS[1] == mazeEndPOS[1])
			{
				break;
			}
			//CHOOSE DIRECTION TO STEP
			directionToStep = randomDirectionStep(openDirections);
			//ADD DIRECTION TO CURRENT TILE THEN MOVE
			StepToNewTile(tempPOS, directionToStep);

			//Console.WriteLine(openDirections);
			//Console.WriteLine(directionToStep);
		}



		/*while(true)
		{
			if(openDirections == Direction.None && pathRecord.Count > 1)
			{
				Console.WriteLine(pathRecord.Count);
				//pathRecord.RemoveAt(pathRecord.Count);
				tempPOS[0] = pathRecord[pathRecord.Count][0];
				tempPOS[1] = pathRecord[pathRecord.Count][1];
			}
			break;
		}

		for (int x = 0; x < pathRecord.Count; x++)
		{
			Console.WriteLine(pathRecord[x][0] + "," + pathRecord[x][1]);
		}*/







		//Console.WriteLine((Direction.North | Direction.South | Direction.East));
		//Console.WriteLine((int)Direction.All);


		//Console.WriteLine(openDirections);
		//Console.WriteLine(directionToStep);





	}
	/*
	public void mazePathfinding()
	{
		int[] tempPOS = new int[3] {mazeStartPOS[0], mazeStartPOS[1], 0};
		//var tile = new Tile();
		//tile.test();

		//int openDirections;
		//Console.WriteLine((int)(Direction.North | Direction.South | Direction.East));
		//Console.WriteLine((int)Direction.All);

		/*

		while (maze[tempPOS[0], tempPOS[1]] == " ")
		{
			if (tempPOS[0] + 1 < mazeWidth && maze[tempPOS[0] + 1, tempPOS[1]] == " ")
			{
				tempPOS[2] = tempPOS[2] + (int)Direction.East;
			}
			if (tempPOS[0] - 1 >= 0 && maze[tempPOS[0] - 1, tempPOS[1]] == " ")
			{
				tempPOS[2] = tempPOS[2] + (int)Direction.West;
			}
			if (tempPOS[1] + 1 < mazeHeight && maze[tempPOS[0], tempPOS[1] + 1] == " ")
			{
				tempPOS[2] = tempPOS[2] + (int)Direction.South;
			}
			if (tempPOS[1] - 1 >=0 && maze[tempPOS[0], tempPOS[1] - 1] == " ")
			{
				tempPOS[2] = tempPOS[2] + (int)Direction.North;
			}

			//FUCK I MADE IT SO THE ABOVE CANT THEN TEST DIRECTION OUTPUT BELOW
			//FROM tempPOS[2] = (int)Direction.XYZ

			if (tempPOS[2] != 0)
			{
				for(bool tempDir = false; tempDir != true; tempDir)
				{
					switch (rnd.Next(4))
			    {
						case 0:
							Console.WriteLine("Case 0");
							if (tempPOS[0] + 1 < mazeWidth && maze[tempPOS[0] + 1, tempPOS[1]] == " ")
							{
								//EAST
								tempPOS[2] = tempPOS[2] + (int)Direction.East;
								Console.WriteLine("Current Tile: " + (Direction)tempPOS[2]);
								maze[tempPOS[0], tempPOS[1]] = (Direction)tempPOS[2];
								tempPOS[0]++;
								maze[tempPOS[0],tempPOS[1]] = Direction.West;
								tempPOS[2] = 0;
								tempDir = true;
							}
							break;
				    case 1:
			        Console.WriteLine("Case 1");
							if (tempPOS[0] - 1 >= 0 && maze[tempPOS[0] - 1, tempPOS[1]] == " ")
							{
								//WEST
								tempPOS[2] = tempPOS[2] + (int)Direction.West;
								Console.WriteLine("Current Tile: " + (Direction)tempPOS[2]);
								maze[tempPOS[0], tempPOS[1]] = (Direction)tempPOS[2];
								tempPOS[0]--;
								maze[tempPOS[0],tempPOS[1]] = Direction.East;
								tempPOS[2] = 0;
								tempDir = true;
							}
			        break;
				    case 2:
			        Console.WriteLine("Case 2");
							if (tempPOS[1] + 1 < mazeHeight && maze[tempPOS[0], tempPOS[1] + 1] == " ")
							{
								//SOUTH
								tempPOS[2] = tempPOS[2] + (int)Direction.South;
								Console.WriteLine("Current Tile: " + (Direction)tempPOS[2]);
								maze[tempPOS[0], tempPOS[1]] = (Direction)tempPOS[2];
								tempPOS[1]++;
								maze[tempPOS[0],tempPOS[1]] = Direction.North;
								tempPOS[2] = 0;
								tempDir = true;
							}
			        break;
						case 3:
							Console.WriteLine("Case 3");
							if (tempPOS[1] - 1 >=0 && maze[tempPOS[0], tempPOS[1] - 1] == " ")
							{
								//NORTH
								tempPOS[2] = tempPOS[2] + (int)Direction.North;
								Console.WriteLine("Current Tile: " + (Direction)tempPOS[2]);
								maze[tempPOS[0], tempPOS[1]] = (Direction)tempPOS[2];
								tempPOS[1]--;
								maze[tempPOS[0],tempPOS[1]] = Direction.South;
								tempPOS[2] = 0;
								tempDir = true;
							}
							break;
				    default:
			        Console.WriteLine("Default case");
			        break;
			    }
				}
			}
		}
		*/
		//maze[tempPOS[0], tempPOS[1]] =
	//}

}
