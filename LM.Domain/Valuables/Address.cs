using System.Collections.Generic;
using LM.Responses;
using LM.Responses.Extensions;

namespace LM.Domain.Valuables
{
    public class Address : ValueObject
    {
        Address() { }
        Address(string cep, string street, string neighborhood, string number, string city, string uf, string complement)
        {
            Cep = cep;
            Street = street;
            Complement = complement;
            Neighborhood = neighborhood;
            Number = number;
            City = city;
            UF = uf;
        }

        public string Cep { get; private set; }

        public string Street { get; private set; }

        public string Complement { get; private set; }

        public string Neighborhood { get; private set; }

        public string Number { get; private set; }

        public string City { get; private set; }

        public string UF { get; private set; }

        public Response<Address> Update(string cep, string street, string neighborhood, string number, string city, string uf, string complement = "")
        {
            var response = Response<Address>.Create();

            var isValid = IsValid(cep, street, neighborhood, number, city, uf);

            if (isValid.HasError)
                return response.WithMessages(isValid.Messages);

            return response.SetValue(new Address(cep, street, neighborhood, number, city, uf, complement));
        }

        static Response<bool> IsValid(string cep, string street, string neighborhood, string number, string city, string uf)
        {
            var response = Response<bool>.Create(true);

            if (string.IsNullOrEmpty(cep))
                response.WithBusinessError(nameof(cep), $"O campo {nameof(cep)} é obrigatório.");

            if (string.IsNullOrEmpty(street))
                response.WithBusinessError(nameof(street), $"O campo {nameof(street)} é obrigatório.");

            if (string.IsNullOrEmpty(number))
                response.WithBusinessError(nameof(number), $"O campo {nameof(number)} é obrigatório.");

            if (string.IsNullOrEmpty(city))
                response.WithBusinessError(nameof(city), $"O campo {nameof(city)} é obrigatório.");

            if (string.IsNullOrEmpty(uf))
                response.WithBusinessError(nameof(uf), $"O campo {nameof(uf)} é obrigatório.");

            return response.SetValue(!response.HasError);
        }

        public static Response<Address> Create(string cep, string street, string neighborhood, string number, string city, string uf, string complement = "")
        {
            var response = Response<Address>.Create();

            var isValid = IsValid(cep, street, neighborhood, number, city, uf);

            if (isValid.HasError)
                return response.WithMessages(isValid.Messages);

            return response.SetValue(new Address(cep, street, neighborhood, number, city, uf, complement));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Cep;
            yield return Street;
            yield return Complement;
            yield return Neighborhood;
            yield return Number;
            yield return City;
            yield return UF;
        }

        public static implicit operator Address(Maybe<Address> entity) => entity.Value;

        public static implicit operator Address(Response<Address> entity) => entity.Data;
    }
}