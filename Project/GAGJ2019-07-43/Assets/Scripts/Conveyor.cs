using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Globalization;

public class Conveyor : MonoBehaviour
{
	// Path Points
	private List<GameObject> pathPoints = new List<GameObject>();
	// Ingredients
	private List<GameObject> ingredients = new List<GameObject>();
	// Checkpoints (i.e. interactions e.g. chopping board, fryng pan, etc)
	// PathPoint7 (3), PathPoint7 (19), PathPoint7 (62)
	private List<int> checkpointIndices;
	private int latestCheckIndex = 0;
	private bool inMiniGame = false;
	// Misc
	private bool beltMoving = false;
	private float beltSpeed = 4f;	
	private int moveDelay = 1;

	private List<float> Times = new List<float>();
	static List<Vector3> startPositions = new List<Vector3>();
	static List<Vector3> currentPositions = new List<Vector3>();

	private List<int> currentPPIndices = new List<int>();
	private System.DateTime startTime;

	// Controller
	// private int motionresult = 1;


	/////////////// Methods starts
	private void toggleBeltMove()
	{
		beltMoving = !beltMoving;
	}

	// private bool mgShopIng()
	// {
	// 	return true;
	// 	int ingBought = 0;
	// 	// 미니게임 panel enable
	// 	while (ingBought < 3)
	// 	{
	// 		if (motion(0) == 1 && false) // shopping cart가 shelf -x와 x 사이일 때 
	// 		ingBought++;
	// 	}

	// 	// return true;
	// }

	// int chopCount = 0;
	// private bool mgChopOnion()
	// {
	// 	// 미니게임 panel enable
	// 	if (chopCount < 3)
	// 	{
	// 		if (motion(1) == 1)
	// 		chopCount++;
	// 		if (chopCount < 3) return false;
	// 	}
	// 	return true;
	// }

	// int wrapCount = 0;
	// private bool mgWrapOnion()
	// {
	// 	// 미니게임 panel enable
	// 	if (wrapCount < 2)
	// 	{
	// 		if (motion(2) == 1)
	// 		wrapCount++;
	// 		if (wrapCount < 2) return false;
	// 	}
	// 	return true;
	// }

	// public void CheckPointOnInteract()
	// {
	// 	inMiniGame = true;

	// 	if (latestCheckIndex == 0) {
	// 		// 0. 재료 고르기 (Y 위->아래 N개의 재료번)
	// 		// motionresult 111
	// 		if (!mgShopIng()) return;

	// 		Invoke("toggleBeltMove", 2); // start

	// 	} else if (latestCheckIndex == 1) {
			
	// 		toggleBeltMove(); // stop
	// 		// 1-1. 도마에서 양파 썰기 (Y 위->아래->위 3번)
	// 		// motionresult는 010101
	// 		if (!mgChopOnion()) return;
	// 		pp1Done = true;

	// 		// 1-2. 썰고 남은 양파 감쌀 종이위에 2개 옮기기 (X 왼->오른 2번)
	// 		// motionresult 11
	// 		if (!mgWrapOnion()) return;
	// 		pp2Done = true;

	// 		// 1-3. 감싸진 양파 2개 냉장고로 옮기기 (XY 중앙->우측 상단 2번)
	// 		// mgOnionToFridge
	// 		// motionresult 11
	// 		Debug.Log("Onion donion");
	// 		Destroy(ingredients[0]);
	// 		ingredients.RemoveAt(0);
	// 		toggleBeltMove();
	// 		// Invoke("toggleBeltMove", 2); // start


	// 	} else if (latestCheckIndex == 2) {
	// 		// toggleBeltMove(); // stop 
	// 		// 1. 사과 씻기 위해 물과 베이킹 파우더 각각 한번씩 1초간 기울이기 (Y 기울이기)
	// 		// mgWaterPowder()
	// 		// motionresult는 1, 1
	// 		// toggleBeltMove(); // start


	// 	} else if (latestCheckIndex == 3) {
	// 		// 2. 고기, 계란이 팬으로 옮겨져 볶음밥이 된 것을 숟가락으로 볶기
	// 		toggleBeltMove(); // stop
	// 		// mgFryRice()
	// 		// motionresult 1010

	// 		// 2-1. 볶음밥에 쓰이고 남은 고기 2덩이 사이에 비닐 깔기 e.g. 비닐-고기-비닐-고기-비닐 (Y 위->아래 3번 [비닐 까는 행위만])
	// 		// mgWrapMeat()
	// 		// motionresult 000

	// 		// 2-2. 비닐에 감싸진 고기가 담긴 통을 냉장고로 이동
	// 		// mgMoveMeats()
	// 		// motionresult 1

	// 		// 2-3. 자연스럽게 생긴 계란 껍질을 쓰레기통에 버리기
	// 		// mgThrowEggShell()
	// 		// motionresult 11
	// 	}

	// 	latestCheckIndex++;
	// 	inMiniGame = false;
	// }


	// bool pp1Done = false;
	// bool pp2Done = false;
	// bool pp3Done = false;

	

	// int getShake()
	// {
	// 	checkForShake();
	// 	if (shaken == )
	// }

	bool isPP1Trigged()
	{
		float x = ingredients[0].transform.position.x;
		float y = ingredients[0].transform.position.y;
		float x1 = pathPoints[checkpointIndices[0]].transform.position.x;
		float y1 = pathPoints[checkpointIndices[0]].transform.position.y;

		if ((x1-1 < x && x < x1+1) && (y1-1 < y && y < y1+1)) {

			Debug.Log("Triggered 1");
			return true;
		}

		return false;
	}

	bool isPP2Trigged()
	{
		float x = ingredients[0].transform.position.x;
		float y = ingredients[0].transform.position.y;
		float x1 = pathPoints[checkpointIndices[1]].transform.position.x;
		float y1 = pathPoints[checkpointIndices[1]].transform.position.y;

		if ((x1-1 < x && x < x1+1) && (y1-1 < y && y < y1+1)) {

			Debug.Log("Triggered 2");
			return true;
		}
		Debug.Log("Failed to trigger 2");
		return false;
	}
	bool isPP3Trigged()
	{
		float x = ingredients[1].transform.position.x;
		float y = ingredients[1].transform.position.y;
		float x1 = pathPoints[checkpointIndices[2]].transform.position.x;
		float y1 = pathPoints[checkpointIndices[2]].transform.position.y;

		if ((x1-1 < x && x < x1+1) && (y1-1 < y && y < y1+1)) {

			Debug.Log("Triggered 3");
			return true;
		}

		return false;
	}
	// Update is called once per frame
	void Update()
	{
		System.DateTime timenow = System.DateTime.Now;
		if ((timenow - startTime).TotalSeconds > 1 && moveDelay < ingredients.Count) {
			moveDelay++;
			startTime = timenow;
		}
		for (int i = 0; i < moveDelay; i++)
		{
			GameObject movable = ((GameObject)ingredients[i]);
			Times[i] += Time.deltaTime * beltSpeed;

			if (movable.transform.position != currentPositions[i]) {
				// movable.transform.position = Vector3.Lerp(movable.transform.position, currentPositions[i], Times[i]);
				movable.transform.position = Vector3.Lerp(startPositions[i], currentPositions[i], Times[i]);

			} else {
				if (currentPPIndices[i] < pathPoints.Count - 1) {
					currentPPIndices[i]++;
					checkNode(i);
				}
			}
		}

		if (isPP1Trigged()) {
			Time.timeScale = 0;
			pausePnl.SetActive(true);
		}
		else if (isPP2Trigged()) {
			Time.timeScale = 0;
			pausePnl.SetActive(true);

		}
		else if (isPP3Trigged()) {
			
			Time.timeScale = 0;
			pausePnl.SetActive(true);
		}



		// if ((!pp1Done || !pp2Done) && isPP1Trigged()) {
		// 	// ingredients[0]가 PathPoint7 (3)과 Collide 했을 때
		// 	// ingredients[0]가 PathPoint7 (19)과 Collide 했을 때
		// 	// ingredients[1]이 PathPoint7 (62)와 Collide 했을 때
		// 	CheckPointOnInteract();
		// } else if (isPP2Trigged()) {
		// 	CheckPointOnInteract();

		// }
		// else if (isPP3Trigged() && !pp3Done) {
		// 	CheckPointOnInteract();
		// }
		// // if (inMiniGame) return;
		// else if (beltMoving) {
		// 	for (int i = 0; i < moveDelay; i++)
		// 	{
		// 		GameObject movable = ((GameObject)ingredients[i]);
		// 		Times[i] += Time.deltaTime * beltSpeed;

		// 		if (movable.transform.position != currentPositions[i]) {
		// 		// movable.transform.position = Vector3.Lerp(movable.transform.position, currentPositions[i], Times[i]);
		// 			movable.transform.position = Vector3.Lerp(startPositions[i], currentPositions[i], Times[i]);

		// 		} else {
		// 			if (currentPPIndices[i] < pathPoints.Count - 1) {
		// 				currentPPIndices[i]++;
		// 				checkNode(i);
		// 			}
		// 		}
		// 	}

		// } else {


	}

	

    // Start is called before the first frame update
    GameObject pausePnl = null;
    void Start()
    {
		// init path points
    	GameObject conveyorPath = GameObject.Find("ConveyorPath");
    	// init ingredients
    	GameObject ingsOnConveyor = GameObject.Find("IngredientsOnConveyor");

		// Obtain all the children (path points)
		// Debug.Log(conveyorPath.transform.childCount);
    	for (int i = 0; i < conveyorPath.transform.childCount; i++)
    	{
    		pathPoints.Add(conveyorPath.transform.GetChild(i).gameObject);
			// Debug.Log("Pathpoint " + i + " from ConveyorPath loaded");
    	}

		// Obtain all the ingredients
    	for (int i = 0; i < ingsOnConveyor.transform.childCount; i++)
    	{
    		ingredients.Add(ingsOnConveyor.transform.GetChild(i).gameObject);
			// initialize times, positions, and indices
    		Times.Add(0);
    		startPositions.Add(ingsOnConveyor.transform.position);
			// currentPositions.Add(new Vector3());
    		currentPositions.Add(ingsOnConveyor.transform.position);
    		currentPPIndices.Add(0);
			// Debug.Log("Ingredient " + i + " from ingsOnConveyor loaded");
    	}

		// PathPoint7 (3), PathPoint7 (19), PathPoint7 (62)
    	checkpointIndices = new List<int>(){11, 27, pathPoints.Count-1};

    	startTime = System.DateTime.Now;
		// checkNode();
    	for (int i = 0; i < 4; i++)
    	{
    		checkNode(i);
    	}

    	// CheckPointOnInteract();
    	pausePnl = GameObject.Find("PausePnl");

    }


    void checkNode(int index)
    {
    	// Timer Related
    	startPositions[index] = ((GameObject)ingredients[index]).transform.position;
    	Times[index] = 0;
    	currentPositions[index] = ((GameObject)pathPoints[currentPPIndices[index]]).transform.position;
    }


}

