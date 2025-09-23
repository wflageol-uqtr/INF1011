## Travail Pratique 2 - Poker

Pour votre deuxième exercice, vous aurez à restructurer (_refactor_) du code légataire dans une mise en situation. Le programme en question est un algorithme pour analyser les mains de Poker.

### Spécifications

L'algorithme prend en entrée une chaîne de caractères représentant une main de 5 cartes encodées sous la forme suivante :

Valeurs : A 2 3 4 5 6 7 8 9 T J Q K  
Suites : H D S C

Exemple de main : _AS 4C TD QC 4C_

L'algorithme retourne ensuite le type de main en tant que valeur de l'énumération suivante :

    public enum Hand {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
    
Voici une courte explication de chaque main, de la plus faible à la plus forte. Dans le cas où plusieurs types de main s'applique, l'algorithme retourne toujours la plus forte.

| Valeur        | Nom          | Description                                          |
| ---           | ---          | ---                                                  |
| HighCard      | Carte haute  | Aucune autre main visible.                           |
| Pair          | Paire        | Deux cartes de même valeur.                          |
| TwoPair       | Deux paires  | Deux paires différentes.                             |
| ThreeOfAKind  | Brelan       | Trois cartes identiques.                             |
| Straight      | Suite        | Cinq cartes de valeurs successives (e.g. 8-9-T-J-Q). |
| Flush         | Couleur      | Cinq cartes de la même suite.                        |
| FullHouse     | Main pleine  | Un brelan et une paire.                              |
| FourOfAKind   | Carré        | Quatre cartes identiques.                            |
| StraightFlush | Quinte flush | Cinq cartes de valeurs successives de la même suite. |


### À faire

Le code déjà en place satisfait les spécifications présentées. L'objectif ici sera de le restructurer en utilisant de bonnes pratiques de conception et programmation pour ensuite le faire évoluer : certaines fonctionnalités sont à ajouter.

#### Quinte flush royale

En plus des mains présentées ci-haut, le code devra aussi détecter la possibilité d'une quinte flush royale, dont voici la spécification :

| Valeur     | Nom                 | Description                        |
| ---        | ---                 | ---                                |
| RoyalFlush | Quinte flush royale | T, J, Q, K, et A de la même suite. |

Cette main a une valeur supérieure à toutes les autres et doit donc être priorisée.

#### Joker

En second lieu, l'algorithme devra maintenant permettre d'ajouter jusqu'à deux jokers dans une main. Un joker (représenté par l'encodage JK) prend la valeur et la suite de façon à ce que la main ait la valeur la plus élevée possible.

Par exemple, la main _8S JK 6S 5S 4S_ verra le joker prendre la valeur _7S_, car cela compléterait une quinte flush. De même, la main _AH JK JK 4S 7H_ verra les deux jokers prendre la valeur _A_ (ou _4_ ou _6_) pour donner un brelan.