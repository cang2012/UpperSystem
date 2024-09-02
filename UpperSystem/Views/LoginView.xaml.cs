using Panuon.WPF.UI;
using System.Windows;
using UpperSystem.ViewModels;

namespace UpperSystem
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    [ExampleView(Index = 2, DisplayName = "Sign In")]
    public partial class LoginView : WindowX
    {
        #region Fields
        private bool _isProcessing;
        #endregion

        #region Ctor
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel { LoginName = "VBVBVB", Password = "343434" };
        }
        #endregion

        #region Event Handlers
        private void btnLogin_Click(object sender, RoutedEventArgs e)
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
            ButtonHelper.SetIsPending(btnLogin, true);
            passwordGroup.ValidateResult = ValidateResult.None;
            passwordGroup.Message = null;

            MessageBoxX.Show(this, "登录成功", "提示", MessageBoxIcon.Info, DefaultButton.YesOK);
        }

        private void loginName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ValidateAccount();
        }

        private void passwordChanged(object sender, RoutedEventArgs e)
        {
            ValidatePassword();
        }
        #endregion

        #region Functions
        private bool ValidateAccount()
        {
            if (loginName.Text == null 
                || loginName.Text == "")
            {
                frmAccount.ValidateResult = ValidateResult.Error;
                frmAccount.Message = "请输入用户名.";
                return false;
            }
            frmAccount.ValidateResult = ValidateResult.Success;
            frmAccount.Message = "";

            return true;
        }

            private bool ValidatePassword()
        {
            if (password.Password == null 
                || password.Password == "")
            {
                passwordGroup.ValidateResult = ValidateResult.Error;
                passwordGroup.Message = "请输入用户密码.";
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
                passwordGroup.ValidateResult = ValidateResult.Success;
                passwordGroup.Message = "";
                return true;
            }
        }
        #endregion

    }
}
