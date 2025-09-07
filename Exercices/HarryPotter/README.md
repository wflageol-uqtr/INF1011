
# Exercice 1 - Harry Potter (Code Kata)

Le premier exercice consiste à compléter un programme en suivant une structure orientée-objet. 

Votre objectif principal dans les exercices est de faire passer les tests unitaires prédéfinis de chaque programme.

#### Spécifications

Les 5 premiers livres de la saga Harry Potter sont à vendre dans une librairie. Chaque livre coûte 8$. La librairie applique certaines politiques de rabais en fonction du total des achats qui sont faits :

* 2 livres différents : 5%
* 3 livres différents : 10%
* 4 livres différents : 20% 
* 5 livres différents : 25%

Il faut concevoir un programme qui reçoit en entrée une liste de livres et qui retourne le prix total incluant les rabais applicables.

![](resources/semaine1_hp_calcul.png)

Attention par contre, un rabais peut s'appliquer plus d'une fois sur la même liste d'articles!

![](resources/semaine1_hp_piege.png)

#### À faire

Heureusement, nous avons déjà conçu la structure du programme en classe durant la première séance. Tout ce qui vous reste à faire est à implémenter les méthodes manquantes pour que tout fonctionne. 

Voici le graphe UML de la structure montée en classe :

![](resources/semaine1_hp_uml.png)

    class Book {
        - bookNb: int
        + new(nb: int)
        + equals(o: Object)
    }

    class Basket {
        + new(books: Book[])
        + howMany(b: Book): int
        + howManyDifferent(): int
        + howManyBooks(): int
        + isEmpty(): bool
        + removeDifferent(nb: int): Basket
    }

    class Discount {
        + new(n: int, p: double)
        + canBeApplied(b: Basket): bool
        + apply(basePrice: double ): double
        + removedPaidBooks(b: Basket): Basket
    }

    class Cashier {
        - price: double
        - discounts: Discount[]
        + new(basePrice: int, discounts: Discount[])
        + compute(b: Basket): double
        + compute(b: Basket, Discount d): double
        + findAvailableDiscount(b: Basket): Discount[]
    }


    Book -- Basket
    
    Basket -- Cashier
    
    Cashier .. Discount
    
    Basket .. Discount

L'objectif ici est que vous preniez connaissance de l'impact qu'une bonne conception peut avoir sur le développement d'un logiciel: un problème qui semble complexe peut devenir presque trivial à résoudre une fois la bonne structure mise en place!