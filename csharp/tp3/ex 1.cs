using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace article
{
	
	public static class List_extension
			{
				public static void AfficherTous(this Article[] a){
					
					foreach(Article i in a){
						i.afficher();
					}
				}	
			}

class Catalogue
{
    private ArticleTypé[] tab_articles;

    public Catalogue(ArticleTypé[] tab_articles)
    {
        this.tab_articles = tab_articles;
    }

    public ArticleTypé this[int index]
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

    public class Article
    {
        public double prix { get; set; }
        public string designation{ get; set; }
		public int quantite{ get; set; }

        public Article(double prix,int quantite, string designation)
        {
            this.prix = prix;
			this.quantite=quantite;
            this.designation = designation;
        }
		
		
		 public void afficher()
        {
            Console.WriteLine("\narticle :" + this.designation);
            Console.WriteLine("prix :" + this.prix);
            Console.WriteLine("quantite :" + this.quantite);

        }
        public void ajouter(int quantite_to)
        {
            this.quantite = this.quantite + quantite_to;
        }


        public void retirer(int quantite_to)
        {
            this.quantite = this.quantite - quantite_to;
        }



    }
	class ArticleTypé : Article{
		public TypeArticle type;
		
		 public ArticleTypé(double prix, int quantite, string designation, TypeArticle type) : base(prix, quantite, designation)
        {
            this.type = type;
        }

	}

    class Video : ArticleTypé
    {
        protected double duree;
        public Video(double duree, double prix, int quantite, string designation, TypeArticle type) : base(prix, quantite, designation, type)
        {
            this.duree = duree;
        }

    }
    class Disque : ArticleTypé
    {
        protected string label;
        public Disque(string label, double prix,int quantite, string designation, TypeArticle type) : base(prix,quantite, designation, type)
        {
            this.label = label;
        }

        public void ecouter()
        {
            Console.WriteLine("Le disque est ecouté");

        }
    }
    class Livre : ArticleTypé
    {
        protected int nb_page;

        public Livre(int nb_page, double prix,int quantite, string designation, TypeArticle type)
            : base(prix, quantite, designation, type)
        {
            this.nb_page = nb_page;
        }
    }

    class Poche : Livre
    {
        private string categorie;

        public Poche(int nb_page, double prix, int quantite, string designation, string categorie, TypeArticle type)
            : base(nb_page, prix, quantite, designation, type)
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


						ArticleTypé[] array_article = {
			new ArticleTypé( 2.5, 50,"Pomme", TypeArticle.Alimentaire),
			new ArticleTypé( 3.2, 30,"Savon", TypeArticle.Droguerie),
			new ArticleTypé( 15.0, 20,"T-shirt", TypeArticle.Habillement) };
			
			Catalogue Tab_article= new Catalogue(array_article);

			

 
			//Lister les aliments
			
			 Console.WriteLine("Liste des aliments:");

			var list_alimentaire = array_article.Where(article => article.type==TypeArticle.Alimentaire);
			
			foreach(ArticleTypé aliment in list_alimentaire.ToList()){
				aliment.afficher();
				
			}
			
			
			
			
			
			//Trier les articles par prix décroissant
			
			Console.WriteLine("\nListe trier par prix décroissant: ");

			var list_trie = array_article.OrderByDescending(article => article.prix);
			
			foreach(ArticleTypé i in list_trie.ToList()){
				i.afficher();
				
			}
			//somme quantite
			Console.WriteLine("\nQuantite total: ");
			var quantite_tot = array_article.Select(f=> f.quantite).Sum();
			Console.WriteLine(quantite_tot);

			
			
			
			
		
			//Filtre par type
			Console.WriteLine("\nFiltre par type: ");

			Article[] array_mixe = {
			new ArticleTypé( 2.5, 50,"Pomme", TypeArticle.Alimentaire),
			new Article( 250, 5,"Ordinateur"),
			new ArticleTypé( 3.2, 30,"Savon", TypeArticle.Droguerie),
			new ArticleTypé( 15.0, 20,"T-shirt", TypeArticle.Habillement) };
			
			
			var list_articletype = array_mixe.OfType<ArticleTypé>();
			
			foreach(ArticleTypé i in list_articletype.ToList()){
				i.afficher();
				
			}
			
			//vue simplifié:
			
			Console.WriteLine("\nVue simplifie");
			var new_v = array_article.Select(f=> new {Name=f.designation,Prix=f.prix});
			
			foreach(var i in new_v.ToList()){
				Console.WriteLine(i);
				
			}
			
					//Metgode extension
					Console.WriteLine("\nMethode Extenstion");

				array_mixe.AfficherTous();
			
			//valeur totale du stock de tous les articles
			Console.WriteLine("\nValeur stock total:");

			Func<Article[],double> val_stock = x => x.Select(f=> f.quantite * f.prix).Sum();
			
			Console.WriteLine(val_stock(array_mixe));
			
			//Etape 4

				Console.WriteLine("\nSerialisation deserialisaiton:");

			
			string jsonString = JsonSerializer.Serialize(array_mixe);
			
			Article[] deseri_articles = JsonSerializer.Deserialize<Article[]>(jsonString);
			
			deseri_articles.AfficherTous();
			


        }
    }
}