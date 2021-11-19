
use velomax;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE TABLE `Velos` (
  `Id` int(11) NOT NULL,
  `ModeleNum` varchar(100) NOT NULL,
  `Nom` varchar(100) NOT NULL,
  `Grandeur` varchar(100) NOT NULL,
  `Ligne` varchar(100) NOT NULL,
  `Prix` double NOT NULL,
  `dateentree` varchar(20) DEFAULT NULL,
  `datefin` varchar(20) DEFAULT NULL,
  `Quantite` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `Velos` (`Id`, `ModeleNum`, `Nom`, `Grandeur`, `Ligne`, `Prix`, `dateentree`, `datefin`, `Quantite`) VALUES
(101, '101', 'Kilimandjaro', 'Adultes', 'VTT', 569, NULL, NULL, 25),
(102, '102', 'NorthPole', 'Adultes', 'VTT', 329, NULL, NULL, 10),
(103, '103', 'MontBlanc', 'Jeunes', 'VTT', 399, NULL, NULL, 10),
(104, '104', 'Hooligan', 'Jeunes', 'VTT', 199, NULL, NULL, 40),
(105, '105', 'Orléans', 'Hommes', 'Vélo de course', 229, NULL, NULL, 8),
(106, '106', 'Orléans', 'Dames', 'Vélo de course', 229, NULL, NULL, 10),
(107, '107', 'BlueJay', 'Hommes', 'Vélo de course', 349, NULL, NULL, 15),
(108, '108', 'BlueJay', 'Dames', 'Vélo de course', 349, NULL, NULL, 16),
(109, '109', 'Trail Explorer', 'Filles', 'Classique', 129, NULL, NULL, 15),
(110, '110', 'Trail Explorer', 'Garçons', 'Classique', 129, NULL, NULL, 18),
(111, '111', 'Night Hawk', 'Jeunes', 'Classique', 189, NULL, NULL, 20),
(112, '112', 'Tierra Verde', 'Hommes', 'Classique', 199, NULL, NULL, 15),
(113, '113', 'Tierra Verde', 'Dames', 'Classique', 199, NULL, NULL, 15),
(114, '114', 'Mud Zinger I', 'Jeunes', 'BMX', 279, NULL, NULL, 15),
(115, '115', 'Mud Zinger II', 'Adultes', 'BMX', 279, NULL, NULL, 20);


CREATE TABLE `Piece` (
  `Id` int(11) NOT NULL,
  `ProductNumber` varchar(100) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `Fournisseur` varchar(100) DEFAULT NULL,
  `FournisseurId` int(11) DEFAULT NULL,
  `Grandeur` varchar(100) NOT NULL,
  `Prix` double NOT NULL,
  `dateentree` varchar(20) NOT NULL,
  `datefin` varchar(20) NOT NULL,
  `Quantite` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;



INSERT INTO `Piece` (`Id`, `ProductNumber`, `Description`, `Fournisseur`, `FournisseurId`, `Grandeur`, `Prix`, `dateentree`, `datefin`, `Quantite`) VALUES
(1,'Kilimandjaro', 'C32*G7*F3*S88', '', '', 'Adultes',Null,Null, Null, 10),
(2,'NorthPole', 'C34*G7*F3*S88', '', '', 'Adultes',Null,Null, Null, 15),
(3,'MontBlanc', 'C76*G7*F3*S88', '', '', 'Jeunes',Null,Null, Null, 20),
(4,'Hooligan', 'C76*G7*F3*S88', '', '', 'Jeunes',Null,Null, Null, 10),
(5,'Orleans', 'C43*G9*F9*S37', '', '', 'Hommes',NULL,Null, Null, 20),
(6,'Orleans', 'C44f*G9*F9*S35', '', '', 'Dames',Null,Null, Null, 10),
(7,'BlueJay', 'C43*G9*F9*S37', '', '', 'Hommes',Null,Null, Null, 10),
(8,'BlueJay', 'C43f*G9*F9', '', '', 'Dames',Null,Null, Null, 20),
(9,'Trail Explorer', 'C01*G12*null*S02', '', '', 'Filles',Null,Null, Null, 10),
(10,'Trail Explorer', 'C02*G12*null*S03', '', '', 'Garçons',Null,Null, Null, 10),
(11,'Night Hawk', 'C15*G12*F9*S36', '', '', 'Jeunes',Null,Null, Null, 15),
(12,'Tierra Verde', 'C87*G12*F9*S36', '', '', 'Hommes',Null,Null, Null, 8),
(13,'Tierra Verde', 'C87f*G12*F9*S34', '', '', 'Dames',Null,Null, Null, 7),
(14,'Mud Zinger I', 'C25*G7*F3*S87', '', '', 'Jeunes',Null,Null, Null, 12),
(15,'Mud Zinger II', 'C26*G7*F3*S87', '', '', 'Adultes',Null,Null, Null, 18);








CREATE TABLE `client` (
  `Id` int(11) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `CompanyNom` varchar(100) DEFAULT NULL,
  `Contact` varchar(100) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `ContactPersonne` varchar(100) DEFAULT NULL,
  `Discount` varchar(5) DEFAULT NULL,
  `Fidelio` varchar(200) DEFAULT NULL,
  `Type` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `client` (`Id`, `Email`, `CompanyNom`, `Contact`, `Address`, `ContactPersonne`, `Discount`, `Fidelio`, `Type`) VALUES
(1, 'mail@gmail.com', 'Marius Girouard', '0102030405', '4 boulevard Montparnasse', '', '', 'Fidélio-100€-3ans-12%', 'Personne'),
(2, 'mail@gmail.com', 'Vianney Gamby', '0203040506', '111 rue de Courcelles', '', '', 'Fidélio-60€-2ans-10%', 'Personne'),
(3, 'mail@gmail.com', 'Laurine Gral', '0304050607', '12 rue Vaugirard', '', '', 'Fidélio-25€-2ans-8%', 'Personne');


CREATE TABLE `clientorders` (
  `Id` int(11) NOT NULL,
  `ClientNom` varchar(100) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `Nom` varchar(100) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Total` double NOT NULL,
  `DeliveryTime` varchar(100) NOT NULL,
  `Quantite` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE `fidelio` (
  `ProgrammeNo` int(11) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `Cout` varchar(10) NOT NULL,
  `Duree` varchar(10) NOT NULL,
  `Rabais` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


INSERT INTO `fidelio` (`ProgrammeNo`, `Description`, `Cout`, `Duree`, `Rabais`) VALUES
(1, 'Fidélio', '15 €', '1 an', '5 %'),
(2, 'Fidélio Or', '25 €', '2 ans', '8 %'),
(3, 'Fidélio Platine', '60 €', '2 ans', '10 %'),
(4, 'Fidélio Max', '100 €', '3 ans', '12 %');



CREATE TABLE `fournisseur` (
  `Id` int(11) NOT NULL,
  `Siret` varchar(19) NOT NULL,
  `CompanyNom` varchar(100) NOT NULL,
  `Contact` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `Qualifiant` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;





INSERT INTO `fournisseur` (`Id`, `Siret`, `CompanyNom`, `Contact`, `Address`, `Qualifiant`) VALUES
('1','1294832884843','Test entreprise','mail@gmail.com','12 avenue de la republique','SARL');

ALTER TABLE `Velos`
  ADD PRIMARY KEY (`Id`);



ALTER TABLE `client`
  ADD PRIMARY KEY (`Id`);


ALTER TABLE `clientorders`
  ADD PRIMARY KEY (`Id`);

ALTER TABLE `fidelio`
  ADD PRIMARY KEY (`ProgrammeNo`);


ALTER TABLE `fournisseur`
  ADD PRIMARY KEY (`Id`);


ALTER TABLE `Velos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;




ALTER TABLE `client`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;


ALTER TABLE `clientorders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;


ALTER TABLE `fidelio`
  MODIFY `ProgrammeNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;


ALTER TABLE `fournisseur`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
