using UnityEngine;
using System.Collections.Generic;
using Gamelogic;
using Gamelogic.Grids;

[RequireComponent(typeof(BoxCollider))]
public class Sector : GLMonoBehaviour
{
//	public SectorCell sectorCellPrefab;
	public int size = 12;
	public Vector2 padding;
	public SectorCell battleCellPrefab;


	public static FlatHexGrid<SectorCell> Grid{ get; set; }

	public static IMap3D<FlatHexPoint> Map{ get; set; }

	#region Spawnpoints
	public static FlatHexPoint centerSpawn;
	public static FlatHexPoint northSpawn;
	public static FlatHexPoint southSpawn;
	public static FlatHexPoint northEastSpwan;
	public static FlatHexPoint northWestSpawn;
	public static FlatHexPoint southEastSpwan;
	public static FlatHexPoint southWestSpawn;
	#endregion 



	void Start ()
	{
//		size = Battle.Manager.state.battleSectorSize;
	
		BuildGrid ();


	}



	public void BuildGrid ()
	{

		var spacing = battleCellPrefab.Dimensions;
		spacing.Scale (padding);

		Grid = FlatHexGrid<SectorCell>.Hexagon (size);
		Map = new FlatHexMap (spacing).AnchorCellMiddleCenter ().To3DXZ ();
//		Battle.Manager.state.allCells = new List<BattleCellState> ();
//		Battle.Manager.state.occupiedCells = new List<BattleCellState> ();
		foreach (var point in Grid)
		{
			var cell = Instantiate (battleCellPrefab);
//			cell.state.coordinates.x = point.X;
//			cell.state.coordinates.y = point.Y;
			Vector3 worldPoint = Map [point];
			cell.transform.parent = this.transform;
			cell.transform.localScale = Vector3.one;
			cell.transform.localPosition = worldPoint;

			cell.name = point.ToString ();
			Grid [point] = cell;
//			Battle.Manager.state.allCells.Add (cell.state);

		}
		positionCollider ();
		createSpawnpoints ();
	}

	void positionCollider ()
	{

		var gridDimensions = new Vector2 ((float)size * 2.1f, (float)size * 2.1f);

		gridDimensions.Scale (battleCellPrefab.Dimensions);

		Vector3 coliderSize = new Vector3 (gridDimensions.x, 0.1f, gridDimensions.y);

		this.GetComponent<BoxCollider> ().size = coliderSize;

	}

	void createSpawnpoints ()
	{
		int _spawnpointBuffer = size / 3;
		int _point = size - _spawnpointBuffer;

		centerSpawn = new FlatHexPoint (0, 0); 
		northSpawn = new FlatHexPoint (0, _point);
		southSpawn = new FlatHexPoint (0, -_point);
		northEastSpwan = new FlatHexPoint (_point, 0);
		southEastSpwan = new FlatHexPoint (_point, -_point);
		northWestSpawn = new FlatHexPoint (-_point, _point); 
		southWestSpawn = new FlatHexPoint (-_point, 0);

		Grid [northSpawn].Color = Color.red;
		Grid [southSpawn].Color = Color.red;
		Grid [northEastSpwan].Color = Color.red;
		Grid [southEastSpwan].Color = Color.red;
		Grid [northWestSpawn].Color = Color.red;
		Grid [southWestSpawn].Color = Color.red;
	}



	/**
	 * Returns a list of Flat Hex Points including the start and end points
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<FlatHexPoint> getGridPath (FlatHexPoint start, FlatHexPoint end)
	{
		List<FlatHexPoint> path = new List<FlatHexPoint> ();


		var _path = Algorithms.AStar<SectorCell, FlatHexPoint>
		(Grid, start, end,
			            (p, q) => p.DistanceFrom (q),
			            c => c.isAccessible,
			            (p, q) => (Grid [p].Cost + Grid [q].Cost / 2)
		            );

		foreach (var step in _path)
		{
			path.Add (step); 

		}

		return path;
	}

	/**
	 * Returns a list of Vector3s including the start and end Vector3s
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<Vector3> getGridPath (Vector3 start, Vector3 end)
	{
		List<Vector3> path = new List<Vector3> ();
		var _start = Map [start];
		var _end = Map [end];

		var _path = getGridPath (_start, _end);

		foreach (var step in _path)
		{
			path.Add (Map [step]);

		}

		return path;
	}


	public static void CreateUnit(UnitState unitState, FlatHexPoint point)
	{
		var template = Game.Manager.UnitRegister.Lookup (unitState.Designation);
		Unit unit = Instantiate (template, Sector.Map [point], Quaternion.identity) as Unit;


		unit.state = unitState;
		unit.gameObject.name = unit.state.DisplayName;
		Sector.Grid [point].unit = unit;

		Sector.Grid [point].contents = SectorCell.Contents.unit; 	
		Sector.Grid [point].isAccessible = false;

		unit.state.coordinates = Sector.Grid [point].name;
	}


	public void registerAtPoint (Vector3 point, Unit unit)
	{
		var _cell = Sector.Grid [Sector.Map [point]];
		_cell.contents = SectorCell.Contents.unit;
		_cell.unit = unit;
		_cell.isAccessible = false;

//		Battle.Manager.state.occupiedCells.Add (_cell);
			
	}

	public void unRegisterAtPoint (Vector3 point, Unit unit)
	{
		var _cell = Sector.Grid [Sector.Map [point]];
		_cell.contents = SectorCell.Contents.empty; 
		_cell.unit = null;
		_cell.isAccessible = true;

//		Battle.Manager.state.occupiedCells.Remove (_cell);

	}

	public static List<Vector3> getDeploymentArea (FlatHexPoint point, int radius)
	{
		List<Vector3> result = new List<Vector3> ();
		var area = Algorithms.GetPointsInRange<SectorCell, FlatHexPoint>
			(Sector.Grid, point,
			           JKCell => JKCell.isAccessible,
			           (p, q) => 1,
			           radius
		           );
	
	
		foreach (var _point in area)
		{
			result.Add (Sector.Map [_point]);
		}
		return result;
	}





}
