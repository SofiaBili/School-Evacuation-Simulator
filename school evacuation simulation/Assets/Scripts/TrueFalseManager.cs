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
	
    FillBarScript fillBarScript;
    [SerializeField] GameObject fillBarObject;

    public AudioSource loseAudio;
    public AudioSource winAudio;

	void Awake(){
		toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();

		fillBarScript = fillBarObject.GetComponent<FillBarScript>();

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
		GetComponent<CanvasGroup>().interactable = false;
        startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		startQuestionProcedureScript.StopAnimationAndCloseCanvasFromExit();
		StartCoroutine(ChangeQuestion(false));
	}
	
    private IEnumerator ChangeButtonColour(Button btn){
		yield return new WaitForSeconds (1.9f);
		btn.GetComponent<Image>().color = Color.white;
	}
	
    private IEnumerator ChangeQuestion(bool show){
		if(show)
			yield return new WaitForSeconds (2.1f);
		GetComponent<CanvasGroup>().interactable = true;
		canvasCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("QuestionCanvas"));
		SetCurrentQuestion();
		Debug.Log(unansweredQuestions.Count);
	}
	public void UserSelectTrue(){
		GetComponent<CanvasGroup>().interactable = false;
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			winAudio.Play(0);
			Debug.Log("Cor");
			trueButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			loseAudio.Play(0);
			trueButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(trueButton));
		StartCoroutine(ChangeQuestion(true));
	}
	public void UserSelectFalse(){
		GetComponent<CanvasGroup>().interactable = false;
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			loseAudio.Play(0);
			falseButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}else{
			winAudio.Play(0);
			Debug.Log("Cor");
			falseButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}
		StartCoroutine(ChangeButtonColour(falseButton));
		StartCoroutine(ChangeQuestion(true));
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            slimeAnimator.Play(newState);
    }

}