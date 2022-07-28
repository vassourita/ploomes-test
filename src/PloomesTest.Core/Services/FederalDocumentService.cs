namespace PloomesTest.Core.Services
{
    public class FederalDocumentService
    {
        public bool Validate(string federalDocument)
        {
            if (string.IsNullOrEmpty(federalDocument))
            {
                return false;
            }

            return federalDocument.Length == 11 ? ValidateCpf(federalDocument) : ValidateCnpj(federalDocument);
        }

        public bool ValidateCpf(string cpf)
        {
            var multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            for (var j = 0; j < 10; j++)
            {
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                {
                    return false;
                }
            }

            var tempCpf = cpf[..9];
            var sum = 0;

            for (var i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            }

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            for (var i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();

            return cpf.EndsWith(digit);
        }

        public bool ValidateCnpj(string cnpj)
        {
            var multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }

            var tempCnpj = cnpj[..12];
            var sum = 0;

            for (var i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            }

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            tempCnpj += digit;
            sum = 0;
            for (var i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();

            return cnpj.EndsWith(digit);
        }
    }
}