namespace Demo.Interfaces
{
  public interface IWeapon : IItem
    {
        int Damage { get; set; }
    }


}

// NOTE Inheritance and Interfaces
// abstract class Animal
// {
//     public float Mass { get; set; }
//     public float Weight { get; set; }
//     public float Height { get; set; }
//     public void Breathe() { }
//     public void Reproduce() { }
//     public void Eat() { }
//     public void Move() { }
// }

// interface IAnimal
// {
//     float Mass { get; set; }
//     float Weight { get; set; }
//     float Height { get; set; }
//     int Breathe();
//     Bird Breathe(decimal o2Amount);
//     void Reproduce();
//     void Eat();
//     void Move();
// }

// class Bird : IAnimal
// {
//     public float Mass { get; set; }
//     public float Weight { get; set; }
//     public float Height { get; set; }

//     public void Breathe()
//     {
//         throw new NotImplementedException();
//     }

//     public Bird Breathe(decimal o2Amount)
//     {
//         throw new NotImplementedException();
//     }

//     public void Eat()
//     {
//         throw new NotImplementedException();
//     }

//     public void Move()
//     {
//         throw new NotImplementedException();
//     }

//     public void Reproduce()
//     {
//         throw new NotImplementedException();
//     }

// }

// class Dog : Animal
// {

//     public void Dig() { }
// }
// class Cat : Animal
// {

//     public void Meow() { }
// }

// class RUNEXAMPLE
// {
//     public List<Cat> Cats { get; private set; } = new List<Cat>();
//     List<Animal> Animals { get; set; } = new List<Animal>();

//     void Thing(string banana)
//     {
//         var dogs = new List<Dog>();
//         var fido = new Dog();
//         var felix = new Cat();

//         Animals.Add(fido);
//         Animals.Add(felix);

//         for (int i = 0; i < Animals.Count; i++)
//         {
//             var animal = Animals[i];

//             if (animal is Dog)
//             {
//                 var dog = (Dog) animal;
//                 dog.Dig();
//             }
//             if (animal is Cat)
//             {
//                 var cat = animal as Cat;
//                 cat.Meow();
//             }

//         }

//     }
// }