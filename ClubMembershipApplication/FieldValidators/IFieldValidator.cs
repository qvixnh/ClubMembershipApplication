using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
    //presented to the usẻ in our user registration
    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorDel validatorDel { get; }
    }
}
