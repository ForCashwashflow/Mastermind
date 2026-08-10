# Mastermind

Ce projet est une version du jeu Mastermind.

Le but est de trouver un code secret composé de 4 chiffres entre 1 et 6.

Le joueur a maximum 10 tentatives pour trouver le bon code.

Après chaque tentative, le jeu indique :

- le nombre de chiffres bien placés
- le nombre de chiffres corrects mais mal placés
- le nombre de tentatives restantes

Les chiffres peuvent être utilisés plusieurs fois dans le code secret.

## Technologies utilisées

Pour le backend j'ai utilisé :

- C#
- ASP.NET Core
- API REST
- .NET 9

Pour le frontend j'ai utilisé :

- Vue.js
- Nuxt
- TypeScript

J'ai séparé le frontend et le backend pour avoir une structure plus claire.

Le backend contient toute la logique du jeu et le frontend permet au joueur d'utiliser le jeu depuis une interface web.

## Structure du projet

Le projet est séparé en deux parties :

### Mastermind.Api

C'est le backend de l'application.

Il contient principalement :

- les modèles
- les DTOs
- le service qui contient la logique du Mastermind
- le contrôleur qui permet au frontend de communiquer avec l'API

### Mastermind.Web

C'est le frontend de l'application.

J'ai séparé l'interface en plusieurs composants :

- création d'une nouvelle partie
- saisie d'une tentative
- affichage du résultat
- historique des tentatives

## Fonctionnement

Quand une nouvelle partie est créée, l'API génère un code secret de 4 chiffres entre 1 et 6.

Le joueur entre ensuite 4 chiffres.

Pour chaque tentative, le backend vérifie d'abord les chiffres qui sont à la bonne position.

Ensuite il vérifie les chiffres présents dans le code mais qui sont à une mauvaise position.

Un chiffre n'est compté qu'une seule fois.

La partie se termine quand le joueur trouve les 4 chiffres ou quand les 10 tentatives sont utilisées.

## Lancer le projet

Pour lancer le projet, il faut avoir .NET, Node.js et npm installés sur la machine.

Le backend et le frontend doivent être lancés séparément.

### 1. Lancer le backend

Ouvrir un terminal à la racine du projet puis faire :

```bash
cd Mastermind.Api
dotnet run
```

L'API va démarrer sur :

```text
http://localhost:5054
```

Il faut laisser ce terminal ouvert.

### 2. Lancer le frontend

Ouvrir un deuxième terminal à la racine du projet puis faire :

```bash
cd Mastermind.Web
npm install
npm run dev
```

Le frontend va démarrer sur :

```text
http://localhost:3000
```

Il suffit ensuite d'ouvrir cette adresse dans le navigateur.

Le backend doit rester lancé pour que le frontend puisse communiquer avec l'API.

## Difficultés rencontrées

J'ai rencontré quelques difficultés pendant la réalisation du projet.

Une des premières difficultés était la mise en place de l'environnement. J'avais au début utilisé une autre version de .NET et j'ai finalement utilisé .NET 9 avec Visual Studio 2022.

J'ai aussi rencontré quelques difficultés pour organiser correctement le frontend et le backend. J'ai donc séparé le projet en deux parties : `Mastermind.Api` pour le backend et `Mastermind.Web` pour le frontend.

La communication entre le frontend et l'API m'a également demandé quelques ajustements, notamment pour créer une partie, envoyer les tentatives et récupérer l'historique.

J'ai également dû faire attention à la logique des chiffres bien placés et mal placés pour qu'un même chiffre ne soit pas compté plusieurs fois.

## Ce que j'ai appris

J'avais déjà utilisé C# pendant ma première année académique. Ce projet m'a donc permis de reprendre C# et de l'utiliser cette fois-ci pour créer une API avec ASP.NET Core.

Pour le frontend, j'avais déjà travaillé avec JavaScript, TypeScript et React.

Par contre, c'était la première fois que j'utilisais Vue.js et Nuxt. J'ai donc dû découvrir leur fonctionnement pendant le développement du projet.

Comme j'avais déjà travaillé avec React, je n'étais pas complètement perdu. J'ai retrouvé certains principes que je connaissais déjà, surtout le fonctionnement avec les composants.

Ce projet m'a donc permis de découvrir Vue.js et Nuxt tout en utilisant mes connaissances précédentes en JavaScript et TypeScript.

## Utilisation de l'IA

J'ai utilisé un peu l'intelligence artificielle pendant le développement du projet.

Je l'ai principalement utilisée comme aide lorsque j'avais des erreurs, pour mieux comprendre certains problèmes et pour avoir des explications sur Vue.js et Nuxt que je découvrais pour la première fois.

J'ai essayé de ne pas simplement copier du code, mais de comprendre les solutions proposées et de les adapter à la structure de mon projet.

Cela m'a surtout aidé à avancer lorsque j'étais bloqué et à découvrir plus rapidement certaines technologies que je n'avais jamais utilisées auparavant.
