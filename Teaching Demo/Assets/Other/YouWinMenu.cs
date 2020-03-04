using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using DG.Tweening;
using TMPro;

public class YouWinMenu : MonoBehaviour
{
    public static YouWinMenu Instance;
    public GameObject container;
    public Button restartButton;
    public Button dismissButton;
    public string winMessage;
    public TextMeshProUGUI winMessageUI;
    public AudioSource audioSource;

    private float _animationSpeed = .25f;

    private Hazard[] _hazards;

    private void Awake()
    {
        Instance = this;
        _hazards = FindObjectsOfType<Hazard>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string initialWinMessage = winMessage;
            winMessage = "Hey, You Cheated!";
            Show();
            winMessage = initialWinMessage;
        }
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(HandleRestartPressed);
        dismissButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(HandleRestartPressed);
        dismissButton.onClick.RemoveListener(Hide);
    }

    void HandleRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Show()
    {
        container.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, _animationSpeed).SetEase(Ease.OutBack);
        StartCoroutine(ShowNextButton());
        winMessageUI.SetText(winMessage);
        audioSource.Play();

        foreach (Hazard hazard in _hazards)
        {
            hazard.GetComponent<BoxCollider2D>().enabled = false;
        }

        PlatformerCharacter2D.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void Hide()
    {
        container.SetActive(false);

        foreach (Hazard hazard in _hazards)
        {
            hazard.GetComponent<BoxCollider2D>().enabled = true;
        }

        PlatformerCharacter2D.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator ShowNextButton()
    {
        restartButton.gameObject.SetActive(false);
        dismissButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        restartButton.gameObject.SetActive(true);
        dismissButton.gameObject.SetActive(true);
        restartButton.transform.DOShakeScale(_animationSpeed, 1, 10, 90, true);
        dismissButton.transform.DOShakeScale(_animationSpeed, 1, 10, 90, true);
    }
}
