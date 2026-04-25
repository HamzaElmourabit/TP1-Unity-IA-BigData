# TP1 – Simulation interactive et collecte de données

## 📌 Description

Ce projet a été réalisé dans le cadre d’un Travaux Pratiques sur **Unity 6** et l’**Intelligence Artificielle / Big Data**.  
L’objectif est de créer une simulation 3D interactive où l’utilisateur peut se déplacer et cliquer sur des objets, tandis que son comportement est enregistré (clics, positions, temps) dans des fichiers JSON et CSV pour une analyse ultérieure.

## 👥 Binôme

- **Hamza Elmourabit**
- **Oussama Hajar**

## 🎮 Fonctionnalités

- **Déplacement à la première personne** (clavier + souris)
- **Clic sur objets interactifs** → changement de couleur aléatoire + log
- **Enregistrement automatique** :
  - Nombre total de clics
  - Temps passé dans la scène
  - Position du joueur toutes les secondes
  - Historique des objets cliqués (avec horodatage)
- **Sauvegarde** en JSON et CSV dans le dossier `Assets/`
- **(Bonus)** Objet qui suit le joueur OU déplacement aléatoire avec évitement d’obstacles

## 🛠️ Technologies utilisées

- Unity 6 (compatible 2022 LTS)
- Langage C#
- .NET Standard 2.1
- JSON & CSV pour l’export des données

## 📁 Structure du projet

Voici l’arborescence complète du projet :
```
TP1_Unity_IA/
│
├── Assets/
│ ├── Scenes/
│ │ └── MainScene.unity # Scène principale
│ │
│ ├── Scripts/
│ │ ├── PlayerMovement.cs # Déplacements du joueur
│ │ ├── ClickableObject.cs # Interaction clic + changement couleur
│ │ ├── DataLogger.cs # Collecte et sauvegarde des données
│ │ ├── Follower.cs # (Bonus) Poursuite du joueur
│ │ └── Wander.cs # (Bonus) Déplacement aléatoire
│ │
│ ├── Materials/
│ │ ├── GroundMat.mat # Matériau du sol
│ │ ├── RedMat.mat # Matériau obstacle rouge
│ │ └── BlueMat.mat # Matériau obstacle bleu
│ │
│ ├── session_data.json # Généré après exécution
│ └── session_data.csv # Généré après exécution
│
├── Packages/ # (géré automatiquement par Unity)
├── ProjectSettings/ # (géré automatiquement par Unity)
└── README.md # Ce fichier
```
**Légende** :  
- Les dossiers `Scenes`, `Scripts`, `Materials` sont à créer manuellement.  
- Les fichiers `session_data.json` et `.csv` apparaissent automatiquement après avoir joué et quitté la scène.

## 🚀 Installation et exécution

1. **Cloner ou télécharger** ce dépôt.
2. Ouvrir **Unity Hub** → **Add project** → sélectionner le dossier du projet.
3. Ouvrir le projet avec **Unity 6** (ou 2022 LTS).
4. Dans la fenêtre **Project**, ouvrir la scène principale (`Assets/Scenes/MainScene.unity`).
5. Appuyer sur **Play** pour lancer la simulation.

## 🎮 Utilisation

| Action                     | Commande                     |
|----------------------------|------------------------------|
| Se déplacer                | ZQSD / flèches               |
| Regarder autour            | Souris                       |
| Cliquer sur un objet       | Clic gauche sur cube/sphère  |
| Quitter la simulation      | Alt+F4 ou arrêter le Play    |

À la fermeture du jeu (ou à l’arrêt du Play mode), deux fichiers sont créés dans `Assets/` :
- `session_data.json` – données structurées
- `session_data.csv` – données tabulaires (exploitable avec Excel ou Python)

## 📊 Format des données enregistrées

### Exemple JSON
```json
{
  "totalClicks": 5,
  "sessionDuration": 42.3,
  "positions": [
    { "x": 0.0, "y": 0.6, "z": 0.0, "timestamp": 0.0 },
    { "x": 1.2, "y": 0.6, "z": 2.1, "timestamp": 1.0 }
  ],
  "clickEvents": [
    { "objectName": "Cube Rouge", "timestamp": 12.5 }
  ]
}
