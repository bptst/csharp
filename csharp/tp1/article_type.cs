using System;
namespace article
{
    class Article
    {
        protected double prix;
        protected string designation;

        public Article(double prix, string designation)
        {
            this.prix = prix;
            this.designation = designation;
        }
        
        public void afficher()
        {
            Console.WriteLine("name :"+this.designation);
        }
    }

    class Livre : Article
    {
        protected int nb_page;

        public Livre(int nb_page, double prix, string designation)
            : base(prix, designation)
        {
            this.nb_page = nb_page;
        }
    }

    class Poche : Livre
    {
        private string categorie;

        public Poche(int nb_page, double prix, string designation, string categorie)
            : base(nb_page, prix, designation)
        {
            this.categorie = categorie;
        }
    }



enum TypeArticle {
            Alimentaire,
            Droguerie,
            Habillement,
            Loisir
        };
    struct Struc_Article
    {
        public string nom;
        public double prix;
        public int quantite;

       

        TypeArticle type;
        public Struc_Article(string nom, double prix, int quantite, TypeArticle type)
        {
            this.nom = nom;
            this.prix = prix;
            this.quantite = quantite;
			this.type=type;
            
        }
        public void afficher()
        {
            Console.WriteLine("article :" + this.nom);
            Console.WriteLine("prix :" + this.prix);
            Console.WriteLine("quantite :" + this.quantite);
            Console.WriteLine("type :" + this.type);

        }
        public void ajouter(int quantite_to)
        {
            this.quantite = this.quantite + quantite_to;
        }


        public void retirer(int quantite_to)
        {
            this.quantite = this.quantite - quantite_to;
        }

        public Struc_Article create_from_csl()
        {
            Console.WriteLine("Name article :");
            string name = Console.ReadLine();

            Console.WriteLine("Prix article :");
            double prix = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Quantite article :");
            int quantite = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("type article (Alimentaire, Droguerie, Habillement, Loisir):");
            string type = Console.ReadLine();


            switch (type)
            {
                case ("alimentaire"):
                    return new Struc_Article(nom, prix, quantite, TypeArticle.Alimentaire);

                case ("droguerie"):
                    return new Struc_Article(nom, prix, quantite, TypeArticle.Droguerie);
                case ("loisir"):
                    return new Struc_Article(nom, prix, quantite, TypeArticle.Loisir);
                case ("habillement"):
                    return new Struc_Article(nom, prix, quantite, TypeArticle.Habillement);

            }
            return new Struc_Article(nom, prix, quantite, TypeArticle.Droguerie);         



        }

    }
// Introduit les fonctionnalités de System :

    // Classe de l'application :
    class MonApp
    {
        // Fonction principale :
        public static void Main()
        {
            // Équivalent de System.Console.WriteLine :
            Console.WriteLine("Hello World!");
            Struc_Article a = new Struc_Article("test", 12.2, 200, TypeArticle.Alimentaire);
            
            a.afficher();
            a.ajouter(20);
            a.afficher();
            a.retirer(10);
            a.afficher();
            Struc_Article b =a.create_from_csl();
            b.afficher();

        }
    }
}