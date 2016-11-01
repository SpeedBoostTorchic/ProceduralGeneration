using UnityEngine;
using System.Collections;

public class Pathmaker : MonoBehaviour {

	//Variables to keep track of instantiation
	private int counter = 0;
	private int maximum = 0;
	private double spawnNewChance = 0f;

	public static int totalCounter = 0;
	public static int trueMax = 10;
	public static int totalPM = 0;

	//Stuff that gets instantiated
	public Transform[] floorTile = new Transform[3];
	public Transform pathmakerSphere;

	void Awake(){
		if(trueMax < 1000)
		trueMax = (int) Random.Range (500, 1500);
	}

	void Start(){
		maximum = (int) Random.Range (25, 100);
		spawnNewChance = Random.Range (0.85f, 0.99f);
	}

	// Update is called once per frame
	void Update () {

		//Never let the total number of tiles exceed trueMax
		if (totalCounter > 1000) {
			Debug.Log (totalCounter);
			Destroy (gameObject);
		}

		//Each individual pathmaker spawns up to the randomly set max
		if (counter < maximum) {
			if (Random.Range (0f, 1f) < .25) {
				//Rotates pathmaker 90 degrees to the right
				this.transform.Rotate (new Vector3 (0,90f,0));
			} 
			else if (Random.Range (0f, 1f) < .5) {
				//Rotates pathmaker 90 degrees to the left
				this.transform.Rotate (new Vector3 (0,90f,0) );
			} 
			else if (Random.Range (0f, 1f) < 1f && Random.Range (0f, 1f) > spawnNewChance) {
				//Spawns a new sphere
				Instantiate (pathmakerSphere, this.transform.position, Quaternion.identity);
				totalPM++;
			}

			//Spawns a floortile then moves
			Instantiate (floorTile[(int)Random.Range(0.5f,3)], this.transform.position, Quaternion.identity);
			this.transform.position += (this.transform.forward * 5f);

			counter++;
			totalCounter++;

		} else {
			//Destoys pathmaker after max tiles then prints number of tiles
			Debug.Log (totalCounter);
			Destroy (gameObject);
		}
	
	}
}
