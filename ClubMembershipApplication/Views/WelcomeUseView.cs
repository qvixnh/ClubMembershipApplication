using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class WelcomeUseView : IView
    {
        User _user = null;
        public WelcomeUseView(User user)
        {
            _user = user;
        }
        public IFieldValidator FieldValidator =>null;//not including validation  on the welcome view

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_user.FirstName}!!{Environment.NewLine}Welcome to the Cycling Club!!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadLine();
        }
    }
}
