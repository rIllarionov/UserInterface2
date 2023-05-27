
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    [SerializeField] private GameObject _screenPutOff;
    [SerializeField] private GameObject _sreenPutOn;

    public void ChangeScreen()
    {
        _screenPutOff.SetActive(false);
        _sreenPutOn.SetActive(true);
    }
}
