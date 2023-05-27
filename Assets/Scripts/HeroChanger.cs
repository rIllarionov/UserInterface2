
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

    private int _selectHeroIndex;
    
    private void Awake()
    {
        if (_player._heroes!=null)//если есть массив персонажей
        {
            _player.SetCurrentHero(Instantiate(_player._heroes[0],transform,false));//ставим первого персонажа
            _player.SetCurrentIndex(0);//записываем текущий индекс
            
            BuyHero();//первый персонаж бесплатный, мы сразу его покупаем за 0 денег.
            SelectHero();//запоминаем наш выбор
            GetStats();//обновляем статы
        }
    }

    public void NextHero()
    {
        
        if (_player._heroes!=null)
        {
            if (_player._indexCurrentHero + 1 > _player._heroes.Length - 1)//если это последний персонаж в массиве
            {
                Destroy(_player._currentHero);//удаляем его со сцены
                
                _player.SetCurrentHero(Instantiate(_player._heroes[0],transform,false));//сетим первого из массива
                _player.SetCurrentIndex(0);//сбрасываем индекс
                GetStats();//забираем статы персонажа
                TrySelect();//проверяем можем ли его выбрать
            }
            else
            {
                Destroy(_player._currentHero);//если не последний то, удаляем текущий и создаем новый
                _player.SetCurrentHero(Instantiate(_player._heroes[_player._indexCurrentHero+1],transform,false));
                _player.SetCurrentIndex(_player._indexCurrentHero+1);
                GetStats();//обновляем статы
                TrySelect();//проверяем можем ли выбрать его
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
                _player.SetCurrentHero(Instantiate(_player._heroes[^1],transform,false));
                _player.SetCurrentIndex(_player._heroes.Length-1);//ставим индекс последнего перса
                GetStats();//обновляем статы 
                TrySelect();//проверяем можем ли его выбрать
            }
            else
            {
                Destroy(_player._currentHero);//если не первый то просто удаляем текущий и сетим следующего слева
                _player.SetCurrentHero(Instantiate(_player._heroes[_player._indexCurrentHero-1],transform,false));
                _player.SetCurrentIndex(_player._indexCurrentHero-1);//меняем индекс
                GetStats();//обновляем статы
                TrySelect();//проверяем можем ли выбрать
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
        //_priceOfCurrentHero = heroStats._price;
    }

    private void TrySelect() //проверяем куплен ли персонаж
    {
        
        var heroStats = _player._heroes[_player._indexCurrentHero].GetComponent<HeroStats>();
        
        if (heroStats.IsAvailable)//если да то активируем кнопку выбора
        {
            _selectButton.SetActive(true);
            _buyButton.SetActive(false);
        }

        if (!heroStats.IsAvailable)//если нет то активируем кнопку покупки
        {
            _selectButton.SetActive(false);
            _buyButton.SetActive(true);
            _buyButton.GetComponentInChildren<TextMeshProUGUI>().text =
                _player._currentHero.GetComponent<HeroStats>()._price.ToString();
        }
    }

    public void ResetChoice()//если выходим из меню без выбора
    {
        Destroy(_player._currentHero);//удаляем текущий выбор
        _player.SetCurrentHero(Instantiate(_player._heroes[_selectHeroIndex],transform,false));//сетим предыдущий выбор
        _player.SetCurrentIndex(_selectHeroIndex);//обновляем текущий индекс
        TrySelect();//обновляем селектор
    }

    public void SelectHero()
    {
        _selectHeroIndex = _player._indexCurrentHero;//запоминаем выбор персонажа с помощью индекса
    }

    public void BuyHero()//покупка персонажа
    {
        var heroStats = _player._heroes[_player._indexCurrentHero].GetComponent<HeroStats>();//обращаемся к статам
        
        if (_player._wallet.BuyItem(heroStats._price))//обращаемся к кошельку игрока и вызываем метод купить,
                                                      //если денег хватило поподаем внутрь условия
        {
            heroStats.ChangeAvailable(true); //меняем показатель персонажа на тру.
        }
        TrySelect();//обновляем - проверяем возможность выбора персонажа
    }
    
}
