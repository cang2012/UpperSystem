using Panuon.WPF.UI;
using System.Windows;

namespace UpperSystem
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    [ExampleView(Index = 2, DisplayName = "Sign In")]
    public partial class SignInView : WindowX
    {
        #region Fields
        private bool _isProcessing;
        #endregion

        #region Ctor
        public SignInView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_isProcessing)
            {
                return;
            }
            if (!ValidateAccount()
                || !ValidatePassword())
            {
                return;
            }
            _isProcessing = true;
            ButtonHelper.SetIsPending(BtnLogin, true);
            Password.ValidateResult = ValidateResult.None;
            Password.Message = null;

            MessageBoxX.Show(this, "登录成功", "提示", MessageBoxIcon.Info, DefaultButton.YesOK);
        }

        private void LoginName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ValidateAccount();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidatePassword();
        }
        #endregion

        #region Functions
        private bool ValidateAccount()
        {
            if (LoginName.Text == null 
                || LoginName.Text == "")
            {
                FrmAccount.ValidateResult = ValidateResult.Error;
                FrmAccount.Message = "请输入用户名.";
                return false;
            }
            FrmAccount.ValidateResult = ValidateResult.Success;
            FrmAccount.Message = "";

            return true;
        }

            private bool ValidatePassword()
        {
            if (PwdPassword.Password == null 
                || PwdPassword.Password == "")
            {
                Password.ValidateResult = ValidateResult.Error;
                Password.Message = "请输入用户密码.";
                return false;
            }
            //else if (PwdPassword.Password.Length < 4)
            //{
            //    FrmPassword.ValidateResult = ValidateResult.Error;
            //    FrmPassword.Message = "At least 4 digits.";
            //    return false;
            //}
            //else if (PwdPassword.Password != "123456")
            //{
            //    FrmPassword.ValidateResult = ValidateResult.Warning;
            //    FrmPassword.Message = "Password should be 123456.";
            //    return false;
            //}
            else
            {
                Password.ValidateResult = ValidateResult.Success;
                Password.Message = "";
                return true;
            }
        }
        #endregion

    }
}
