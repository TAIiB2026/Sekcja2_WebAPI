using Contracts;
using Contracts.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Database
{
    public class PeopleDatabaseRepository : IPeopleService
    {
        private readonly PeopleContext peopleContext;

        public PeopleDatabaseRepository(PeopleContext peopleContext)
        {
            this.peopleContext = peopleContext;
        }

        public async Task<IEnumerable<PersonDTO>> GetAsync()
        {
            var data = await this.peopleContext.PeopleDbSet.ToListAsync();
            return data.Select(x => new PersonDTO(x.Id, x.Name, x.Surname, x.DateOfBirth));
        }

        public async Task<PersonDTO?> GetByIDAsync(int Id)
        {
            var data = await this.peopleContext.PeopleDbSet.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(data is null)
            {
                return null;
            }

            return new PersonDTO(data.Id, data.Name, data.Surname, data.DateOfBirth);
        }

        public async Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            PersonEntity personEntity = new PersonEntity
            {
                DateOfBirth = newPersonDTO.DateOfBirth,
                Surname = newPersonDTO.Surname,
                Name = newPersonDTO.Name,
                Phone = "",
                Email = ""
            };

            await peopleContext.AddAsync(personEntity);
            try
            {
                await peopleContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await peopleContext.PeopleDbSet.FindAsync(id);
            if (data is not null)
            {
                peopleContext.Remove(data);
                await peopleContext.SaveChangesAsync();
            }
        }

        public async Task Delete2Async(int id)
        {
            await peopleContext.PeopleDbSet.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<PersonAdressDTO>> GetAddresses(int PersonID)
        {
            var data = await peopleContext.PeopleDbSet.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == PersonID);
            
            if (data is not null)
            {
                var addresses = data.Addresses;
                return addresses.Select(x => new PersonAdressDTO(x.Person.Name, x.ID, x.City, x.Street));
            }

            return [];
        }

        public async Task PostAddressAsync(int PersonID, string PostalCode, string City, string Street)
        {
            PersonEntity personEntity = await this.peopleContext.PeopleDbSet.FindAsync(PersonID);

            AddressEntity addressEntity = new AddressEntity
            {
                City = City,
                Street = Street,
                PostalCode = PostalCode,
                Person = personEntity
            };

            await this.peopleContext.AddAsync(addressEntity);
            await this.peopleContext.SaveChangesAsync();
        }
    }
}
