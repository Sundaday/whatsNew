using System;

namespace What_s_new_in_C
{
    struct PersonneStruct
    {
        public string name { get; set; }
        public int id { get; set; }

        public void Afficher()
        {
            Console.WriteLine("name: " + name + ", id: " + id);
        }
    }
    record PersonneRecord
    {
        public string name { get; set; }
        public int id { get; set; }

        public PersonneRecord(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public void Deconstruct(out string name, out int id)
        {
            name = this.name;
            id = this.id;
        }
        public void Afficher()
        {
            Console.WriteLine("name: " + name + ", id: " + id);
        }
    }
    class PersonneClass
    {
        public string name { get; set; }
        public int id { get; set; }

        public void Afficher()
        {
            Console.WriteLine("name: " + name + ", id: " + id);
        }
        //Ne pouvant pas tester l'égalité en personne1 et personne2 avec Equals
        //Nous devons la methode pour pouvoir obtenir le resultat souhaité
        public override bool Equals(object obj)
        {
            PersonneClass objetAComparer = (PersonneClass)obj;
            if ((name == objetAComparer.name) && (id == objetAComparer.id)) 
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pointe et set par valeur et non par référence{
            //int a = 5;
            //int b = 10;

            //b = a;
            //a = 6;

            //Console.WriteLine("a = " + a);
            //Console.WriteLine("b = " + b);
            //}


            //Classe marche par référence(adresse) et non par valeur(variable),
            //permettant le changement de valeur lors de var personne2 = personne1;
            //L'adresse de personne1 est stocké dans personne 2
            //le contenu des champs n'est pas important pour vérifier une égalité
            Console.WriteLine("Class");
            var personne1 = new PersonneClass() { name = "Toto", id = 5 };
            var personne5 = new PersonneClass() { name = "Toto", id = 5 };
            var personne2 = personne1; //True
            //personne1.name = "Tata";
 
            personne1.Afficher();   
            personne2.Afficher();

            Console.WriteLine(personne1.Equals(personne5)); //False
            Console.WriteLine();

            //Struct pointe vers les valeurs et non par la référence(adresse);
            //personne3.name = "Tata" ne s'applique donc pas a personne4
            //le contenu des champs est important pour vérifier une égalité
            Console.WriteLine("Struct");
            var personne3 = new PersonneStruct() { name = "Toto", id = 5 };
            var personne4 = personne3; //False
            personne3.name = "Tata";
 
            personne3.Afficher();   
            personne4.Afficher();

            //Console.WriteLine(personne3 == personne4); X ne fonctionne pas
            Console.WriteLine(personne3.Equals(personne4)); //False
            Console.WriteLine();

            //Types simples (int,float,char...) -> Value type (valeur)
            //Struct -> Value Type (valeur = les valeurs des champs)
            //Class -> Reference Type (valeur = adresse de l'objet)
            //Record -> Value Type (valeur = les valeurs des champs)

            Console.WriteLine("Record");
            var personne6 = new PersonneRecord() { name = "Toto", id = 5 };
            //var personne7 = new PersonneRecord() { name = "Toto", id = 5 }; true

            //Record clone les valeurs mais pas la reference; Equals sera donc false Toto != Titi;
            var personne7 = personne6 with { }; //True
            personne6.name = "Titi";

            personne6.Afficher();
            personne7.Afficher();

            Console.WriteLine(personne6.Equals(personne7)); //False
            Console.WriteLine();
        }
    }
}
