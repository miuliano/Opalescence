using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	[ContextMenu ("Generate Map")]
	void DoSomething () {
		LoadData();
	}

	public TextAsset dataFile;
	
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
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
