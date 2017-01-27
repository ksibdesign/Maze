using System;

[Flags]
public enum Direction
{
  None = 0,
  North = 1,
  South = 2,
  East = 4,
  West = 8,
  NorthEast = North | East,
  SouthEast = South | East,
  NorthWest = North | West,
  SouthWest = South | West,
  NorthSouth = North | South,
  EastWest = East | West,
  NorthSouthEast = North | South | East,
  NorthSouthWest = North | South | West,
  NorthEastWest = North | East | West,
  SouthEastWest = South | East | West,
  All = North | South | East | West
}
