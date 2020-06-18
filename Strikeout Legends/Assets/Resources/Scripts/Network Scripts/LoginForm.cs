
using UnityEngine;
using TMPro;


/// <summary>
/// Class/Object responsible for managing login and registration input
/// </summary>
public class LoginForm : MonoBehaviour
{
    /// 1st we create space for variables we are going to use
    ///
    #region // 1st
    [Header("Login Input")]
    [SerializeField] TMP_InputField _usernameLogin;
    [SerializeField] TMP_InputField _passwordLogin;

    [Header("Register Input")]
    [SerializeField] TMP_InputField _usernameRegister;
    [SerializeField] TMP_InputField _passwordRegister;
    [SerializeField] TMP_InputField _passwordRegisterConfirm;

    /// Determain Form type
    public enum formType { login, register }
    [Header("Form Type")]
    public formType _formType;

    [Header("Debug Options")]
    [SerializeField] bool _debugMode;

    bool _isValidUsername;
    bool _isValidPassword;
    bool _isValid;
    #endregion


    /// 2nd we create Login and Register methods
    ///
    #region // 2nd
    /// Make confirmation checks to see if everything is okay
    public void Login()
    {
        if (_debugMode == true)
        {
            NetworkManager.Instance.CreateUserProfile(DebugManager.Instance.GenerateRandomUsername());
            _isValid = true;
        }

        /// get user data from database
        /// if username & pass coincide, then login
        if (_usernameLogin.text.Length > 3 && _usernameLogin.text.Length < 16)
        {
            NetworkManager.Instance.CreateUserProfile(_usernameLogin.text);
            _isValid = true;
        }

        ValidateForm();
    }

    public void Register()
    {
        /// 1 Check if username is already in use
        /// 2 Check if passwords match
        /// 3 Validade
    }


    void ValidateForm()
    {
        if (_formType == formType.register)
        {
            string _regUsername = _usernameRegister.text;
            string _regPass = _passwordRegister.text;
            string _regPassConfirm = _passwordRegisterConfirm.text;

            /// if username not used => _isValidUsername = true;
            /// else display warning message
            /// 
            /// if passwords match => _isValidPassword = true;
            /// else display warning message
            /// 
            /// if validUsername & validPassword => _isValid = true;
        }


        else if (_formType == formType.login)
        {
            string _username = _usernameLogin.text;
            string _password = _passwordLogin.text;

            /// if validUsername & validPassword => _isValid = true;
        }


        if (_isValid)
        {
            GameManager.Instance.ConfirmedLogin();
        }
    }
    #endregion


    /// Debug methods
    /// 
    #region // Debug Methods

    

    #endregion
}
