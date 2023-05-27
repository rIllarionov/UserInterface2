
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private Slider _health;
    [SerializeField] private Slider _atack;
    [SerializeField] private Slider _defense;
    [SerializeField] private Slider _speed;
    [SerializeField] private GameObject _selectButton;
    [SerializeField] private GameObject _buyButton;

    private float _priceOfCurrentHero;


    private void Awake()
    {
        if (_player._heroes!=null)//если есть массив персонажей
        {
            _player._currentHero = Instantiate(_player._heroes[0],transform,false);//ставим первого персонажа
            _player._indexCurrentHero = 0;//записываем текущий индекс
            GetStats();//обновляем статы
            CanWeTakeThat();//проверяем можем ли выбирать данного персонажа
        }
    }

    public void NextHero()
    {
        
        if (_player._heroes!=null)
        {
            if (_player._indexCurrentHero + 1 > _player._heroes.Length - 1)//если это последний персонаж в массиве
            {
                Destroy(_player._currentHero);//удаляем его со сцены
                
                _player._currentHero = Instantiate(_player._heroes[0],transform,false);//сетим первого из массива
                _player._indexCurrentHero = 0;//сбрасываем индекс
                GetStats();//забираем статы персонажа
                CanWeTakeThat();//проверяем можем ли его выбрать
            }
            else
            {
                Destroy(_player._currentHero);//если не последний то, удаляем текущий и создаем новый
                _player._currentHero = Instantiate(_player._heroes[_player._indexCurrentHero+1],transform,false);
                _player._indexCurrentHero++;
                GetStats();//обновляем статы
                CanWeTakeThat();//проверяем можем ли выбрать его
            }
        }
    }

    public void PreviousHero()
    {
        if (_player._heroes!=null)
        {
            if (_player._indexCurrentHero - 1 < 0)//если это первый персонаж в массиве
            {
                Destroy(_player._currentHero);//удаляем его и сетим последнего в списке
                _player._currentHero = Instantiate(_player._heroes[^1],transform,false);
                _player._indexCurrentHero = _player._heroes.Length-1;//ставим индекс последнего перса
                GetStats();//обновляем статы 
                CanWeTakeThat();//проверяем можем ли его выбрать
            }
            else
            {
                Destroy(_player._currentHero);//если не первый то просто удаляем текущий и сетим следующего слева
                _player._currentHero = Instantiate(_player._heroes[_player._indexCurrentHero-1],transform,false);
                _player._indexCurrentHero--;//меняем индекс
                GetStats();//обновляем статы
                CanWeTakeThat();//проверяем можем ли выбрать
            }
        }
    }

    private void GetStats()//забираем статы текущего персонажа
    {
        var heroStats = _player._currentHero.GetComponent<HeroStats>();
        _heroName.text = heroStats._name;
        _health.value = heroStats._health;
        _atack.value = heroStats._atack;
        _defense.value = heroStats._defense;
        _speed.value = heroStats._speed;
        _priceOfCurrentHero = heroStats._price;
    }

    private void CanWeTakeThat() //проверяем куплен ли персонаж
    {
        
        var heroStats = _player._heroes[_player._indexCurrentHero].GetComponent<HeroStats>();
        
        if (heroStats._isAwailable)//если да то активируем кнопку выбора
        {
            _selectButton.SetActive(true);
            _buyButton.SetActive(false);
        }

        if (!heroStats._isAwailable)//если нет то активируем кнопку покупки
        {
            _selectButton.SetActive(false);
            _buyButton.SetActive(true);
            _buyButton.GetComponentInChildren<TextMeshProUGUI>().text = _priceOfCurrentHero.ToString();
        }
    }

    public void ResetChoice()//если выходим из меню без выбора
    {
        Destroy(_player._currentHero);//удаляем текущий выбор
        _player._currentHero = Instantiate(_player._heroes[_player._startIndex],transform,false);//сетим предыдущий выбор
    }

    public void SelectHero()
    {
        _player._startIndex = _player._indexCurrentHero;//запоминаем выбор персонажа с помощью индекса
    }

    public void BuyHero()//покупка персонажа
    {
        var heroStats = _player._heroes[_player._indexCurrentHero].GetComponent<HeroStats>();//обращаемся к статам
        
        if (_player._wallet.ByeItem(heroStats._price))//обращаемся к кошельку игрока и вызываем метод купить,
                                                      //если денег хватило поподаем внутрь условия
        {
            heroStats._isAwailable = true; //меняем показатель персонажа на тру.
        }
        CanWeTakeThat();//обновляем - проверяем возможность выбора персонажа
    }
    
}
