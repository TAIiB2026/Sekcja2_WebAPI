using Contracts.Models;

namespace Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonDTO>> GetAsync();
        Task<PersonDTO?> GetByIDAsync(int Id);
        Task<bool> PostAsync(NewPersonDTO newPersonDTO);
        Task<IEnumerable<PersonAdressDTO>> GetAddresses(int PersonID);
        Task PostAddressAsync(int PersonID, string PostalCode, string City, string Street);
    }
}
