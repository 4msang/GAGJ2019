using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour
{
	// Panels
	private GameObject pausePnl;

	// Buttons
	// private GameObject pauseBtn = null;

	// Member Variables
	private bool paused = false;

	int shaken = 0;
	int motionresult = 1;
	void checkForShake()
	{
		print("# shaken: " + shaken);
		if (motionresult == 0) {
			// if (motion(1) == 1 && motion(1) == 0) {
			motionresult = motion(1);
			if (motionresult == 1) {
				shaken++;
				// motionresult = 1;
				// motionresult = motion(1);
			}
		} else if (motionresult == 1) {
			motionresult = motion(1);
			// shaken++;
			// if (motion(1) == 1) {
				// motionresult = 0;
		}
		
	}


	/////////////// Methods Start

	int motion(int section)
	{
        if (section == 0 && Input.acceleration.y <= -0.7){//재료 담기(휴대폰 위로 올리기 (손목고정))
        	Debug.Log("section 0");
        	return 1;
        }
        // else if (section == 1 && (Input.acceleration.x >= -1.0) && (Input.acceleration.y <= -0.7)){//칼질
        else if (section == 1 && (Input.acceleration.y <= -0.7)){//칼질
        // else if (section == 1 && (Input.acceleration.x >= -1.0)){//칼질
        	Debug.Log("Section 1");
        	return 1;
        }

        else if (section == 2 && Input.acceleration.x >= 0.5){//양파 도마로 옮기기(오른쪽으로 손목 기울이기)
        	Debug.Log("SEction 2");
        	return 1;
        }

        else if (section == 3 && Input.acceleration.x <= -0.5)//양파 냉장고로 옮기기(오른쪽으로 손목 기울이기)
        {Debug.Log("SEction 3");return 1;}

        else if (section == 4 && Input.acceleration.y >= 0.5) //사과 씻기 위해 물과 베이킹 파우더 기울이기)
        return 1;
        
        else if(section == 5 && Input.acceleration.y >= 0.75) //볶음밥 손으로 볶기(휴대폰 윗부분을 아랫방향으로 내렸다가 올리기)
        return 1;

        else if (section == 6 && Input.acceleration.z < -1.7) //고기위로 비닐깔기 (휴대폰을 잡고 손을 아래위로 움직이기)
        return 1;

        else if (section == 7 && Input.acceleration.x <= -0.5)//고기 냉장고로 옮기기(오른쪽으로 손목 기울이기)
        return 1;

        else if (section == 8 && Input.acceleration.y >= 0.7)//계란 껍질 쓰레기통에 버리기(휴대폰 위쪽을 아래로 기울이기)
        return 1;

        else
        return 0;
    }

	// For onclick lambda on pause button
    // public void PauseBtnOnPress()
    // {
    // 	if (!paused) {
    // 		Time.timeScale = 0;

    // 	}

    // 	paused = !paused;
    // 	pausePnl.SetActive(true);
    // 	pauseBtn.SetActive(false);
    // }


    public void ResumeBtnOnPress(int num)
    {
    	if (shaken >= 2) {
    		Time.timeScale = 1;
    		// paused = !paused;
    		pausePnl.SetActive(false);

    		if (num == 0) {
    			knife.GetComponent<Animator>().enabled = true;
    			GameObject.Find("Ingredient0_Onion").SetActive(false);
    		}
    		else if (num == 1) {
    			glass.GetComponent<Animator>().enabled = true;
    			GameObject.Find("Ingredient1_Apple").SetActive(false);
    		} else if (num == 2) {
    			egg.GetComponent<Animator>().enabled = true;
    			GameObject.Find("Ingredient2_Meat").SetActive(false);
    		}

    		shaken = 0;
    		if (num < 2) i++;
    	}

    }

    GameObject knife;
    GameObject glass;
    GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
    	pausePnl = GameObject.Find("PausePnl");
    	pausePnl.SetActive(false);
    	knife = GameObject.Find("knife");
    	knife.GetComponent<Animator>().enabled = false;
    	glass = GameObject.Find("glass");
    	glass.GetComponent<Animator>().enabled = false;
    	egg = GameObject.Find("egg");
    	egg.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    int i = 0;
    // bool once = true;
    void Update()
    {
    	// motionresult = motion(1);
    	checkForShake();
    	if (pausePnl.active) {
    		ResumeBtnOnPress(i);
    		// once = false;
    		// i++;
    	}
    }
}
