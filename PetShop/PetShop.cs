using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (!_petsInTheStore.Contains(newPet))
                _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsSpecies(Species.Cat));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);

            sortedPets.Sort((pet1, pet2) =>
                pet1.name.CompareTo(pet2.name)
            );
            return sortedPets;
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsMale().And(Pet.IsSpecies(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsSpecies(Species.Rabbit).Or(Pet.IsBornAfter(2011)));
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsSpecies(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsAnyOfSpecies(Species.Cat, Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(new Negate<Pet>(Pet.IsSpecies(Species.Mouse)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsSpecies(Species.Dog).And(Pet.IsBornAfter(2010)));
        }
    }
}