using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstantiateDialog : MonoBehaviour
{
    [SerializeField] TextAsset text;
    [SerializeField] Dialogue dialogue;
    [SerializeField] int currentNode;
    [SerializeField] GameObject buttonInteraction, NPC;
    [SerializeField] GUISkin skin;
    public static bool ShowDialog;
    public List<Answer> answers = new List<Answer>();
    TextMeshProUGUI textInteraction;
    Animator animator;
    




    private void Start()
    {
        textInteraction = buttonInteraction.GetComponent<TextMeshProUGUI>();

        PlayerPrefs.DeleteKey("Mushroom");
        dialogue = Dialogue.Load(text);
        skin = Resources.Load("Skin") as GUISkin;
        UpdateAnswers();
        animator = NPC.gameObject.GetComponent<Animator>();

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
            if (dialogue.nodes[currentNode].answers[i].QuestName == null || dialogue.nodes[currentNode].answers[i].NeedQuestValue == PlayerPrefs.GetInt(dialogue.nodes[currentNode].answers[i].QuestName))
                answers.Add(dialogue.nodes[currentNode].answers[i]);
        
        }
    }

    private void OnTriggerStay(Collider other)
    {
        textInteraction.enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsTalking", true);
            ShowDialog = true;

            
        }
           


    }

    private void OnTriggerExit(Collider other)
    {
        textInteraction.enabled = false;
    }

    private void OnGUI()
    {
       
        GUI.skin = skin;
        if (ShowDialog)
        {
            
            Cursor.visible = true;
            ThirdHeroMovment.Instance.LockMovement = true;
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialogue.nodes[currentNode].NpcText);
            for (int i = 0; i < answers.Count; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 50 * i, 500, 40), answers[i].text))
                {
                    if (answers[i].QuestValue > 0)
                    {
                        PlayerPrefs.SetInt(answers[i].QuestName, answers[i].QuestValue);
                        if (answers[i].QuestValue == 1)
                        {
                            QuestSystem.Instance.GetQuest(answers[i].QuestName, answers[i].title, answers[i].description);
                        }
                        if (answers[i].QuestValue == 3)
                        {
                            InventorySystem.Instance.RemoveItem(answers[i].QuestName, 5);
                            QuestSystem.Instance.DestroyQuest();
                        }
                    }
                    if (QuestSystem.Instance.CheckQuest() != "")
                    {
                        if (QuestSystem.Instance.CheckQuestComplited())
                        {

                            PlayerPrefs.SetInt(answers[i].QuestName, 2);
                        }
                    }
                    if (answers[i].end == "true")
                    {
                        ShowDialog = false;
                        animator.SetBool("IsTalking", false);
                        Cursor.visible = false;
                        ThirdHeroMovment.Instance.LockMovement = false;
                    }
                    currentNode = answers[i].nextNode;
                    UpdateAnswers();
                   
                    
                    
                    
                }
            }
        }

    }
}
