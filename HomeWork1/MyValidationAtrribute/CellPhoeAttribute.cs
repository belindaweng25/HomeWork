using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HomeWork1.MyValidationAtrribute
{
    public class CellPhoeValidAttribute : ValidationAttribute
    {
        public const string RegExString = @"^\d{4}-\d{6}";

        public CellPhoeValidAttribute()
        {
            ErrorMessage = "手機格式不對";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (value is string)
            {
                Regex regEx = new Regex(RegExString);
                return regEx.IsMatch(value.ToString());
            }
            return false;
        }

    }
}