using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Model;

namespace BLL.Service
{
    public class ValidateNIF
    {
        private readonly string _nif;
        private readonly int _divisionNumber = 11;
        private readonly int _lengthNif = 9;

        public ValidateNIF(string nif) 
        {
            _nif = nif;
        }

        public Response Action () 
        {   
            Response response = new Response();

            try
            {
                ValidateNifField();

                List<int> digitsNif = _nif.Select(x => Convert.ToInt32(x.ToString())).ToList();

                response.IsValid = ValidateControlDigit(digitsNif);

                response.Type = GetType(digitsNif);

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }            

            return response;            
        }

        private void ValidateNifField()
        {
            if (_nif == null)
            {
                throw new ArgumentException("The NIF value is null");
            }

            if (_nif.Length != _lengthNif)
            {
                throw new ArgumentException("The NIF length is incorrect");
            }
        }

        private string GetType(List<int> digitsNif) 
        {
            if (Enumerable.Range(1,3).Contains(digitsNif[0]))
            {
                return "Single Person";
            }
            else if (digitsNif[0] == 5)
            {
                return "Legal Person";
            }            

            return "Unidentified type";
        }

        private bool ValidateControlDigit(List<int> digitsNif)
        {
            int calculateDigits = digitsNif[7] * 2 + digitsNif[6] * 3 + digitsNif[5] * 4 + digitsNif[4] * 5
            + digitsNif[3] * 6 + digitsNif[2] * 7 + digitsNif[1] * 8 + digitsNif[0] * 9;

            int divisionRest = calculateDigits % _divisionNumber;

            int lastDigitHasToBe = divisionRest <= 1 ? 0 : _divisionNumber - divisionRest;

            if (digitsNif[8] != lastDigitHasToBe)
            {
                throw new ArgumentException("The NIF is invalid");
            }

            return true;
        }
    }
}
