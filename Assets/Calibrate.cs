using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calibrate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject targetTop, targetBottom, targetRight, targetLeft;
    [SerializeField] LeapServiceProvider service;
    private GameObject[] targets;
    private int targetNo = 0;

    private void OnEnable()
    {
        service.OnUpdateFrame += OnUpdateFrame;
    }

    private void OnDisable()
    {
        service.OnUpdateFrame -= OnUpdateFrame;
    }
    void Start()
    {
        
        targets = new GameObject[] { targetTop, targetBottom, targetRight, targetLeft };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnUpdateFrame(Frame frame)
    {
        
        targets[targetNo].SetActive(true);
        print(frame.ToString());
        if (frame != null)
        {
            
            var handPos = frame.GetHand(Chirality.Right).GetIndex().TipPosition;

            if(handPos != null)
            {
                if (Input.GetKeyDown("space"))
                {
                    switch (targetNo)
                    {
                        case 0:
                            Preferences.bottom = handPos;
                            targets[targetNo].SetActive(false);
                            targetNo++;
                            break;
                        case 1:
                            Preferences.top = handPos;
                            targets[targetNo].SetActive(false);
                            targetNo++;
                            break;
                        case 2:
                            Preferences.left = handPos;
                            targets[targetNo].SetActive(false);
                            targetNo++;
                            break;
                        case 3:
                            Preferences.right = handPos;
                            targets[targetNo].SetActive(false);
                            targetNo++;
                            break;
                    }
                }
            }
            
        }

        if(targetNo == 4)
        {
            Preferences.calibrated = true;
            SceneManager.LoadScene("Portrait");
        }
        
    }

}
