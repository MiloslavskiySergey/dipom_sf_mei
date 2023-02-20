CREATE DATABASE  IF NOT EXISTS `servicecenters` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_bin */;
USE `servicecenters`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: servicecenters
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `catalog`
--

DROP TABLE IF EXISTS `catalog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `catalog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Data_priema` text COLLATE utf8mb4_bin,
  `Data_vidachi` text COLLATE utf8mb4_bin,
  `Data_predoplaty` text COLLATE utf8mb4_bin,
  `surname` text COLLATE utf8mb4_bin,
  `phone` text COLLATE utf8mb4_bin,
  `AboutUs` text COLLATE utf8mb4_bin,
  `WhatRemont` text COLLATE utf8mb4_bin,
  `brand` text COLLATE utf8mb4_bin,
  `model` text COLLATE utf8mb4_bin,
  `SerialNumber` text COLLATE utf8mb4_bin,
  `sostoyanie` text COLLATE utf8mb4_bin,
  `komplektonst` text COLLATE utf8mb4_bin,
  `polomka` text COLLATE utf8mb4_bin,
  `kommentarij` text COLLATE utf8mb4_bin,
  `predvaritelnaya_stoimost` text COLLATE utf8mb4_bin,
  `Predoplata` text COLLATE utf8mb4_bin,
  `Zatrati` text COLLATE utf8mb4_bin,
  `okonchatelnaya_stoimost_remonta` text COLLATE utf8mb4_bin,
  `Skidka` text COLLATE utf8mb4_bin,
  `Status_remonta` text COLLATE utf8mb4_bin,
  `master` text COLLATE utf8mb4_bin,
  `vipolnenie_raboti` text COLLATE utf8mb4_bin,
  `Garanty` text COLLATE utf8mb4_bin,
  `wait_zakaz` text COLLATE utf8mb4_bin,
  `Adress` text COLLATE utf8mb4_bin,
  `Image_key` text COLLATE utf8mb4_bin,
  `AdressSC` text COLLATE utf8mb4_bin,
  `DeviceColour` text COLLATE utf8mb4_bin,
  `ClientId` text COLLATE utf8mb4_bin,
  `Barcode` text COLLATE utf8mb4_bin,
  `Deleted` text COLLATE utf8mb4_bin,
  `catalogcol` varchar(45) COLLATE utf8mb4_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalog`
--

LOCK TABLES `catalog` WRITE;
/*!40000 ALTER TABLE `catalog` DISABLE KEYS */;
INSERT INTO `catalog` VALUES (1,'05-06-2019 18:26','','','','','','ПАТИФОН','BBK','BBK','56664567343','поменять в файле,','АКБ','Этот текст можно,','','0','0','0','0','0','Диагностика','','','Без гарантии','','','','','','2','050618264196','',NULL),(2,'05-06-2019 18:33','','','','','','ТЕЛЕФОН','APPLE','66666','666666','Этот текст можно,','Зарядное устройство','поменять в файле,','Устройство было выдано после гарантийного ремонта 05.06.2019 09:16','0','0','0','0','0','Выдан','ИГОРЬ','Чистка от пыли с заменой термопасты,','30 дней','','','','','','3','050618334493','',NULL),(3,'05-06-2019 18:37','','','','','','ПАТИФОН','APPLE','APPLE','33336767767744','Не бит, не крашен,','Чехол','Этот текст можно,','','0','0','0','0','0','Диагностика','','','Без гарантии','','','','','','4','050618373799','',NULL),(4,'05-06-2019 18:45','06-06-2019 00:00','','','','','ПАТИФОН','ASUS','545','3455','Не бит, не крашен,','поменять в файле','Этот текст можно,','','0','0','0','0','0','Выдан','РОМАН','Замена аккумулятора,','Без гарантии','','','','','','5','050618452791','',NULL),(7,'05-06-2019 19:34','','','','','','NBNBN','NBNB','NBNB','656787878878','Трещина на экране,','Аппарат, зарядное уст-во,','Нет звука,','Устройство было принято на гарантийный ремонт 05.06.2019 09:14\r\nУстройство было принято на гарантийный ремонт 05.06.2019 09:15','0','0','0','0','0','Готов','','','30 дней','','','','','','8','050619345894','',NULL),(8,'05-06-2019 19:36','','','','','','NBNBN','NBNB','NBNB','RTRTRTRT','Трещина на экране,','Аппарат, зарядное уст-во,','Нет звука,','','0','0','0','0','0','Диагностика','','','','','','','','','8','050619362495','1',NULL),(9,'05-06-2019 22:05','','','','','','TV','ASX','UIO','56565','Трещина на экране,','Аппарат, акб,','Не включается,','','0','0','10000','0','0','Согласование с клиентом','','','Без гарантии','','','1','','','10','050622052192','',NULL),(10,'06-06-2019 09:49','06-06-2019 10:01','','','','','ПЛАНШЕТ','APPLE','APPLE','7676FNDF6N','Среднее','Аппарат,','Разбит экран,','','10000','3000','5000','100000','15','Выдан','ВИКТОР','Замена аккумулятора,','30 дней','','','','','','11','060609495690','',NULL),(11,'06-06-2019 10:02','06-06-2019 10:04','','','','','TV','APPLE','АИИРПАПА','6756767','Трещина на экране,','Аппарат,','Разбит экран,','Устройство было выдано после гарантийного ремонта 10.06.2019 09:31','1000','500','5000','10000','0','Выдан','ИГОРЬ','Чистка от пыли с заменой термопасты,','15 дней','','','','','','12','060610022595','',NULL),(12,'12-06-2019 12:01','','','','','','ДЖОЙСТИК','BEKO','BEKO','988989898','Трещина на экране,','Аппарат коробка, зарядное уст-во,','Нет изображения,','','0','0','0','0','0','Диагностика','','','','','','','','','13','120612011697','',NULL),(13,'12-06-2019 23:38','','','','','','НОУТБУК','ASUS','ASUS','F8FDF4545N','Трещина на экране,','Аппарат, зарядное уст-во,','Разбит экран,','','0','0','0','0','0','Диагностика','ИГОРЬ','','Без гарантии','','','','','','14','120623385893','',NULL),(14,'13-06-2019 00:26','','','','','','НОУТБУК','DELL','DELL','SD79SD35','Скол на корпусе,','Аппарат, зарядное уст-во,','Требуется диагностика,','','0','0','0','0','0','Диагностика','','','','','','','','','15','130600262390','',NULL),(15,'14-06-2019 19:22','14-06-2019 19:25','','','','','БЛОК ПИТАНИЯ','DEXP','DEXP','DF8785FDFDF5','Скол на корпусе,','Аппарат, зарядное уст-во,','Неккоректно работает,','','0','0','0','0','0','Выдан','ВИКТОР','Восстановление цепей питания,','Без гарантии','','','','','','16','140619222391','',NULL);
/*!40000 ALTER TABLE `catalog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientsmap`
--

DROP TABLE IF EXISTS `clientsmap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `clientsmap` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FIO` text COLLATE utf8mb4_bin,
  `Phone` text COLLATE utf8mb4_bin,
  `Adress` text COLLATE utf8mb4_bin,
  `Primechanie` text COLLATE utf8mb4_bin,
  `Blist` text COLLATE utf8mb4_bin,
  `date` text COLLATE utf8mb4_bin,
  `aboutUs` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientsmap`
--

LOCK TABLES `clientsmap` WRITE;
/*!40000 ALTER TABLE `clientsmap` DISABLE KEYS */;
INSERT INTO `clientsmap` VALUES (2,'ФЕДОРОВ АЛЕКСЕЙ','8787878787','','','0','05-06-2019 18:26',''),(3,'TEST','d354535','','','0','05-06-2019 18:33',''),(4,'ТРАВКИН ИЛЬЯ','6768687878','','','0','05-06-2019 18:37',''),(5,'TT','34545','gfg','','0','05-06-2019 18:45',''),(8,'КОЗИКОВ НИКОЛАЙ','98779786878678','','','0','05-06-2019 19:34',''),(9,'FGFGF','45454','','','0','05-06-2019 19:36',''),(10,'МИЛАЙЛОВ СЕРГЕЙ','89991345789','','','0','05-06-2019 22:05',''),(11,'МИЛОСЛАВСКИЙ','89886656567','','','0','06-06-2019 09:49',''),(12,'ДЯТЛИВ','6565656565','','','0','06-06-2019 10:02',''),(13,'ПУПКИН ВАСЯ','65767678878','','','0','12-06-2019 12:01',''),(14,'КУДРИК КИРИЛЛ','89042514506','','','0','12-06-2019 23:38',''),(15,'ПЕТУХОВ ДАНЯ','89963425465','','','0','13-06-2019 00:26',''),(16,'ЩУКИН ВОВА','83459815698','','','0','14-06-2019 19:22','');
/*!40000 ALTER TABLE `clientsmap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groupdostup`
--

DROP TABLE IF EXISTS `groupdostup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `groupdostup` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grName` text COLLATE utf8mb4_bin,
  `delZapis` text COLLATE utf8mb4_bin,
  `addZapis` text COLLATE utf8mb4_bin,
  `saveZapis` text COLLATE utf8mb4_bin,
  `graf` text COLLATE utf8mb4_bin,
  `sms` text COLLATE utf8mb4_bin,
  `stock` text COLLATE utf8mb4_bin,
  `clients` text COLLATE utf8mb4_bin,
  `stockAdd` text COLLATE utf8mb4_bin,
  `stockDel` text COLLATE utf8mb4_bin,
  `stockEdit` text COLLATE utf8mb4_bin,
  `clientAdd` text COLLATE utf8mb4_bin,
  `clientDel` text COLLATE utf8mb4_bin,
  `clientConcat` text COLLATE utf8mb4_bin,
  `settings` text COLLATE utf8mb4_bin,
  `dates` text COLLATE utf8mb4_bin,
  `editDates` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groupdostup`
--

LOCK TABLES `groupdostup` WRITE;
/*!40000 ALTER TABLE `groupdostup` DISABLE KEYS */;
INSERT INTO `groupdostup` VALUES (7,'Оператор','1','1','1','0','0','0','1','0','0','0','1','1','1','0','1','1'),(8,'Директор','0','0','0','1','0','1','1','0','0','0','0','0','0','1','1','1'),(9,'Мастер','1','0','1','0','0','1','0','1','1','1','0','0','0','0','1','1'),(10,'Администратор','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1');
/*!40000 ALTER TABLE `groupdostup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historybd`
--

DROP TABLE IF EXISTS `historybd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `historybd` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `WHO` text COLLATE utf8mb4_bin,
  `WHAT` text COLLATE utf8mb4_bin,
  `FULLWHAT` text COLLATE utf8mb4_bin,
  `DATA` text COLLATE utf8mb4_bin,
  `IDINCATALOG` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historybd`
--

LOCK TABLES `historybd` WRITE;
/*!40000 ALTER TABLE `historybd` DISABLE KEYS */;
INSERT INTO `historybd` VALUES (1,'ADMIN','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 18:33','1'),(2,'ADMIN','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 18:35','2'),(3,'ADMIN','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 18:43','3'),(4,'ADMIN','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 18:45','4'),(7,'ADMIN 1234','ИЗМЕНЕНИЕ ДАТЫ ВЫДАЧИ','','05-06-2019 19:32','4'),(8,'ADMIN 1234','СОХРАНЕНИЕ ДАТЫ ПРЕДОПЛАТЫ','','05-06-2019 19:32','4'),(9,'1234 TEST','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 19:36','8'),(10,'1234 TEST','УДАЛЕНИЕ','','05-06-2019 21:13','8'),(11,'1234 TEST','ПЕЧАТЬ АКТА ПРИЁМА ПО ГАРАНТИИ','Изменено: Устройство было принято на гарантийный ремонт 05.06.2019 09:14 НА: Устройство было принято на гарантийный ремонт 05.06.2019 09:14\r\nУстройство было принято на гарантийный ремонт 05.06.2019 09:15','05-06-2019 21:15','7'),(12,'1234 TEST','ПЕЧАТЬ АКТА ВЫДАЧИ ПО ГАРАНТИИ','Изменено:  НА: \r\nУстройство было выдано после гарантийного ремонта 05.06.2019 09:16\r\nИзменено: Диагностика НА: Выдан\r\nИзменено:  НА: Игорь\r\nИзменено:  НА: Чистка от пыли с заменой термопасты,','05-06-2019 21:16','2'),(13,'1234 TEST','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','05-06-2019 22:05','9'),(14,'1234 TEST','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','06-06-2019 09:49','10'),(15,'1234 TEST','СОХРАНЕНИЕ','Изменено: 0 НА: 10000\r\nИзменено: 0 НА: 3000\r\nИзменено: 0 НА: 5000\r\nИзменено: 0 НА: \r\nИзменено: 0 НА: 15\r\nИзменено: Диагностика НА: Ждёт запчасть\r\nИзменено:  НА: Виктор\r\nИзменено:  НА: Замена аккумулятора,','06-06-2019 09:58','10'),(16,'1234 TEST','ПЕЧАТЬ АКТА ПРИЁМА','','06-06-2019 09:58','10'),(17,'1234 TEST','СОХРАНЕНИЕ','Изменено: 0 НА: 10000','06-06-2019 09:59','10'),(18,'1234 TEST','ПЕЧАТЬ АКТА ПРИЁМА','','06-06-2019 09:59','10'),(19,'1234 TEST','СОХРАНЕНИЕ','Изменено: 10000 НА: 100000','06-06-2019 09:59','10'),(20,'1234 TEST','ПЕЧАТЬ АКТА ПРИЁМА','','06-06-2019 09:59','10'),(21,'1234 TEST','ПЕЧАТЬ АКТА ВЫДАЧИ','Изменено: Ждёт запчасть НА: Выдан','06-06-2019 10:01','10'),(22,'1234 TEST','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','06-06-2019 10:02','11'),(23,'1234 TEST','ПЕЧАТЬ АКТА ПРИЁМА','Изменено: 0 НА: 1000\r\nИзменено: 0 НА: 500\r\nИзменено: 0 НА: 5000\r\nИзменено: 0 НА: 10000','06-06-2019 10:03','11'),(24,'1234 TEST','ПЕЧАТЬ АКТА ВЫДАЧИ','Изменено: Диагностика НА: Выдан\r\nИзменено:  НА: Игорь\r\nИзменено:  НА: Чистка от пыли с заменой термопасты,','06-06-2019 10:04','11'),(25,'1234 TEST','СОХРАНЕНИЕ','Изменено: 0 НА: 10000','10-06-2019 09:29','9'),(26,'1234 TEST','СОХРАНЕНИЕ','','10-06-2019 09:29','9'),(27,'1234 TEST','СОХРАНЕНИЕ','Изменено: Диагностика НА: Согласование с клиентом','10-06-2019 09:30','9'),(28,'1234 TEST','ПЕЧАТЬ АКТА ВЫДАЧИ ПО ГАРАНТИИ','Изменено:  НА: \r\nУстройство было выдано после гарантийного ремонта 10.06.2019 09:31','10-06-2019 09:31','11'),(29,'1234 TEST','СОХРАНЕНИЕ','Изменено: Принят по гарантии НА: Готов','10-06-2019 09:33','7'),(30,'ADMIN -1','СОХРАНЕНИЕ','Изменено: GFF НА: Милайлов Сергей\r\nИзменено: 676767 НА: 89991345789\r\nИзменено: GHGHGH НА: UIO','12-06-2019 11:31','9'),(31,'ADMIN -1','СОХРАНЕНИЕ','Изменено: FGFGF НА: Козиков Николай\r\nИзменено: RTRTRTRT НА: 656787878878','12-06-2019 11:32','7'),(32,'ADMIN -1','СОХРАНЕНИЕ','Изменено: TEFFDF НА: Травкин Илья\r\nИзменено: 5556 НА: 6768687878\r\nИзменено: 534444 НА: APPLE\r\nИзменено: 33333333 НА: 33336767767744','12-06-2019 11:32','3'),(33,'ADMIN -1','СОХРАНЕНИЕ','Изменено: FER НА: Федоров Алексей\r\nИзменено: 4536 НА: 8787878787\r\nИзменено: APPLE НА: BBK\r\nИзменено: 56456 НА: BBK\r\nИзменено: 5666666 НА: 56664567343','12-06-2019 11:33','1'),(34,'ADMIN -1','СОХРАНЕНИЕ','Изменено: 45454 НА: 98779786878678','12-06-2019 11:33','7'),(35,'ADMIN -1','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','12-06-2019 12:01','12'),(36,'ADMIN -1','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','12-06-2019 23:39','13'),(37,'ADMIN -1','ПЕЧАТЬ АКТА ПРИЁМА','','12-06-2019 23:56','13'),(38,'ADMIN -1','СОХРАНЕНИЕ','Изменено: СМИЛОСЛАВСКИЙ НА: МИЛОСЛАВСКИЙ','12-06-2019 23:59','10'),(39,'ADMIN -1','СОХРАНЕНИЕ','Изменено: TV НА: ПЛАНШЕТ\r\nИзменено: ПРПР НА: APPLE\r\nИзменено: 7676 НА: 7676FNDF6N\r\nИзменено: Трещина на экране, НА: Среднее','13-06-2019 00:00','10'),(40,'ADMIN -1','СОХРАНЕНИЕ','Изменено: 76767 НА: 89886656567','13-06-2019 00:00','10'),(41,'ADMIN -1','ПЕЧАТЬ АКТА ПРИЁМА','','13-06-2019 00:01','10'),(42,'ADMIN -1','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','13-06-2019 00:26','14'),(43,'ADMIN -1','СОХРАНЕНИЕ','Изменено:  НА: Игорь','14-06-2019 19:19','13'),(44,'ADMIN -1','ДОБАВЛЕНИЕ НОВОЙ ЗАПИСИ','','14-06-2019 19:22','15'),(45,'ADMIN -1','ПЕЧАТЬ АКТА ВЫДАЧИ','Изменено: Диагностика НА: Выдан\r\nИзменено:  НА: Виктор\r\nИзменено:  НА: Восстановление цепей питания,','14-06-2019 19:25','15'),(46,'ADMIN -1','ПЕЧАТЬ АКТА ПРИЁМА','Изменено:  НА: Другой\r\nИзменено:  НА: Замена аккумулятора,','15-06-2019 11:16','4'),(47,'ADMIN -1','ПЕЧАТЬ АКТА ВЫДАЧИ','Изменено: Диагностика НА: Выдан\r\nИзменено: ДРУГОЙ НА: Роман','15-06-2019 11:17','4');
/*!40000 ALTER TABLE `historybd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statesmap`
--

DROP TABLE IF EXISTS `statesmap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `statesmap` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `clientId` text COLLATE utf8mb4_bin,
  `State` text COLLATE utf8mb4_bin,
  `date` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statesmap`
--

LOCK TABLES `statesmap` WRITE;
/*!40000 ALTER TABLE `statesmap` DISABLE KEYS */;
INSERT INTO `statesmap` VALUES (1,'4','05-06-2019 18-45','Установлен статус\r\nДиагностика'),(4,'4','05-06-2019 19-32','Установлена галочка\r\nТребует заказа'),(5,'4','05-06-2019 19-32','Установлен статус\r\nЖдёт запчасть'),(6,'4','05-06-2019 19-32','Снята галочка\r\nТребует заказа'),(7,'4','05-06-2019 19-32','Установлена галочка\r\nТребует заказа'),(8,'4','05-06-2019 19:33','Назначен мастер\r\nИгорь'),(9,'4','05-06-2019 19-33','Установлен статус\r\nГотов'),(10,'4','05-06-2019 19-33','Установлена галочка\r\nНужно согласовать'),(11,'4','05-06-2019 19-33','Снята галочка\r\nНужно согласовать'),(12,'7','05-06-2019 19-34','Установлен статус\r\nДиагностика'),(14,'7','05-06-2019 21-14','Установлен статус\r\nПринят по гарантии'),(15,'2','05-06-2019 21:15','Назначен мастер\r\nИгорь'),(16,'2','05-06-2019 21-16','Установлен статус\r\nВыдан'),(17,'9','05-06-2019 22-05','Установлен статус\r\nДиагностика'),(18,'10','06-06-2019 09-49','Установлен статус\r\nДиагностика'),(19,'10','06-06-2019 09:51','Назначен мастер\r\nВиктор'),(20,'10','06-06-2019 09-51','Установлена галочка\r\nТребует заказа'),(21,'10','06-06-2019 09-51','Установлен статус\r\nЖдёт запчасть'),(22,'10','06-06-2019 09-51','Снята галочка\r\nТребует заказа'),(23,'10','06-06-2019 09-51','Установлена галочка\r\nТребует заказа'),(24,'10','06-06-2019 09-52','Снята галочка\r\nТребует заказа'),(25,'10','06-06-2019 09-58','Установлена галочка\r\nТребует заказа'),(26,'10','06-06-2019 10-01','Установлен статус\r\nВыдан'),(27,'11','06-06-2019 10-02','Установлен статус\r\nДиагностика'),(28,'11','06-06-2019 10-02','Установлена галочка\r\nТребует заказа'),(29,'11','06-06-2019 10:04','Назначен мастер\r\nИгорь'),(30,'11','06-06-2019 10-04','Установлен статус\r\nВыдан'),(31,'9','10-06-2019 09-29','Установлена галочка\r\nНужно согласовать'),(32,'9','10-06-2019 09-29','Установлен статус\r\nСогласование с клиентом'),(33,'7','10-06-2019 09-33','Установлен статус\r\nГотов'),(34,'12','12-06-2019 12-01','Установлен статус\r\nДиагностика'),(35,'13','12-06-2019 23-38','Установлен статус\r\nДиагностика'),(36,'14','13-06-2019 00-26','Установлен статус\r\nДиагностика'),(37,'13','14-06-2019 19:19','Назначен мастер\r\nИгорь'),(38,'15','14-06-2019 19-22','Установлен статус\r\nДиагностика'),(39,'15','14-06-2019 19:25','Назначен мастер\r\nВиктор'),(40,'15','14-06-2019 19-25','Установлен статус\r\nВыдан'),(41,'4','15-06-2019 11:16','Назначен мастер\r\nДругой'),(42,'4','15-06-2019 11:16','Назначен мастер\r\nРоман'),(43,'4','15-06-2019 11-17','Установлен статус\r\nВыдан');
/*!40000 ALTER TABLE `statesmap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `stock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Naimenovanie` text COLLATE utf8mb4_bin,
  `Kategoriya` text COLLATE utf8mb4_bin,
  `Podkategoriya` text COLLATE utf8mb4_bin,
  `Colour` text COLLATE utf8mb4_bin,
  `Brand` text COLLATE utf8mb4_bin,
  `Model` text COLLATE utf8mb4_bin,
  `CountOf` text COLLATE utf8mb4_bin,
  `Price` text COLLATE utf8mb4_bin,
  `Napominanie` text COLLATE utf8mb4_bin,
  `Photo` text COLLATE utf8mb4_bin,
  `Primechanie` text COLLATE utf8mb4_bin,
  `Photo2` text COLLATE utf8mb4_bin,
  `Photo3` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (1,'MP3 ПЛЕЕР СЕНСОР AMD 55656 БЕЛЫЙ','MP3 ПЛЕЕР','СЕНСОР','БЕЛЫЙ','AMD','55656','50','5000','1','','','',''),(2,'ВИДЕОКАРТА СЕНСОР ASX BBK ЧЕРНЫЙ','ВИДЕОКАРТА','СЕНСОР','ЧЕРНЫЙ','ASX','BBK','15','300','5','','','',''),(3,'НОУТБУК КЛАВИАТУРА DIGMA DIGMA','НОУТБУК','КЛАВИАТУРА','','DIGMA','DIGMA','20','500','4','','','',''),(4,'ТЕЛЕФОН МАТРИЦА DNS DNS','ТЕЛЕФОН','МАТРИЦА','','DNS','DNS','5','1000','2','','','','');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stockmap`
--

DROP TABLE IF EXISTS `stockmap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `stockmap` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `clientId` text COLLATE utf8mb4_bin,
  `ZIPId` text COLLATE utf8mb4_bin,
  `countOfZIP` text COLLATE utf8mb4_bin,
  `priceOfZIP` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stockmap`
--

LOCK TABLES `stockmap` WRITE;
/*!40000 ALTER TABLE `stockmap` DISABLE KEYS */;
INSERT INTO `stockmap` VALUES (1,'10','1','1','5000'),(2,'11','1','1','5000'),(3,'9','1','1','5000'),(4,'9','1','1','5000');
/*!40000 ALTER TABLE `stockmap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` text COLLATE utf8mb4_bin,
  `name` text COLLATE utf8mb4_bin,
  `id_gruppi_dostupa` text COLLATE utf8mb4_bin,
  `user_pwd` text COLLATE utf8mb4_bin,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (9,'1234','admin','6','7c87541fd3f3ef5016e12d411900c87a6046a8e8'),(10,'test','1234','5','139f69c93c042496a8e958ec5930662c6cccafbf'),(11,'Оператор','operator1','7','139f69c93c042496a8e958ec5930662c6cccafbf'),(12,'Мастер','master1','9','2f2416ba3bcf5db18362cad20ca90089515abe0f'),(13,'Администратор','admin','10','7c87541fd3f3ef5016e12d411900c87a6046a8e8'),(14,'Директор','director1','8','6ed5833cf35286ebf8662b7b5949f0d742bbec3f');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-16 23:54:55
