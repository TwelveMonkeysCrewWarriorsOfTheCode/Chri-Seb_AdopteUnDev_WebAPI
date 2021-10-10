/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Category (Name)
Values ('Back-End')

INSERT INTO Category (Name)
Values ('Database')

INSERT INTO Category (Name)
Values ('Front-End')

INSERT INTO Skill (Name, Description, CategoryID)
Values ('React', 'JS', 3)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('Angular', 'JS', 3)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('VueJS', 'JS', 3)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('ASP MVC', 'C#', 3)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('WPF', 'C#', 3)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('NodeJS', 'JS', 1)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('ExpressJS', 'JS', 1)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('ASP API', 'C#', 1)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('Spring', 'Java', 1)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('MySql', 'DB', 2)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('SqlServer', 'DB', 2)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('Oracle', 'DB', 2)

INSERT INTO Skill (Name, Description, CategoryID)
Values ('PL-Sql', 'DB', 2)