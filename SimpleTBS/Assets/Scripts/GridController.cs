using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
	public GameObject gridLoc;
	public List<GridLoc> grid = new List<GridLoc>();
	public Mesh gridMesh;

	private void Start()
	{
		int index = 0;
		foreach(Vector3 p in gridMesh.vertices)
		{
			GridLoc g = Instantiate(gridLoc, p, Quaternion.identity).GetComponent<GridLoc>();
			g.index = index;
			index++;
			g.pos = p;
			g.transform.parent = transform;
		}
	}
}
