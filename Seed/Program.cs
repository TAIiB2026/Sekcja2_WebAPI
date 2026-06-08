using DAL;
using Models;
using System.Reflection.Emit;

namespace Seed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonEntity> repository = [
                new PersonEntity() {
                    DateOfBirth = new DateOnly(1992, 1, 30),
                    Email = "adam.kowalski@iks.pl",
                    Name = "Adam",
                    Phone = "999888777",
                    Surname = "Kowalski",
                    Addresses = [
                            new AddressEntity {
                                City = "Gdańsk",
                                PostalCode = "33-234",
                                Street = "Testowa"
                            },
                            new AddressEntity {
                                City = "Warszawa",
                                PostalCode = "11-333",
                                Street = "Marszałkowska"
                            },
                            new AddressEntity {
                                City = "Katowice",
                                PostalCode = "44-111",
                                Street = "Dworcowa"
                            }
                        ]
                },
                new PersonEntity() {
                    DateOfBirth = new DateOnly(1988, 5, 14),
                    Email = "anna.nowak@iks.pl",
                    Name = "Anna",
                    Phone = "123456789",
                    Surname = "Nowak"
                },

                new PersonEntity() {
                    DateOfBirth = new DateOnly(1995, 11, 2),
                    Email = "piotr.wisniewski@iks.pl",
                    Name = "Piotr",
                    Phone = "555666777",
                    Surname = "Wiśniewski",
                    Addresses = [
                            new AddressEntity {
                                City = "Warszawa",
                                PostalCode = "33-222",
                                Street = "Warszawska"
                            }
                        ]
                },

                new PersonEntity() {
                    DateOfBirth = new DateOnly(1990, 7, 21),
                    Email = "katarzyna.zielinska@iks.pl",
                    Name = "Katarzyna",
                    Phone = "888777666",
                    Surname = "Zielińska"
                },

                new PersonEntity() {
                    DateOfBirth = new DateOnly(1983, 3, 9),
                    Email = "marek.lewandowski@iks.pl",
                    Name = "Marek",
                    Phone = "444333222",
                    Surname = "Lewandowski"
                }
            ];

            using (PeopleContext peopleContext = new PeopleContext())
            {
                peopleContext.AddRange(repository);
                peopleContext.SaveChanges();
            }
        }
    }
}
