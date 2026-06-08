using Contracts;
using Contracts.Models;
using Models;

namespace Services.Memory
{
    public class PeopleMemoryRepository : IPeopleService
    {
        private static int ID_GENERATOR = 1;
        private static List<PersonEntity> repository = [
                new PersonEntity() {
                    Id = ID_GENERATOR++,
                    DateOfBirth = new DateOnly(1992, 1, 30),
                    Email = "adam.kowalski@iks.pl",
                    Name = "Adam",
                    Phone = "999888777",
                    Surname = "Kowalski"
                },
                new PersonEntity() {
                    Id = ID_GENERATOR++,
                    DateOfBirth = new DateOnly(1988, 5, 14),
                    Email = "anna.nowak@iks.pl",
                    Name = "Anna",
                    Phone = "123456789",
                    Surname = "Nowak"
                },

                new PersonEntity() {
                    Id = ID_GENERATOR++,
                    DateOfBirth = new DateOnly(1995, 11, 2),
                    Email = "piotr.wisniewski@iks.pl",
                    Name = "Piotr",
                    Phone = "555666777",
                    Surname = "Wiśniewski"
                },

                new PersonEntity() {
                    Id = ID_GENERATOR++,
                    DateOfBirth = new DateOnly(1990, 7, 21),
                    Email = "katarzyna.zielinska@iks.pl",
                    Name = "Katarzyna",
                    Phone = "888777666",
                    Surname = "Zielińska"
                },

                new PersonEntity() {
                    Id = ID_GENERATOR++,
                    DateOfBirth = new DateOnly(1983, 3, 9),
                    Email = "marek.lewandowski@iks.pl",
                    Name = "Marek",
                    Phone = "444333222",
                    Surname = "Lewandowski"
                }
            ];

        public Task<IEnumerable<PersonDTO>> GetAsync()
        {
            var res = repository.Select(x => EntityToDTO(x));
            return Task.FromResult(res);
        }

        private PersonDTO EntityToDTO(PersonEntity personEntity)
        {
            return new PersonDTO(personEntity.Id, personEntity.Name, personEntity.Surname, personEntity.DateOfBirth);
        }

        public Task<PersonDTO?> GetByIDAsync(int Id)
        {
            PersonEntity? obj = repository.Find(x => x.Id == Id);
            PersonDTO? res;

            if(obj is null)
            {
                res = null;
            } else
            {
                res = EntityToDTO(obj);
            }

            return Task.FromResult(res);
        }

        public Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            bool res;

            if (repository.Count >= 10)
            {
                res = false;
            }
            else
            {
                var newObj = new PersonEntity
                {
                    DateOfBirth = newPersonDTO.DateOfBirth,
                    Email = null,
                    Id = ID_GENERATOR++,
                    Name = newPersonDTO.Name,
                    Phone = null,
                    Surname = newPersonDTO.Surname
                };
                repository.Add(newObj);
                res = true;
            }

            return Task.FromResult(res);
        }

        public Task<IEnumerable<PersonAdressDTO>> GetAddresses(int PersonID)
        {
            throw new NotImplementedException();
        }

        public Task PostAddressAsync(int PersonID, string PostalCode, string City, string Street)
        {
            throw new NotImplementedException();
        }
    }
}
