using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        private  ILogin _loginUser;

        public IFieldValidator FieldValidator => null;//not include validation on the login field
        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();
            Console.WriteLine("Please enter your email address");
            string emailAddress = Console.ReadLine();
            Console.Write("Please enter your password");
            string password = Console.ReadLine();
            User user = _loginUser.Login(emailAddress, password); 
            if(user != null)
            {
                //Todo: Run the Welcome view
                WelcomeUseView welcomeUseView = new WelcomeUseView(user);
                welcomeUseView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadLine();
            }
        }
    }
}
