using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class TrueFalseManager : MonoBehaviour
{
	public TrueFalseQuestions[] questions;
	private static List<TrueFalseQuestions> unansweredQuestions;
	private TrueFalseQuestions currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;
	
    StartQuestionProcedureScript startQuestionProcedureScript;
    GameObject startQuestionProcedureScriptObject;
    ToggleQuestionCanvas toggleQuestionCanvasScript;
    [SerializeField] GameObject toggleQuestionCanvasObject;

	[SerializeField] Button trueButton;
	[SerializeField] Button falseButton;
	static int randomQuestionIndex;

	
	[SerializeField] Camera canvasCamera;
	
    [SerializeField] GameObject slimeObject;
	Animator slimeAnimator;
    private string currentState;

	void Awake(){
		toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
        slimeAnimator = slimeObject.GetComponent<Animator>();
	}
	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<TrueFalseQuestions>();
		}
		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.fact;
	}
	public void UserSelectExit(){
        startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		startQuestionProcedureScript.StopAnimationAndCloseCanvasFromExit();
		StartCoroutine(ChangeQuestion());
	}
	
    private IEnumerator ChangeButtonColour(Button btn){
		yield return new WaitForSeconds (1.9f);
		btn.GetComponent<Image>().color = Color.white;
	}
	
    private IEnumerator ChangeQuestion(){
		yield return new WaitForSeconds (2.1f);
		canvasCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("QuestionCanvas"));
		//canvasCamera.cullingMask |=  (1 << LayerMask.NameToLayer("QuestionCanvas"));
		SetCurrentQuestion();
		yield return new WaitForSeconds (0.09f);
		//canvasCamera.cullingMask |=  (1 << LayerMask.NameToLayer("QuestionCanvas"));
		//canvasCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("QuestionCanvas"));
		Debug.Log(unansweredQuestions.Count);
	}
	public void UserSelectTrue(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			Debug.Log("Cor");
			trueButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
		}else{
			trueButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
		}
		StartCoroutine(ChangeButtonColour(trueButton));
		StartCoroutine(ChangeQuestion());
	}
	public void UserSelectFalse(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			falseButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
		}else{
			Debug.Log("Cor");
			falseButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
		}
		StartCoroutine(ChangeButtonColour(falseButton));
		StartCoroutine(ChangeQuestion());
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            slimeAnimator.Play(newState);
    }
}