using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // N�cessaire pour le component Text
using UnityEngine.SceneManagement; // G�re le chargement d'une sc�ne (n�cessaire pour le bouton Retry)

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private IntVariable _playerCurrentHP;
    [SerializeField] private IntVariable _playerMaxHP;
    [SerializeField] private IntVariable _bossCurrentHP;
    [SerializeField] private IntVariable _bossMaxHP;
    [SerializeField] private IntVariable _enemyCount;
    [SerializeField] private Text _enemyNomberText;
    [SerializeField] private Text _bossHPText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _bossHealthBar;
    [SerializeField] private Image _backgroundBossHealthBar;

    private void Start()
    {
        _backgroundBossHealthBar.fillAmount = 0;
        _bossHealthBar.fillAmount = 0;
        _bossHPText.text = "";
    }

    private void Update()
    {
        if (_playerCurrentHP.value < 0)
        {
            _playerCurrentHP.value = 0;
        }
        else
        { 
            float healthPercent = _playerCurrentHP.value / (float)_playerMaxHP.value; // Ici on force l'une des deux variables en float car si l'on divise deux entiers entre, le r�sultat sera soit 0 ou 1.
            _healthBar.fillAmount = healthPercent;
            
            if(healthPercent <= 0.5 && healthPercent > 0.25)
            {
                _healthBar.color = Color.yellow; // Colore la barre en jaune
            }
            else if (healthPercent <=0.25 && healthPercent >= 0)
            {
                _healthBar.color = new Color(1, 0, 0);  // Autre mani�re de colorer la barre, cette fois en rouge � l'aide du code RGB
            }
        }

       

        if (_enemyCount.value == 0)
        {
            _enemyNomberText.text = "";
            _backgroundBossHealthBar.fillAmount = 1;
            _bossHPText.text = "Boss HP";
            float bossHealthPercent = _bossCurrentHP.value / (float)_bossMaxHP.value;
            _bossHealthBar.fillAmount = bossHealthPercent;
        }
        else
        {
            _enemyNomberText.text = "Enemies remaining : " + _enemyCount.value; // Affichage du nombre d'ennemies restant
        }

        
        //_bossHPText.text = "Boss HP :" + _bossCurrentHP.value;
    }

    public void ShowLosePanel()
    {
        _losePanel.SetActive(true); // Affiche l'�cran "GAME OVER"
    }

    public void HideLosePanel()
    {
        _losePanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        _winPanel.SetActive(true); // Affiche l'�cran "YOU WIN"
    }

    public void HideWinPanel()
    {
        _winPanel.SetActive(false);
    }

    public void OnCLickRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // On recharge le niveau || Pensez � activer la sc�ne dans "File/Build setting"
    }

    public void OnCLickReturnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
