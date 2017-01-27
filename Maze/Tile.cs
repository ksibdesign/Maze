public class Tile
{
	public Direction Direction { get; private set; }

	public void openAllDirections()
  {
    Direction = Direction.All;
  }
	public void setDirectionNorth()
	{
		Direction = Direction | Direction.North;
	}
	public void setDirectionSouth()
	{
		Direction = Direction | Direction.South;
	}
	public void setDirectionEast()
	{
		Direction = Direction | Direction.East;
	}
	public void setDirectionWest()
	{
		Direction = Direction | Direction.West;
	}

	public TileDesc TileDesc { get; private set; }

	public void placeStartPOS()
	{
		TileDesc = TileDesc.Start;
	}
	public void placeExitPOS()
	{
		TileDesc = TileDesc.Exit;
	}
	public void placeInvalidExitLocation()
	{
		TileDesc = TileDesc.InvalidExit;
	}
	public void setEmptyTile()
	{
		TileDesc = TileDesc.Empty;
	}
	public void setTestTile()
	{
		TileDesc = TileDesc.Test;
	}
}
