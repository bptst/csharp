using System;
using System.Collections.Generic;

namespace article
{


abstract class Publication 
{
  public abstract void PublishDetails();

}

    class Article
    {
        protected double prix;
        protected string designation;

        public Article(double prix, string designation)
        {
            this.prix = prix;
            this.designation = designation;
        }


    }

    class Video : Publication
    {
        protected double duree;
        protected double prix;
        protected string designation;
        public Video(double duree, double prix, string designation)
        {
            this.duree = duree;
            this.prix = prix;
            this.designation = designation;
        }

        public void afficher()
        {
            Console.WriteLine("La video est affiché");

        }
        public override void PublishDetails()
        {
            Console.WriteLine("\ndetail video");
            Console.WriteLine("duré video :"+this.duree);


		}
    }
    class Disque : Publication
    {
        protected string label;
        
        protected double prix;
        protected string designation;
        public Disque(string label, double prix, string designation)
        {
            this.label = label;
            this.prix = prix;
            this.designation = designation;
        }

        public void ecouter()
        {
            Console.WriteLine("Le disque est ecouté");

        }
        public override void PublishDetails()
        {
            Console.WriteLine("\ndetail disque");
            Console.WriteLine("label disque :"+this.label);


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





    enum TypeArticle
    {
        Alimentaire,
        Droguerie,
        Habillement,
        Loisir,
        notype
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
            Console.WriteLine("\narticle :" + this.nom);
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


            Console.WriteLine("type article (alimentaire, droguerie, habillement, loisir):");
            string type = Console.ReadLine();


            switch (type)
            {
                case ("alimentaire"):
                    return new Struc_Article(name, prix, quantite, TypeArticle.Alimentaire);

                case ("droguerie"):
                    return new Struc_Article(name, prix, quantite, TypeArticle.Droguerie);
                case ("loisir"):
                    return new Struc_Article(name, prix, quantite, TypeArticle.Loisir);
                case ("habillement"):
                    return new Struc_Article(name, prix, quantite, TypeArticle.Habillement);

            }
            return new Struc_Article(name, prix, quantite, TypeArticle.notype);         



        }

    }
// Introduit les fonctionnalités de System :

    // Classe de l'application :

    class MonApp
    {
        public static void Main()
        {
            Video TP = new Video(123, 2.3, "tvshow");			
            Disque CetC = new Disque("virg",78, "cd");

        	List<Publication> publicationlist = new List<Publication>();
            publicationlist.Add(TP);
            publicationlist.Add(CetC);
            
            foreach (Publication publi in publicationlist)
            {
                publi.PublishDetails();
            }
            ;
           





        }
    }
}