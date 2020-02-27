using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomButtons : MonoBehaviour
{
	public static BottomButtons Instance; 
	private Animator _animator;
	[SerializeField] private Animator _scrollAnimator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();

		if(Instance == null)
			Instance = this;
	}

	public void PlayButton()
	{
		CameraController.Instance.PlayAnimationWithButtons(ScrollWiewPositions.center);
	}

	public void MatchHistoryButton()
	{
		
		CameraController.Instance.PlayAnimationWithButtons(ScrollWiewPositions.left);
	}

	public void SettingsButton()
	{
		CameraController.Instance.PlayAnimationWithButtons(ScrollWiewPositions.right);
	}

	public void PlayButtonAnimation()
	{
		_animator.SetTrigger("PlayButton");
		_scrollAnimator.SetTrigger("Play");
	}

	public void MatchHistoryButtonAnimation()
	{
		_animator.SetTrigger("MatchHistoryButton");
		_scrollAnimator.SetTrigger("Settings");
	}

	public void SettingsButtonAnimation()
	{
		_animator.SetTrigger("SettingsButton");
		_scrollAnimator.SetTrigger("History");
	}

 //   private void Start()
 //   {
 //   		Button[] buttons = gameObject.GetComponentsInChildren<Button>();
 //   }






 //    private class OneButton
	// {
	// 	private Vector2 defaultPosition, defaultScale, zoomScale;
	// 	private Button button;
	// 	public static OneButton ActiveButton { get; private set; }

	// 	public OneButton(Vector2 defaultPosition, Vector2 defaultScale, Vector2 zoomScale, Button button)
	// 	{
	// 		this.defaultPosition = defaultPosition;
	// 		this.defaultScale = defaultScale;
	// 		this.zoomScale = zoomScale;
	// 		this.button = button;
	// 	}

	// 	public static void SetActiveButton(OneButton activeButton)
	// 	{
	// 		ActiveButton = activeButton;
	// 	}


	// }


}


