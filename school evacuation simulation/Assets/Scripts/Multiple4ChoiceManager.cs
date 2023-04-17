using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Multiple4ChoiceManager : MonoBehaviour
{
    public Multiple4ChoiceQuestions[] questions;
	private static List<Multiple4ChoiceQuestions> unansweredQuestions;
	private Multiple4ChoiceQuestions currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;
	[SerializeField] private TextMeshProUGUI ans0Text;
	[SerializeField] private TextMeshProUGUI ans1Text;
	[SerializeField] private TextMeshProUGUI ans2Text;
	[SerializeField] private TextMeshProUGUI ans3Text;

    StartQuestionProcedureScript startQuestionProcedureScript;
    GameObject startQuestionProcedureScriptObject;
    ToggleQuestionCanvas toggleQuestionCanvasScript;
    [SerializeField] GameObject toggleQuestionCanvasObject;

	[SerializeField] Button but1;
	[SerializeField] Button but2;
	[SerializeField] Button but3;
	[SerializeField] Button but4;
	static int randomQuestionIndex;

	
	[SerializeField] Camera canvasCamera;
	
    [SerializeField] GameObject slimeObject;
	Animator slimeAnimator;
    private string currentState;

    FillBarScript fillBarScript;
    [SerializeField] GameObject fillBarObject;

	void Awake(){
		toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
		fillBarScript = fillBarObject.GetComponent<FillBarScript>();
        slimeAnimator = slimeObject.GetComponent<Animator>();
	}
	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<Multiple4ChoiceQuestions>();
		}

		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.question;
		ans0Text.text = currentQuestion.ans1;
		ans1Text.text = currentQuestion.ans2;
		ans2Text.text = currentQuestion.ans3;
		ans3Text.text = currentQuestion.ans4;
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
	public void UserSelectExit(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		startQuestionProcedureScript.StopAnimationAndCloseCanvasFromExit();
		StartCoroutine(ChangeQuestion());
	}
	public void UserSelect0(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.corrAns == 0){
			Debug.Log("Cor");
			but1.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			but1.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(but1));
		StartCoroutine(ChangeQuestion());
	}
	public void UserSelect1(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.corrAns == 1){
			Debug.Log("Cor");
			but2.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			but2.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(but2));
		StartCoroutine(ChangeQuestion());
	}
	public void UserSelect2(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.corrAns == 2){
			Debug.Log("Cor");
			but3.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			but3.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(but3));
		StartCoroutine(ChangeQuestion());
	}
	public void UserSelect3(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.corrAns == 3){
			Debug.Log("Cor");
			but4.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			but4.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(but4));
		StartCoroutine(ChangeQuestion());
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            slimeAnimator.Play(newState);
    }
}