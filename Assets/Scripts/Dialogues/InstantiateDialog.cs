using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialog : MonoBehaviour
{
    [SerializeField] TextAsset text;
    [SerializeField] Dialogue dialogue;
    [SerializeField] int currentNode;
    [SerializeField] GameObject e;
    [SerializeField] GUISkin skin;
    public bool ShowDialog;
    public List<Answer> answers = new List<Answer>();




    private void Start()
    {
        dialogue = Dialogue.Load(text);
        skin = Resources.Load("Skin") as GUISkin;
        UpdateAnswers();
    }

    private void Update()
    {
        UpdateAnswers();

    }

    void UpdateAnswers()
    {
        answers.Clear();
        for (int i = 0; i < dialogue.nodes[currentNode].answers.Length; i++)
        {
            if (dialogue.nodes[currentNode].answers[i].QuestName == "" || dialogue.nodes[currentNode].answers[i].NeedQuestValue == PlayerPrefs.GetInt(dialogue.nodes[currentNode].answers[i].QuestName))
                answers.Add(dialogue.nodes[currentNode].answers[i]);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        e.SetActive(true);
        if(Input.GetKey(KeyCode.E))
            ShowDialog = true;


    }

    private void OnTriggerExit(Collider other)
    {
        e.SetActive(false);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        if (ShowDialog)
        {
            Cursor.visible = true;
            ThirdHeroMovment.LockMovement = true;
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialogue.nodes[currentNode].NpcText);
            for (int i = 0; i < answers.Count; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 50 * i, 500, 40), answers[i].text))
                {
                    if (answers[i].QuestValue > 0)
                    {
                        PlayerPrefs.SetInt(answers[i].QuestName, answers[i].QuestValue);
                    }
                    if (answers[i].end == "true")
                    {
                        ShowDialog = false;
                        Cursor.visible = false;
                        ThirdHeroMovment.LockMovement = false;
                    }
                    currentNode = answers[i].nextNode;
                    UpdateAnswers();
                }
            }
        }

    }
}
