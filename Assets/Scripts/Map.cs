using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	[ContextMenu ("Generate Map")]
	void GenerateMapHandler () {

		_world = this.gameObject;

		// Remove all child objects
		for (int i = _world.transform.childCount - 1; i >= 0; i--)
		{
			DestroyImmediate(_world.transform.GetChild(i).gameObject);
		}

		LoadData();
		GenerateMap();
	}

	[ContextMenu ("Remove Map")]
	void RemoveMapHandler ()
	{
		_world = this.gameObject;

		// Remove all child objects
		for (int i = _world.transform.childCount - 1; i >= 0; i--)
		{
			DestroyImmediate(_world.transform.GetChild(i).gameObject);
		}
	}

	public TextAsset dataFile;
	public GameObject pathObject;
	public GameObject towerObject;

	private GameObject _world;
	public GameObject World
	{
		get
		{
			return _world;
		}
	}

	private int _width;
	public int Width
	{
		get
		{
			return _width;
		}
	}
	
	private int _height;
	public int Height
	{
		get
		{
			return _height;
		}
	}
	
	private int[] _data;

	void LoadData()
	{
		if (dataFile == null) throw new UnityException("No data file defined!");
		
		string dataText = dataFile.text;
		string[] dataLines = dataText.Split(new char[]{'\r', '\n'}, System.StringSplitOptions.RemoveEmptyEntries);

		// Init values
		_width = 0;
		_height = 0;

		int index = 0;

		foreach (string line in dataLines)
		{
			// Assume width, height, data order
			if (_width == 0)
			{
				_width = int.Parse(line);
			}
			else if (_height == 0)
			{
				_height = int.Parse(line);
				_data = new int[_width * _height];
			}
			else
			{
				string[] cells = line.Split(new char[]{' '}, System.StringSplitOptions.RemoveEmptyEntries);

				foreach (string cell in cells)
				{
					_data[index] = int.Parse(cell);
					index++;
				}
			}
		}

		Debug.Log(string.Format("Loaded level\r\nWidth = {0}\r\nHeight = {1}", _width, _height));
		// Done!
	}

	void GenerateMap ()
	{
		for (int z = 0; z < _height; z++)
		{
			for (int x = 0; x < _width; x++)
			{
				// Path block
				if (_data[x + z * _height] == 0)
				{
					GameObject o = Instantiate(pathObject, new Vector3(x + 0.0f, 0.0f, z + 0.0f), Quaternion.identity) as GameObject;
					o.transform.parent = _world.transform;
				}
				// Tower block
				else if (_data[x + z * _height] == 1)
				{
					GameObject o = Instantiate(towerObject, new Vector3(x + 0.0f, 0.0f, z + 0.0f), Quaternion.identity) as GameObject;
					o.transform.parent = _world.transform;
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		_world = gameObject;

		LoadData();
		GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
