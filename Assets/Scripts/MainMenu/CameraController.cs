using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    [SerializeField] private float scaleOffset;
    [SerializeField] private float xPositionOffset;
    // [SerializeField] private float leftScrollWiewOffset, rightScrollWiewOffset;
    // [SerializeField] private float leftCameraOffset, rightCameraOffset;
    // [SerializeField] private float leftPosition, rightPosition;
    // private float centerOffset = 0f;

    // [SerializeField] private Transform scrollView;    
    [SerializeField] private Transform target;
    [SerializeField] private float animationWaitTime;
    private float animationWaitCounter = 0f;

    // private float startPosition = 0f;
    // private float startPositionScrollView = 0f;
    [SerializeField] private float leftCameraPosition, leftCenterPosition, rightCenterPosition, rightCameraPosition;
    [SerializeField] private float betweenCenterNLeft, betweenCenterNRight, betweenLeftNCenter, betweenRightNCenter;
    private ScrollWiewPositions currentPosition = ScrollWiewPositions.center;
    private Camera mainCamera;
    

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        Instance = this;
        //startPosition = scrollView.position.x;
    }
    private void Update()
    { 
        mainCamera.transform.position = new Vector3(-target.position.x * scaleOffset + xPositionOffset, mainCamera.transform.position.y, -10);
        if(animationWaitCounter > 0)
            animationWaitCounter -= Time.deltaTime;
        else
        {
            SetScrollView(); 
        }
    }

    public void SetCurrentPosition(ScrollWiewPositions position)
    {
        currentPosition = position;
    }

    private void SetScrollView()
    {
        float camPosition = mainCamera.transform.position.x;
        ScrollWiewPositions newCurrentPosition = currentPosition;
        if(camPosition < leftCameraPosition)
        {
            // Debug.Log("Off left");
            newCurrentPosition = ScrollWiewPositions.left;
        }
        else if(camPosition >= betweenCenterNLeft && camPosition < leftCenterPosition)
        {
            // Debug.Log("Left Position");
            newCurrentPosition = ScrollWiewPositions.left;
        }
        else if((camPosition >= leftCameraPosition && camPosition < betweenLeftNCenter) ||
         (camPosition >= betweenRightNCenter && camPosition < rightCameraPosition))
        {
            // Debug.Log("Center Position");
            newCurrentPosition = ScrollWiewPositions.center;
        }
        else if(camPosition >= rightCenterPosition && camPosition < betweenCenterNRight)
        {
            // Debug.Log("Right Position");
            newCurrentPosition = ScrollWiewPositions.right;
        }
        else if(camPosition > rightCameraPosition)
        {
            // Debug.Log("Off right");
            newCurrentPosition = ScrollWiewPositions.right;
        }

        bool mouseUnpressed = !Input.GetMouseButton(0);  
        // Debug.Log(Input.GetMouseButton(0));
        if(currentPosition != newCurrentPosition && mouseUnpressed)
        {
            ResetAnimationTimer();
            PlayAnimation(newCurrentPosition);
            SetCurrentPosition(newCurrentPosition);
        }
    }

    private void ResetAnimationTimer()
    {
        animationWaitCounter = animationWaitTime;
    }

    private void PlayAnimation(ScrollWiewPositions position)
    {
        switch (position) 
        {
            case ScrollWiewPositions.left:
              BottomButtons.Instance.MatchHistoryButtonAnimation();
              break;
            case ScrollWiewPositions.center:
              BottomButtons.Instance.PlayButtonAnimation();
              break;
            case ScrollWiewPositions.right:
              BottomButtons.Instance.SettingsButtonAnimation();
              break;
        }
    }

    public void PlayAnimationWithButtons(ScrollWiewPositions position)
    {
        if(currentPosition != position && animationWaitCounter <= 0)
        {
            SetCurrentPosition(position);
            PlayAnimation(position);
            ResetAnimationTimer();                        
        }
    }

    // private void SetScrollView()
    // {
    //     ScrollWiewPositions changedPosition = currentPosition;
    //     switch (currentPosition) 
    //     {
    //         case ScrollWiewPositions.left:
    //          if(mainCamera.transform.position.x - leftPosition > rightCameraOffset)
    //          {
    //             changedPosition = ScrollWiewPositions.center;
    //             Debug.Log("Case left - center");
    //          }
    //         break;
    //         case ScrollWiewPositions.center:
    //          if(mainCamera.transform.position.x > rightCameraOffset)
    //           {
    //             changedPosition = ScrollWiewPositions.right;
    //             Debug.Log("Case center - right");
    //           }
    //           else if(mainCamera.transform.position.x < leftCameraOffset)
    //           {
    //             changedPosition = ScrollWiewPositions.left;
    //             Debug.Log("Case center - left");
    //           }     
    //          break;
    //         case ScrollWiewPositions.right:
    //           if(mainCamera.transform.position.x - rightCameraOffset < leftCameraOffset)
    //           {
    //              changedPosition = ScrollWiewPositions.center;
    //              Debug.Log("Case right - center");
    //           }
    //           break;
    //     }
    //     SetPosition(changedPosition);
    // }

    // private void SetPosition(ScrollWiewPositions position)
    // {
    //     ScrollWiewPositions changedPosition = currentPosition;
    //     switch (position) 
    //     { 
    //         case ScrollWiewPositions.left:
    //           BottomButtons.Instance.MatchHistoryButton();
    //           changedPosition = ScrollWiewPositions.left;
    //           Debug.Log("Left");
    //           break;
    //         case ScrollWiewPositions.center:
    //           BottomButtons.Instance.PlayButton();       
    //           changedPosition = ScrollWiewPositions.center; 
    //           Debug.Log("Center");    
    //          break;
    //         case ScrollWiewPositions.right:
    //           BottomButtons.Instance.SettingsButton();
    //           changedPosition = ScrollWiewPositions.right;
    //           Debug.Log("Right");
    //           break;
    //     }

    //     if(currentPosition != changedPosition)
    //     {
    //         currentPosition = changedPosition; 
    //         animationWaitCounter = animationWaitTime;
    //         Debug.Log("CameraPositionIsChanged");
    //     }      
    // }

    

    // private void SetScrollView()
    // {
    //     ScrollWiewPositions temp = ScrollWiewPositions.center;
    //     if(mainCamera.transform.position.x - startPosition > rightCameraOffset && currentPosition != ScrollWiewPositions.right)
    //     {
    //         temp = ScrollWiewPositions.right;
    //         currentPosition = ScrollWiewPositions.right;
    //         if(currentPosition == ScrollWiewPositions.left) currentPosition = ScrollWiewPositions.center;
    //         Debug.Log("Right");
    //     }

    //     else if(mainCamera.transform.position.x - startPosition < leftCameraOffset && currentPosition != ScrollWiewPositions.left)
    //     {
    //         // temp = ScrollWiewPositions.left;
    //         // currentPosition = ScrollWiewPositions.left;
    //         // if(currentPosition == ScrollWiewPositions.right) currentPosition = ScrollWiewPositions.center;
    //         Debug.Log("Left");
    //     }
    //     else
    //     {
    //         Debug.Log("Center");
    //     }

    //     SetPosition(temp);
    // }

    // private void SetPosition(ScrollWiewPositions position)
    // {
    //     float xOffset = 0f;
    //     float cameraOffset = 0f;
    //     switch (position) 
    //     { 
    //         case ScrollWiewPositions.left:
    //           xOffset = leftScrollWiewOffset;
    //           cameraOffset = leftCameraOffset;
    //           break;
    //         // case ScrollWiewPositions.center:
    //         //   xOffset = centerOffset; 
    //         //   break;
    //         case ScrollWiewPositions.right:
    //           xOffset = rightScrollWiewOffset;  
    //           cameraOffset = rightCameraOffset;
    //           break;
    //     }

    //     scrollView.position = new Vector3(startPositionScrollView + xOffset, scrollView.position.y,
    //      scrollView.position.z);

    //     startPositionScrollView = scrollView.position.x;

    //     //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + cameraOffset, mainCamera.transform.position.y,
    //       //  mainCamera.transform.position.z);  
    //     startPosition += cameraOffset; 
    //     mainCamera.transform.position  = new Vector3(startPosition, mainCamera.transform.position.y, mainCamera.transform.position.z);
    // }


}

public enum ScrollWiewPositions { left, right, center }

