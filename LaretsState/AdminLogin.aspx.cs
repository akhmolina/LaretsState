using System;
using System.Web.Security;
using System.Web.UI;

namespace LaretsState
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void LoginAction_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            if (FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, false);
            }
            else
            {
                LegendStatus.Text = "Вы неправильно ввели имя пользователя или пароль!";
            }
        }

    }
}