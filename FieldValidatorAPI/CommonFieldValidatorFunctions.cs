using System.Text.RegularExpressions;
using System;
namespace FieldValidatorAPI
{
    //form field is not left empty
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    //validating a text input field value against a regular expression pattern
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCOmpare);
    public class CommonFieldValidatorFunctions
    {
        //set up static attribute for above delegates
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel= null;
        private static CompareFieldsValidDel _compareFieldsValidDel= null;

        //create static read-only property for each related delegate 
        public static RequiredValidDel RequiredValidDel
        {
            //singleton pattern
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredValid);
                return _requiredValidDel;
            }
        }
        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);
                return _stringLengthValidDel;
            }
        }
        public static DateValidDel  DateValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);
                return _dateValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(PatternMatchValid);
                return _patternMatchValidDel;
            }
        }
        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(CompareFieldsValid);
                return _compareFieldsValidDel;
            }
        }
        private static bool RequiredValid(string fieldVal)
        {
            if(!string.IsNullOrEmpty(fieldVal))
            {
                return true;

            }
            return false;
        }
        private static bool StringLengthValid(string fieldVal,int min, int max) {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;
            return false;
        }
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime) {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;
            return false;
        }
        private static bool PatternMatchValid(string fieldVal, string regularExpressionPattern) {
            Regex regex = new Regex(regularExpressionPattern);
            if (regex.IsMatch(fieldVal))
                return true;
            return false;
        }
        private static bool CompareFieldsValid(string  fieldVal, string fieldValCompare) {
            if (fieldVal.Equals(fieldValCompare))
                return true;
            return false;
        } 
    }
}