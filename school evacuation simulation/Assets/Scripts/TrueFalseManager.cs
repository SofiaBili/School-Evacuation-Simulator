using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class TrueFalseManager : MonoBehaviour
{
	public TrueFalseQuestions[] questions;
	private static List<TrueFalseQuestions> unansweredQuestions1;
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
		if(unansweredQuestions1 != null) unansweredQuestions1.Clear();
		toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
		fillBarScript = fillBarObject.GetComponent<FillBarScript>();
        slimeAnimator = slimeObject.GetComponent<Animator>();
	}
	void Start(){
		if(unansweredQuestions1 == null || unansweredQuestions1.Count==0){
			unansweredQuestions1 = questions.ToList<TrueFalseQuestions>();
		}
		SetCurrentQuestion();
		transform.gameObject.SetActive(false);
	}
	public static bool UnansweredQuestionsCount1(){
		Debug.Log("ppppppppppppppppp"+unansweredQuestions1.Count);
		if(unansweredQuestions1.Count == 0) return false;
		return true;
	}
	void SetCurrentQuestion(){
		randomQuestionIndex = Random.Range(0, unansweredQuestions1.Count);
		currentQuestion = unansweredQuestions1[randomQuestionIndex];
		factText.text = currentQuestion.fact;
	}
	public void UserSelectExit(){
		GetComponent<CanvasGroup>().interactable = false;
        startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		startQuestionProcedureScript.StopAnimationAndCloseCanvasFromExit();
		if(UnansweredQuestionsCount1()) StartCoroutine(ChangeQuestion(false));
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
		Debug.Log(unansweredQuestions1.Count);
	}
	public void UserSelectTrue(){
		GetComponent<CanvasGroup>().interactable = false;
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			winAudio.Play(0);
			//Debug.Log("Cor");
			trueButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions1.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}else{
			loseAudio.Play(0);
			trueButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			//Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}
		StartCoroutine(ChangeButtonColour(trueButton));
		if(UnansweredQuestionsCount1()) StartCoroutine(ChangeQuestion(true));
	}
	public void UserSelectFalse(){
		GetComponent<CanvasGroup>().interactable = false;
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			loseAudio.Play(0);
			falseButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			//Debug.Log("WRONG");
			ChangeAnimationState("disappoint");
			fillBarScript.WrongAnswer();
		}else{
			winAudio.Play(0);
			//Debug.Log("Cor");
			falseButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions1.RemoveAt(randomQuestionIndex);
			ChangeAnimationState("congratulations");
			fillBarScript.RightAnswer();
		}
		StartCoroutine(ChangeButtonColour(falseButton));
		if(UnansweredQuestionsCount1()) StartCoroutine(ChangeQuestion(true));
	}
	public void ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            slimeAnimator.Play(newState);
    }

}