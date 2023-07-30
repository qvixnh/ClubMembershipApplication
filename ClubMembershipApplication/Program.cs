using System;
using ClubMembershipApplication;
using ClubMembershipApplication.Views;
using FieldValidatorAPI;

namespace ClubMemberShipApplicatoin
{
    class Program
    {
        static void Main(string[] args)
        {
            //clean client code
            IView mainView = Factory.GeMainViewObject();
            //run the application
            mainView.RunView();

            Console.ReadKey();
        }
    }
}