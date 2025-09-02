using System;
namespace article
{

class Catalogue
{
    private Struc_Article[] tab_articles;

    public Catalogue(Struc_Article[] tab_articles)
    {
        this.tab_articles = tab_articles;
    }

    // Indexeur : permet d'accéder aux articles par indice
    public Struc_Article this[int index]
    {
        get
        {
            return tab_articles[index];
        }
        set
        {

            tab_articles[index] = value;
        }
    }

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

    class Video : Article
    {
        protected double duree;
        public Video(double duree, double prix, string designation) : base(prix, designation)
        {
            this.duree = duree;
        }

        public void afficher()
        {
            Console.WriteLine("La video est affiché");

        }
    }
    class Disque : Article
    {
        protected string label;
        public Disque(string label, double prix, string designation) : base(prix, designation)
        {
            this.label = label;
        }

        public void ecouter()
        {
            Console.WriteLine("Le disque est ecouté");

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
        // Fonction principale :
        public static void Main()
        {
            // Équivalent de System.Console.WriteLine :
            Console.WriteLine("Hello World!");
            Struc_Article a = new Struc_Article("a", 12.2, 200, TypeArticle.Alimentaire);
            Struc_Article c = new Struc_Article("c", 2.27, 20, TypeArticle.Alimentaire);
            Struc_Article d = new Struc_Article("d", 45.78, 205, TypeArticle.Alimentaire);
			
			

            Struc_Article[] array_article = [a,c,d];
			Catalogue Tab_article= new Catalogue(array_article);


            
            Tab_article[2].afficher();
            Tab_article[2].ajouter(20);
            Tab_article[2].afficher();
            Tab_article[2].retirer(10);
            Tab_article[2].afficher();
			
			

            
            foreach (Struc_Article article in array_article)
            {
                article.afficher();
            }

			
			Tab_article[2].afficher();
			Tab_article[1].afficher();
			Tab_article[2].afficher();


            Struc_Article b =a.create_from_csl();
            b.afficher();


        }
    }
}