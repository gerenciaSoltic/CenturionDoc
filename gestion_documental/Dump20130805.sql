CREATE DATABASE  IF NOT EXISTS `gestiondocumental` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `gestiondocumental`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: gestiondocumental
-- ------------------------------------------------------
-- Server version	5.5.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `propietariop`
--

DROP TABLE IF EXISTS `propietariop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `propietariop` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(33) DEFAULT NULL,
  `predio` varchar(15) DEFAULT NULL,
  `nrodoc` varchar(12) DEFAULT NULL,
  `numord` varchar(3) DEFAULT NULL,
  `total` int(3) DEFAULT NULL,
  `estado` varchar(1) DEFAULT NULL,
  `tipodoc` varchar(1) DEFAULT NULL,
  `idcontribu` varchar(20) DEFAULT NULL,
  `inactivo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propietariop`
--

LOCK TABLES `propietariop` WRITE;
/*!40000 ALTER TABLE `propietariop` DISABLE KEYS */;
/*!40000 ALTER TABLE `propietariop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `codfin`
--

DROP TABLE IF EXISTS `codfin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `codfin` (
  `codigo` char(10) DEFAULT NULL,
  `nombre` char(150) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `codfin`
--

LOCK TABLES `codfin` WRITE;
/*!40000 ALTER TABLE `codfin` DISABLE KEYS */;
/*!40000 ALTER TABLE `codfin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expediente`
--

DROP TABLE IF EXISTS `expediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expediente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idserie` int(11) NOT NULL,
  `idsubserie` int(11) NOT NULL,
  `idtipologia` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `Fechainicio` date NOT NULL,
  `Fechafinal` date NOT NULL,
  `fasearchivo` varchar(45) DEFAULT NULL,
  `contenedor` varchar(10) DEFAULT NULL,
  `compartimiento` int(11) DEFAULT NULL,
  `idunidad` int(11) DEFAULT NULL,
  `idente` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_EXPEDIENTE_SUBSERIE` (`idsubserie`),
  KEY `FK_EXPEDIENTE_TIPOLOGIA` (`idtipologia`),
  KEY `FK_EXPEDIENTE_SERIE` (`idserie`,`idente`,`idunidad`,`fasearchivo`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expediente`
--

LOCK TABLES `expediente` WRITE;
/*!40000 ALTER TABLE `expediente` DISABLE KEYS */;
INSERT INTO `expediente` VALUES (6,13,2,1,'DESARROLLO DE ACTIVIDAD COMUNITARIA','2013-05-10','2013-05-10',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `expediente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `indices`
--

DROP TABLE IF EXISTS `indices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `indices` (
  `idINDICES` int(11) NOT NULL AUTO_INCREMENT,
  `INDICE` varchar(45) DEFAULT NULL,
  `iddocumento` int(11) DEFAULT NULL,
  `ATRIBUTO` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idINDICES`),
  KEY `INDICE` (`INDICE`),
  KEY `ATRIBUTO` (`ATRIBUTO`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `indices`
--

LOCK TABLES `indices` WRITE;
/*!40000 ALTER TABLE `indices` DISABLE KEYS */;
INSERT INTO `indices` VALUES (2,'10/10/2013',24,'FECHA'),(3,'1254454',24,'No. Resolución'),(4,'VICTOR ANDRADE',24,'NOMBRE CONTRATISTA'),(5,'025588',24,'NOMBRE DEL CONTRATO'),(10,'10/10/2013',27,'FECHA'),(11,'015566',27,'No. Resolución'),(12,'VICTOR ANDRADE',27,'NOMBRE CONTRATISTA'),(13,'DESARROLLO COMUNITARIO',27,'NOMBRE DEL CONTRATO'),(14,'12/12/2013',29,'FECHA'),(15,'02555',29,'No. Resolución'),(16,'VICTOR ANDRADE',29,'NOMBRE CONTRATISTA'),(17,'DESARROLLO',29,'NOMBRE DEL CONTRATO'),(18,'MOTO REPUESTOS',24,''),(19,'NOMBRE',24,''),(21,'MOTO',24,''),(22,'BOLETIN',31,''),(23,'BRYAN',31,''),(24,'andres',32,''),(26,'CUENTA',32,''),(27,'EXTRACTO',33,''),(28,'VICTOR',33,'');
/*!40000 ALTER TABLE `indices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propietarioi`
--

DROP TABLE IF EXISTS `propietarioi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `propietarioi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` char(120) NOT NULL,
  `direccion` char(120) NOT NULL,
  `nit` char(20) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nit_UNIQUE` (`nit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propietarioi`
--

LOCK TABLES `propietarioi` WRITE;
/*!40000 ALTER TABLE `propietarioi` DISABLE KEYS */;
/*!40000 ALTER TABLE `propietarioi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentos`
--

DROP TABLE IF EXISTS `documentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documentos` (
  `idDOCUMENTOS` int(11) NOT NULL AUTO_INCREMENT,
  `IDSERIE` int(11) DEFAULT NULL,
  `IDSUBSERIE` int(11) DEFAULT NULL,
  `IDTIPOLOGIA` int(11) unsigned DEFAULT NULL,
  `DOCUMENTO` varchar(250) DEFAULT NULL,
  `CAMINO` varchar(500) DEFAULT NULL,
  `IDEXPEDIENTE` int(11) DEFAULT NULL,
  `FOLIOS` int(5) DEFAULT NULL,
  `ANEXOS` varchar(500) DEFAULT NULL,
  `IDWORKFLOW` int(11) DEFAULT NULL,
  `IDENTE` int(11) DEFAULT NULL,
  `version` int(11) DEFAULT '0',
  PRIMARY KEY (`idDOCUMENTOS`),
  KEY `IDSERIE` (`IDSERIE`),
  KEY `IDSUBSERIE` (`IDSUBSERIE`),
  KEY `IDTIPOLOGIA` (`IDTIPOLOGIA`),
  KEY `DOCUMENTO` (`DOCUMENTO`),
  KEY `IDEXPEDIENTE` (`IDEXPEDIENTE`) USING BTREE,
  KEY `IDWORKFLOW` (`IDWORKFLOW`),
  KEY `IDENTE` (`IDENTE`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentos`
--

LOCK TABLES `documentos` WRITE;
/*!40000 ALTER TABLE `documentos` DISABLE KEYS */;
INSERT INTO `documentos` VALUES (24,13,2,1,'CUENTA DE COBRO ALMACEN MOTO REPUESTOS.pdf','uploadFiles',6,10,'10',NULL,0,0),(26,0,0,0,'CUENTA DE COBRO ALMACEN MOTO REPUESTOS.pdf','uploadFiles',0,10,'10',NULL,0,0),(27,13,2,1,'pago exequial 4 meses.pdf','uploadFiles',6,5,'1 cd',NULL,0,0),(28,0,0,0,'pago exequial 4 meses.pdf','uploadFiles',0,5,'1 cd',NULL,0,0),(29,13,2,1,'HOJA DE VIDA VICTOR ANDRADE.pdf','uploadFiles',6,5,'1 cd',NULL,0,0),(30,0,0,0,'HOJA DE VIDA VICTOR ANDRADE.pdf','uploadFiles',0,5,'1 cd',NULL,0,0),(31,13,2,1,'boletines Bryan III periodo.pdf','uploadFiles',6,2,'',NULL,7,0),(32,0,0,0,'Consulta Afiliados Base de Datos Unica Mary.pdf','uploadFiles',0,5,'1 cd',NULL,0,0),(33,0,0,0,'extracto marzo 2012 Victor Andrade.pdf','uploadFiles',0,5,'',NULL,0,0),(34,13,2,1,'System.Web.UI.WebControls.FileUpload','uploadFiles',6,5,'',NULL,0,0),(35,13,2,1,'System.Web.UI.WebControls.FileUpload','uploadFiles',6,5,'',NULL,0,0);
/*!40000 ALTER TABLE `documentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plancuenta`
--

DROP TABLE IF EXISTS `plancuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plancuenta` (
  `codigo` char(21) NOT NULL,
  `nombre` char(150) DEFAULT NULL,
  `codigo2` char(30) DEFAULT NULL,
  `auxiliar` tinyint(1) DEFAULT NULL,
  `centro` tinyint(1) DEFAULT NULL,
  `idcentro` char(20) DEFAULT NULL,
  `nomcentro` char(80) DEFAULT NULL,
  `presupuesto` tinyint(4) DEFAULT NULL,
  `corriente` tinyint(4) DEFAULT NULL,
  `reciproco` tinyint(4) DEFAULT NULL,
  `terreciproco` varchar(20) DEFAULT NULL,
  `nomreciproco` varchar(150) DEFAULT NULL,
  `codexoge` varchar(20) DEFAULT NULL,
  `gasto1` varchar(20) DEFAULT NULL,
  `pasivo1` varchar(20) DEFAULT NULL,
  `reconocimiento` varchar(20) DEFAULT NULL,
  `nomrecono` varchar(30) DEFAULT NULL,
  `banco` varchar(20) DEFAULT NULL,
  `nbanco` varchar(150) DEFAULT NULL,
  `nroche` varchar(20) DEFAULT NULL,
  `libredest` tinyint(4) DEFAULT NULL,
  `depende` varchar(2) DEFAULT NULL,
  `nomdepende` varchar(80) DEFAULT NULL,
  `chepred` tinyint(4) DEFAULT NULL,
  `ctacgr` varchar(30) DEFAULT NULL,
  `nomctacgr` varchar(150) DEFAULT NULL,
  `depecgr` varchar(2) DEFAULT NULL,
  `nomdepecgr` varchar(150) DEFAULT NULL,
  `secretaria` varchar(2) DEFAULT NULL,
  `nomsecreta` varchar(150) DEFAULT NULL,
  `otrafuente` varchar(2) DEFAULT NULL,
  `nomotraf` varchar(150) DEFAULT NULL,
  `cuentah` varchar(30) DEFAULT NULL,
  `nombreh` varchar(150) DEFAULT NULL,
  `codsia` varchar(20) DEFAULT NULL,
  `codoei` varchar(3) DEFAULT NULL,
  `nomoei` varchar(150) DEFAULT NULL,
  `codfin` varchar(10) DEFAULT NULL,
  `nomfin` varchar(150) DEFAULT NULL,
  `recurso` varchar(3) DEFAULT NULL,
  `subrecurso` varchar(3) DEFAULT NULL,
  `nomrecurso` varchar(200) DEFAULT NULL,
  `ctafut` varchar(25) DEFAULT NULL,
  `nomfut` varchar(80) DEFAULT NULL,
  `ctafutr` varchar(25) DEFAULT NULL,
  `nomfutr` varchar(80) DEFAULT NULL,
  `ctafutes` varchar(25) DEFAULT NULL,
  `nomfutes` varchar(80) DEFAULT NULL,
  `ctafutts` varchar(25) DEFAULT NULL,
  `nomfutts` varchar(80) DEFAULT NULL,
  `ctafutr05` varchar(25) DEFAULT NULL,
  `nomfutr05` varchar(80) DEFAULT NULL,
  `sifondos` tinyint(1) DEFAULT NULL,
  `depefut` varchar(2) DEFAULT NULL,
  `clase` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plancuenta`
--

LOCK TABLES `plancuenta` WRITE;
/*!40000 ALTER TABLE `plancuenta` DISABLE KEYS */;
/*!40000 ALTER TABLE `plancuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entidades`
--

DROP TABLE IF EXISTS `entidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entidades` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `codmunicip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entidades`
--

LOCK TABLES `entidades` WRITE;
/*!40000 ALTER TABLE `entidades` DISABLE KEYS */;
/*!40000 ALTER TABLE `entidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilizacion`
--

DROP TABLE IF EXISTS `utilizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utilizacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilizacion`
--

LOCK TABLES `utilizacion` WRITE;
/*!40000 ALTER TABLE `utilizacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conindycom`
--

DROP TABLE IF EXISTS `conindycom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conindycom` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idindus` int(11) DEFAULT NULL,
  `idconcepto` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conindycom`
--

LOCK TABLES `conindycom` WRITE;
/*!40000 ALTER TABLE `conindycom` DISABLE KEYS */;
/*!40000 ALTER TABLE `conindycom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subrecurso`
--

DROP TABLE IF EXISTS `subrecurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subrecurso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cod_srec` char(3) NOT NULL,
  `nombre` char(200) NOT NULL,
  `cod_rec` char(2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subrecurso`
--

LOCK TABLES `subrecurso` WRITE;
/*!40000 ALTER TABLE `subrecurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `subrecurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dependencias`
--

DROP TABLE IF EXISTS `dependencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dependencias` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Id de la dependencia',
  `nombre` char(80) NOT NULL COMMENT 'Nombre de la dependencia',
  `codigo` char(2) NOT NULL,
  `codfut` char(2) NOT NULL,
  `codcgr` char(2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dependencias`
--

LOCK TABLES `dependencias` WRITE;
/*!40000 ALTER TABLE `dependencias` DISABLE KEYS */;
/*!40000 ALTER TABLE `dependencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `terceros`
--

DROP TABLE IF EXISTS `terceros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `terceros` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nit` varchar(13) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `direccion` varchar(50) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `nombre1` varchar(100) DEFAULT NULL,
  `nombre2` varchar(25) DEFAULT NULL,
  `apellido1` varchar(50) DEFAULT NULL,
  `apellido2` varchar(25) DEFAULT NULL,
  `tipodoc` varchar(5) DEFAULT NULL,
  `verifica` int(11) DEFAULT NULL,
  `rsocial` varchar(30) DEFAULT NULL,
  `tpersona` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terceros`
--

LOCK TABLES `terceros` WRITE;
/*!40000 ALTER TABLE `terceros` DISABLE KEYS */;
/*!40000 ALTER TABLE `terceros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sitioarchivo`
--

DROP TABLE IF EXISTS `sitioarchivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sitioarchivo` (
  `idSitioArchivo` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idSitioArchivo`),
  KEY `indice` (`DESCRIPCION`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sitioarchivo`
--

LOCK TABLES `sitioarchivo` WRITE;
/*!40000 ALTER TABLE `sitioarchivo` DISABLE KEYS */;
INSERT INTO `sitioarchivo` VALUES (2,'ARCHIVO CENTRAL'),(1,'ARCHIVO OFICINA'),(4,'DESTRUCCION'),(3,'DIGITALIZACION');
/*!40000 ALTER TABLE `sitioarchivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enteruta`
--

DROP TABLE IF EXISTS `enteruta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enteruta` (
  `identeruta` int(11) NOT NULL AUTO_INCREMENT,
  `idente` int(11) DEFAULT NULL,
  `contenedor` varchar(10) DEFAULT NULL,
  `numero` varchar(20) DEFAULT NULL,
  `compartimiento` int(3) DEFAULT NULL,
  PRIMARY KEY (`identeruta`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enteruta`
--

LOCK TABLES `enteruta` WRITE;
/*!40000 ALTER TABLE `enteruta` DISABLE KEYS */;
INSERT INTO `enteruta` VALUES (2,7,'ARCHIVADOR','001',2);
/*!40000 ALTER TABLE `enteruta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `secretarias`
--

DROP TABLE IF EXISTS `secretarias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `secretarias` (
  `nombre` char(80) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `secretarias`
--

LOCK TABLES `secretarias` WRITE;
/*!40000 ALTER TABLE `secretarias` DISABLE KEYS */;
/*!40000 ALTER TABLE `secretarias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `radicados`
--

DROP TABLE IF EXISTS `radicados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `radicados` (
  `idradicados` int(11) NOT NULL AUTO_INCREMENT,
  `conseInt` int(11) DEFAULT NULL,
  `ConseExtSal` int(11) DEFAULT NULL,
  `ConseExtent` int(11) DEFAULT NULL,
  `prefInter` varchar(3) DEFAULT NULL,
  `PrefExtSal` varchar(3) DEFAULT NULL,
  `PrefExtEnt` varchar(45) DEFAULT NULL,
  `UltimaFecha` date DEFAULT NULL,
  PRIMARY KEY (`idradicados`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `radicados`
--

LOCK TABLES `radicados` WRITE;
/*!40000 ALTER TABLE `radicados` DISABLE KEYS */;
INSERT INTO `radicados` VALUES (1,1,0,0,'INT','EXS','EXE','2013-08-05'),(2,5,0,0,'INT','EXS','EXE','2013-03-22'),(3,1,1,1,'INT','EXS','EXE','2013-03-21'),(4,4,0,0,'INT','EXS','EXE','2013-03-22');
/*!40000 ALTER TABLE `radicados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `indycom`
--

DROP TABLE IF EXISTS `indycom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `indycom` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` char(80) NOT NULL,
  `base` decimal(14,2) DEFAULT NULL,
  `placa` char(15) DEFAULT NULL,
  `direccion` char(34) DEFAULT NULL,
  `estrato` char(2) DEFAULT NULL,
  `idtipo` int(11) DEFAULT NULL,
  `idpropieta` int(11) DEFAULT NULL,
  `largo` char(10) DEFAULT NULL,
  `ancho` char(10) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `telefono` char(50) DEFAULT NULL,
  `email` char(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fkTipCom` (`idtipo`),
  KEY `fkProp` (`idpropieta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `indycom`
--

LOCK TABLES `indycom` WRITE;
/*!40000 ALTER TABLE `indycom` DISABLE KEYS */;
/*!40000 ALTER TABLE `indycom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serie`
--

DROP TABLE IF EXISTS `serie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `serie` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SERIE` varchar(255) DEFAULT NULL,
  `codigo` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serie`
--

LOCK TABLES `serie` WRITE;
/*!40000 ALTER TABLE `serie` DISABLE KEYS */;
INSERT INTO `serie` VALUES (13,'ACTAS','100.10'),(14,'BOLETINES','100.40'),(15,'CIRCULARES','100.50'),(16,'INFORMES','100.150'),(17,'MEMORIAS DE PARTICIPACION OFICIAL','100.330'),(18,'CONSECUTIVO DE CORRESPONDENCIA DESPACHADA','100.75'),(19,'REGISTROS','100.360');
/*!40000 ALTER TABLE `serie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emirecep`
--

DROP TABLE IF EXISTS `emirecep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emirecep` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NIT` varchar(20) NOT NULL,
  `DESCRIPCION` varchar(200) DEFAULT NULL,
  `DIRECCIONFISICA` varchar(100) DEFAULT NULL,
  `PAIS` int(11) DEFAULT NULL,
  `DEPARTAMENTO` int(11) DEFAULT NULL,
  `MUNICIPIO` int(11) DEFAULT NULL,
  `EMAIL` varchar(200) DEFAULT NULL,
  `CONTRASENAEMAIL` char(20) DEFAULT NULL,
  `FOTO` char(100) DEFAULT NULL,
  `TELEFONO` char(20) DEFAULT NULL,
  `CODIGOUSUARIO` int(11) DEFAULT NULL,
  `IDTIPOEMISOR` int(11) NOT NULL,
  `IDCONFICOR` int(11) DEFAULT NULL,
  `IDENTE` int(11) NOT NULL,
  `IDCARGO` int(11) DEFAULT NULL,
  `IDRADICADO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_EMIRECEP_CONFICOR` (`IDCONFICOR`),
  KEY `FK_EMIRECEP_USUARIOS` (`CODIGOUSUARIO`),
  KEY `FK_EMIRECEP_ENTE` (`IDENTE`),
  KEY `FK_EMIRECEP_CARGO` (`IDCARGO`),
  KEY `FK_EMIRECEP_TIPOEMIRECE` (`IDTIPOEMISOR`),
  CONSTRAINT `FK_EMIRECEP_TIPOEMIRECE` FOREIGN KEY (`IDTIPOEMISOR`) REFERENCES `tipoemirec` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emirecep`
--

LOCK TABLES `emirecep` WRITE;
/*!40000 ALTER TABLE `emirecep` DISABLE KEYS */;
INSERT INTO `emirecep` VALUES (2,'88212634-1','HERRAMIENTAS EMPRESARIALES - VICTOR ANDRADE','CL 101 No. 42-14 HACIENDA SAN JUAN',7,68,1,'herramientasempresariales@gmail.com','','','6959138',0,3,0,0,0,0),(3,'13240610','VICTOR JULIO ANDRADE','OFICINA JURIDICA',7,68,1,'juridica@indersantander.com','','','5825034',3,1,3,7,2,1),(4,'800.256.369','VENTANILLA UNICA','CL 45 No. 63-59',7,68,1,'ventanillaunica@indersantander.gov.co','','','6582526',2,4,2,10,1,1),(5,'12658999','UBERT ANDRADE','oficina 4003',7,68,1,'auxiliarjuridico@indersantander.com','','','6888',4,1,4,7,3,1),(6,'21545155','RODOLFO AICARDI','ALCALDIA',7,68,1,'gobierno@indersantander.com','','','6959138',5,1,5,6,4,1),(7,'5495145','BRAYAN FERNEY ANDRADE','secretaria de gobierno',7,68,1,'auxgobierno@indersantander.com','','','6959138',6,1,7,6,5,1);
/*!40000 ALTER TABLE `emirecep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consecutivos`
--

DROP TABLE IF EXISTS `consecutivos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `consecutivos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `prefijo` varchar(10) DEFAULT NULL,
  `consecuti` int(11) DEFAULT NULL,
  `tipo` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consecutivos`
--

LOCK TABLES `consecutivos` WRITE;
/*!40000 ALTER TABLE `consecutivos` DISABLE KEYS */;
/*!40000 ALTER TABLE `consecutivos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `correoentrante`
--

DROP TABLE IF EXISTS `correoentrante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `correoentrante` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDEMISOR` int(11) DEFAULT NULL,
  `IDRECEPTOR` int(11) DEFAULT NULL,
  `IDTIPOLOGIA` int(11) NOT NULL,
  `ASUNTO` varchar(200) DEFAULT NULL,
  `TEXTO` varchar(1000) DEFAULT NULL,
  `RADICADO` varchar(20) NOT NULL,
  `FECHA` datetime NOT NULL,
  `PROCESADO` int(11) NOT NULL DEFAULT '0',
  `auxEmailEmisor` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_CORREOENTRANTE_TIPOLOGIA` (`IDTIPOLOGIA`),
  KEY `FK_CORREOENTRANTE_EMISOR` (`IDEMISOR`),
  KEY `FK_CORREOENTRANTE_RECEPTOR` (`IDRECEPTOR`),
  CONSTRAINT `FK_CORREOENTRANTE_EMISOR` FOREIGN KEY (`IDEMISOR`) REFERENCES `emirecep` (`ID`),
  CONSTRAINT `FK_CORREOENTRANTE_RECEPTOR` FOREIGN KEY (`IDRECEPTOR`) REFERENCES `emirecep` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_CORREOENTRANTE_TIPOLOGIA` FOREIGN KEY (`IDTIPOLOGIA`) REFERENCES `tipologia` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=487 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `correoentrante`
--

LOCK TABLES `correoentrante` WRITE;
/*!40000 ALTER TABLE `correoentrante` DISABLE KEYS */;
INSERT INTO `correoentrante` VALUES (445,2,2,1,'Nueva prueba','\r\rPrueba de mensaje\r\r-- \rCordialmente,\r\r\r\rVICTOR ALEXANDER ANDRADE \r\rHERRAMIENTAS EMPRESARIALES  ','201306140002','2013-06-14 22:01:07',0,NULL),(446,2,2,1,'Una prueba mas','\r\rEsta es una prueba mas de lo que se puede realizar  por este cliente de correo\r\r-- \rCordialmente,\r\r\r\rVICTOR ALEXANDER ANDRADE  \r\rHERRAMIENTAS EMPRESARIALES  ','201306140003','2013-06-14 22:08:42',0,NULL),(447,2,2,1,'con adjunto','\r\rPrueba con Adjunto\r\r-- \rCordialmente,\r\r\r\rVICTOR ALEXANDER ANDRADE \r\rHERRAMIENTAS EMPRESARIALES  ','201306140004','2013-06-14 22:23:55',0,NULL),(448,NULL,2,1,'RE: ACTUALIZACION','  \r\rIngeniero envio ruta 52 generada por las 2 interfaces del periodo DIC-2012, para tener en cuenta:\r\rLa Interfaz con la que se esta trabajando genera 68 Facturas, la suya genera solo 67\r\rEl concepto reactiva, aparece asi no se les cobre, debe aparecer las lecturas y/o causales según el caso\r\rEl recibo anterior sin cancelar en algunos casos no concuerda\r\rEl item de consumo financiado, también debe aparecer en la parte inferior, asi como hizo lo del recibo anterior sin cancelar\r\rLos datos de Valor Neto, Valor Subsidiado y Valor Consumo, de la parte derecha de la factura despues de las barras de consumos en algunos casos no concuerdan, para revisar estos casos, genere la ruta 51 una ruta pequeña de arauca, donde hay usuarios con los diferentes estratos y hace d','201308020002','2013-06-19 16:10:25',0,'moises_13@hotmail.com'),(449,NULL,2,1,'[PHP Classes] Becoming a PHP Master (Part 2): Reputation','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: mediu','201308020003','2013-06-19 17:09:49',0,'list-announcements@phpclasses.org'),(450,NULL,2,1,'Re: ACTUALIZACION','\r\rUyy Manito.,.. me pongo ya a revisar cada uno de los inconvenientes..\r\rEl 19 de junio de 2013 11:10, Moises Calderon <moises_13@hotmail.com> escribió:\r\rIngeniero envio ruta 52 generada por las 2 interfaces del periodo DIC-2012, para tener en cuenta:\r\rLa Interfaz con la que se esta trabajando genera 68 Facturas, la suya genera solo 67\r\rEl concepto reactiva, aparece asi no se les cobre, debe aparecer las lecturas y/o causales según el caso \r\rEl recibo anterior sin cancelar en algunos casos no concuerda\r\rEl item de consumo financiado, también debe aparecer en la parte inferior, asi como hizo lo del recibo anterior sin cancelar\r\rLos datos de Valor Neto, Valor','201308020004','2013-06-19 20:11:51',0,'servisoftenlinea@gmail.com'),(451,NULL,2,1,'[PHP Classes] Added a new class: Config Manager Class','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020005','2013-06-20 12:30:57',0,'list-newclasses@phpclasses.org'),(452,NULL,2,1,'[PHP Classes] Added a new class: PHP Twitter Feed','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { c','201308020006','2013-06-21 14:33:05',0,'list-newclasses@phpclasses.org'),(453,NULL,2,1,'[PHP Classes] Weekly newsletter of Monday - 2013-06-24','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: #113452; font-size: 17px;','201308020007','2013-06-24 13:21:55',0,'list-newsletter@phpclasses.org'),(454,NULL,2,1,'[PHP Classes] Added a new class: Config4all','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: ','201308020008','2013-06-25 14:22:06',0,'list-newclasses@phpclasses.org'),(455,NULL,2,1,'[PHP Classes] Added a new class: PHP Scrape Website Links','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 {','201308020009','2013-06-26 14:18:31',0,'list-newclasses@phpclasses.org'),(456,NULL,2,1,'[PHP Classes] The Future Beyond the 14 years of PHP Classes','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: me','201308020010','2013-06-26 17:13:07',0,'list-announcements@phpclasses.org'),(457,NULL,2,1,'\"Don Ramon se entera que Uribe es el Gran Colombiano\" de HumorMundialTV','      * { font-family: arial, Arial, sans-serif; } @media only screen and (max-device-width: 480px) { body[class=suppress-border-on-mobile] { margin: 0 !important; border: 0 !important; padding: 0 !important; } table[class=suppress-on-mobile], td[class=suppress-on-mobile], div[class=suppress-on-mobile], img[class=suppress-on-mobile], span[class=suppress-on-mobile] { display: none !important; width: 0px !important; height: 0px !important; line-height: 0px !important; margin: 0 !important; border: 0 !important; padding: 0 !important; } table[class=outer-container-width], td[class=outer-container-width], table[class=inner-container-width], td[class=inner-container-width], table[class=header-container-width], td[class=header-container-width] { width: 320px !important; } td[class=header-left-size], img[class=header-left-size], td[class=header-right-size], img[class=header-right-size] { width: 115px !important; height: ','201308020011','2013-06-27 10:47:20',0,'noreply@youtube.com'),(458,NULL,2,1,'[PHP Classes] Added a new class: PHP API Caller','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { col','201308020012','2013-06-27 14:26:49',0,'list-newclasses@phpclasses.org'),(459,NULL,2,1,'[PHP Classes] Added a new class: Data Page','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: #','201308020013','2013-06-28 14:17:59',0,'list-newclasses@phpclasses.org'),(460,NULL,2,1,'[PHP Classes] Added a new class: Google Charts','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { colo','201308020014','2013-06-29 14:11:47',0,'list-newclasses@phpclasses.org'),(461,NULL,2,1,'[PHP Classes] Added a new class: PHP INI Read and Write Class','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } ','201308020015','2013-06-30 14:15:51',0,'list-newclasses@phpclasses.org'),(462,NULL,2,1,'[PHP Classes] Weekly newsletter of Monday - 2013-07-01','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: #113452; font-size: 17px;','201308020016','2013-07-01 13:33:17',0,'list-newsletter@phpclasses.org'),(463,NULL,2,1,'[PHP Classes] Innovation Award results of June of 2013','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020017','2013-07-01 23:05:01',0,'list-awards@phpclasses.org'),(464,NULL,2,1,'[PHP Classes] Added a new class: PHP MongoDB Message Queue','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 ','201308020018','2013-07-02 14:32:35',0,'list-newclasses@phpclasses.org'),(465,NULL,2,1,'[PHP Classes] How to Install LAMP with Samba File Sharing','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medi','201308020019','2013-07-03 14:34:50',0,'list-announcements@phpclasses.org'),(466,NULL,2,1,'[PHP Classes] Added a new class: PHP Add Apache Virtual Host','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h','201308020020','2013-07-03 16:25:06',0,'list-newclasses@phpclasses.org'),(467,NULL,2,1,'[PHP Classes] Added a new class: PHP Short URL Class','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020021','2013-07-04 14:26:31',0,'list-newclasses@phpclasses.org'),(468,NULL,2,1,'[PHP Classes] Added a new class: PHP Simple HTTP Request','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020022','2013-07-05 14:23:25',0,'list-newclasses@phpclasses.org'),(469,NULL,2,1,'[PHP Classes] Added a new class: PHP File Renamer','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { c','201308020023','2013-07-06 14:20:53',0,'list-newclasses@phpclasses.org'),(470,NULL,2,1,'[PHP Classes] Added a new class: PDO MySQL Connection','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020024','2013-07-07 14:19:17',0,'list-newclasses@phpclasses.org'),(471,NULL,2,1,'[PHP Classes] Weekly newsletter of Monday - 2013-07-08','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: #113452; font-size: 17px;','201308020025','2013-07-08 13:28:59',0,'list-newsletter@phpclasses.org'),(472,NULL,2,1,'[PHP Classes] Added a new class: PHP PNG Lossless Compression','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } ','201308020026','2013-07-08 14:46:48',0,'list-newclasses@phpclasses.org'),(473,NULL,2,1,'[PHP Classes] Added a new class: PHP GIF resize','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { col','201308020027','2013-07-09 14:21:45',0,'list-newclasses@phpclasses.org'),(474,NULL,2,1,'[PHP Classes] Added a new class: PHP Equations','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { colo','201308020028','2013-07-10 14:36:28',0,'list-newclasses@phpclasses.org'),(475,NULL,2,1,'\"Curse of Chucky Official Trailer\" de Mashable','      * { font-family: arial, Arial, sans-serif; } @media only screen and (max-device-width: 480px) { body[class=suppress-border-on-mobile] { margin: 0 !important; border: 0 !important; padding: 0 !important; } table[class=suppress-on-mobile], td[class=suppress-on-mobile], div[class=suppress-on-mobile], img[class=suppress-on-mobile], span[class=suppress-on-mobile] { display: none !important; width: 0px !important; height: 0px !important; line-height: 0px !important; margin: 0 !important; border: 0 !important; padding: 0 !important; } table[class=outer-container-width], td[class=outer-container-width], table[class=inner-container-width], td[class=inner-container-width], table[class=header-container-width], td[class=header-container-width] { width: 320px !important; } td[class=header-left-size], img[class=header-left-size], td[class=header-right-size], img[class=header-right-size] { width: 115px !important; height: ','201308020029','2013-07-11 10:30:17',0,'noreply@youtube.com'),(476,NULL,2,1,'[PHP Classes] The Maturity of PHP - Lately in PHP podcast episode 37','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { b','201308020030','2013-07-11 13:16:28',0,'list-announcements@phpclasses.org'),(477,NULL,2,1,'[PHP Classes] Added a new class: PHP Deobfuscator Class','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020031','2013-07-11 14:54:29',0,'list-newclasses@phpclasses.org'),(478,NULL,2,1,'[PHP Classes] Added a new class: PHP Node.js','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color:','201308020032','2013-07-12 14:23:01',0,'list-newclasses@phpclasses.org'),(479,NULL,2,1,'PREC005_001_08 (servisoftenlinea@gmail.com)',' \r\r\rPREC005_001_08 \r\r\r	 <span itemscope itemprop=\"action\" itemtype=\"http','201308020033','2013-07-12 20:23:51',0,'lulutoloza7@gmail.com'),(480,NULL,2,1,'PREC005_001_08 (servisoftenlinea@gmail.com)',' \r\r\rPREC005_001_08 \r\r\r	 <span itemscope itemprop=\"action\" itemtype=\"http','201308020034','2013-07-12 20:38:31',0,'lulutoloza7@gmail.com'),(481,NULL,2,1,'[PHP Classes] Added a new class: Simple Password Generator','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 ','201308020035','2013-07-13 14:16:26',0,'list-newclasses@phpclasses.org'),(482,NULL,2,1,'[PHP Classes] Added a new class: PHP Fast Cache','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { col','201308020036','2013-07-14 14:24:20',0,'list-newclasses@phpclasses.org'),(483,NULL,2,1,'[PHP Classes] Weekly newsletter of Monday - 2013-07-15','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color: #113452; font-size: 17px;','201308020037','2013-07-15 13:16:27',0,'list-newsletter@phpclasses.org'),(484,NULL,2,1,'[PHP Classes] Added a new class: Contemplate','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { color:','201308020038','2013-07-15 14:25:17',0,'list-newclasses@phpclasses.org'),(485,NULL,2,1,'[PHP Classes] New class daily digest of 2013-07-15','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020039','2013-07-16 14:43:00',0,'list-newclasses@phpclasses.org'),(486,NULL,2,1,'[PHP Classes] New class daily digest of 2013-07-16','    <!-- * { font-size: 12px; } html, body { background: url(\"http://files.phpclasses.org/graphics/phpclasses/background.jpg\") repeat-x scroll center 36px #97DFEE; color: black; font-family: arial,helvetica,sans-serif; height: 100%; margin: 0px; } a:link, a:active { color: #0578C2; text-decoration: underline; } a:visited { color: #12314D; text-decoration: underline; } a:hover { color: #999999; } .left { float: left; } .right { float: right; } .clear { clear: both; } img { border: medium none; } h1 { ','201308020040','2013-07-17 14:26:41',0,'list-newclasses@phpclasses.org');
/*!40000 ALTER TABLE `correoentrante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tareas`
--

DROP TABLE IF EXISTS `tareas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tareas` (
  `idtareas` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  `orden` int(3) DEFAULT NULL,
  PRIMARY KEY (`idtareas`),
  UNIQUE KEY `idtareas_UNIQUE` (`idtareas`),
  KEY `orden` (`orden`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tareas`
--

LOCK TABLES `tareas` WRITE;
/*!40000 ALTER TABLE `tareas` DISABLE KEYS */;
INSERT INTO `tareas` VALUES (1,'Tarea No especificada',NULL),(2,'Su Estudio y Concepto',0),(3,'Proyectar Respuesta para mi Firma',0),(4,'Responder Directamente y Enviar Copia',0),(5,'Encargarse del Asunto e Informar',0),(6,'Coordinar Con',0),(7,'Para su información y Archive',0),(8,'Para su Visto Bueno',0),(9,'Hablar Conmigo',0),(10,'Investigar',0),(11,'Urgente',0),(12,'Otros',0);
/*!40000 ALTER TABLE `tareas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `municipios`
--

DROP TABLE IF EXISTS `municipios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `municipios` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `codigodep` varchar(45) DEFAULT NULL,
  `codigopais` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `municipios`
--

LOCK TABLES `municipios` WRITE;
/*!40000 ALTER TABLE `municipios` DISABLE KEYS */;
INSERT INTO `municipios` VALUES (1,'BUCARAMANGA','68','7');
/*!40000 ALTER TABLE `municipios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plancgr`
--

DROP TABLE IF EXISTS `plancgr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plancgr` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(40) DEFAULT NULL,
  `nombre` varchar(500) DEFAULT NULL,
  `aux` int(1) DEFAULT NULL,
  `transfe` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `codigo` (`codigo`),
  KEY `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plancgr`
--

LOCK TABLES `plancgr` WRITE;
/*!40000 ALTER TABLE `plancgr` DISABLE KEYS */;
/*!40000 ALTER TABLE `plancgr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dispofinal`
--

DROP TABLE IF EXISTS `dispofinal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dispofinal` (
  `iddispofinal` int(11) NOT NULL AUTO_INCREMENT,
  `idserie` int(11) DEFAULT NULL,
  `idunidad` int(11) DEFAULT NULL,
  `tiempo` int(11) DEFAULT NULL,
  `unitiempo` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`iddispofinal`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dispofinal`
--

LOCK TABLES `dispofinal` WRITE;
/*!40000 ALTER TABLE `dispofinal` DISABLE KEYS */;
/*!40000 ALTER TABLE `dispofinal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contabilidad`
--

DROP TABLE IF EXISTS `contabilidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contabilidad` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `cuenta` varchar(22) DEFAULT NULL,
  `idtercero` varchar(22) DEFAULT NULL,
  `concepto` varchar(500) DEFAULT NULL,
  `debito` double DEFAULT NULL,
  `credito` double DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `cheque` varchar(15) DEFAULT NULL,
  `factura` varchar(20) DEFAULT NULL,
  `prefijo` varchar(20) DEFAULT NULL,
  `tipo` varchar(5) DEFAULT NULL,
  `salini` tinyint(1) DEFAULT NULL,
  `nomplan` varchar(150) DEFAULT NULL,
  `tercero` varchar(150) DEFAULT NULL,
  `idcuenta` varchar(22) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contabilidad`
--

LOCK TABLES `contabilidad` WRITE;
/*!40000 ALTER TABLE `contabilidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `contabilidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conceptoic`
--

DROP TABLE IF EXISTS `conceptoic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conceptoic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` char(20) DEFAULT NULL,
  `porcenta` double(14,2) DEFAULT NULL,
  `valor` double(14,2) DEFAULT NULL,
  `anno` char(4) DEFAULT NULL,
  `descuento` int(1) DEFAULT NULL,
  `postotal` int(1) DEFAULT NULL,
  `interes` int(1) DEFAULT NULL,
  `vigenact` int(1) DEFAULT NULL,
  `vigenant` int(1) DEFAULT NULL,
  `idconcepto` char(20) DEFAULT NULL,
  `anticipo` int(1) DEFAULT NULL,
  `descantici` int(1) DEFAULT NULL,
  `indycom` int(1) DEFAULT NULL,
  `aplicades` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conceptoic`
--

LOCK TABLES `conceptoic` WRITE;
/*!40000 ALTER TABLE `conceptoic` DISABLE KEYS */;
/*!40000 ALTER TABLE `conceptoic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meses`
--

DROP TABLE IF EXISTS `meses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meses` (
  `numero` int(11) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `mes` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`numero`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meses`
--

LOCK TABLES `meses` WRITE;
/*!40000 ALTER TABLE `meses` DISABLE KEYS */;
/*!40000 ALTER TABLE `meses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subserieindice`
--

DROP TABLE IF EXISTS `subserieindice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subserieindice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idserie` int(11) DEFAULT NULL,
  `idsubserie` int(11) DEFAULT NULL,
  `atributo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idserie` (`idserie`),
  KEY `idsubserie` (`idsubserie`),
  KEY `atributo` (`atributo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subserieindice`
--

LOCK TABLES `subserieindice` WRITE;
/*!40000 ALTER TABLE `subserieindice` DISABLE KEYS */;
INSERT INTO `subserieindice` VALUES (1,13,2,'FECHA'),(2,13,2,'No. Resolución'),(3,13,2,'NOMBRE CONTRATISTA'),(4,13,2,'NOMBRE DEL CONTRATO'),(5,13,3,'FECHA'),(6,13,3,'No. Resolución'),(7,13,3,'NOMBRE CONTRATISTA'),(8,13,3,'NOMBRE DEL CONTRATO');
/*!40000 ALTER TABLE `subserieindice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ente`
--

DROP TABLE IF EXISTS `ente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ente` (
  `IDENTE` int(11) NOT NULL AUTO_INCREMENT,
  `CODIGO` varchar(20) NOT NULL,
  `DESCRIPCION` varchar(255) NOT NULL,
  `Archivadores` int(11) DEFAULT NULL,
  `Estantes` int(11) DEFAULT NULL,
  `Bandejas` int(11) DEFAULT NULL,
  `Gavetas` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDENTE`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ente`
--

LOCK TABLES `ente` WRITE;
/*!40000 ALTER TABLE `ente` DISABLE KEYS */;
INSERT INTO `ente` VALUES (6,'200','SECRETARIA DE GOBIERNO',NULL,NULL,NULL,NULL),(7,'110','OFICINA JURIDICA',NULL,NULL,NULL,NULL),(8,'105','DESPACHO',NULL,NULL,NULL,NULL),(9,'100','DIRECCION GENERAL',NULL,NULL,NULL,NULL),(10,'000','VENTANILLA',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `ente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subserie`
--

DROP TABLE IF EXISTS `subserie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subserie` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDSERIE` int(11) NOT NULL,
  `SUBSERIE` varchar(255) NOT NULL,
  `CODIGO` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `CODIGO_UNIQUE` (`CODIGO`),
  KEY `FK_SUBSERIE_SERIE` (`IDSERIE`),
  CONSTRAINT `FK_SUBSERIE_SERIE` FOREIGN KEY (`IDSERIE`) REFERENCES `serie` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subserie`
--

LOCK TABLES `subserie` WRITE;
/*!40000 ALTER TABLE `subserie` DISABLE KEYS */;
INSERT INTO `subserie` VALUES (2,13,'Actas de Reunión','10.30'),(3,13,'SUBSERIE DE PRUEBA','40.00');
/*!40000 ALTER TABLE `subserie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `predios`
--

DROP TABLE IF EXISTS `predios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `predios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `avaluo` int(12) DEFAULT NULL,
  `dpto` varchar(2) DEFAULT NULL,
  `muni` varchar(3) DEFAULT NULL,
  `predio` varchar(15) DEFAULT NULL,
  `tiporeg` varchar(1) DEFAULT NULL,
  `direcc` varchar(34) DEFAULT NULL,
  `direccob` varchar(80) DEFAULT NULL,
  `comuna` varchar(1) DEFAULT NULL,
  `destino` varchar(1) DEFAULT NULL,
  `areat` varchar(12) DEFAULT NULL,
  `areac` varchar(6) DEFAULT NULL,
  `espacios` varchar(1) DEFAULT NULL,
  `vigencia` varchar(8) DEFAULT NULL,
  `Estrato` varchar(2) DEFAULT NULL,
  `idgrupo` varchar(20) DEFAULT NULL,
  `hectatotal` int(12) DEFAULT NULL,
  `metrototal` int(12) DEFAULT NULL,
  `hectacons` int(12) DEFAULT NULL,
  `metrocons` int(12) DEFAULT NULL,
  `exento` tinyint(1) DEFAULT NULL,
  `excluido` tinyint(1) DEFAULT NULL,
  `especial` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `predios`
--

LOCK TABLES `predios` WRITE;
/*!40000 ALTER TABLE `predios` DISABLE KEYS */;
/*!40000 ALTER TABLE `predios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cargo` (
  `IDCARGO` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(255) NOT NULL,
  `LIDER` int(1) DEFAULT NULL,
  PRIMARY KEY (`IDCARGO`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
INSERT INTO `cargo` VALUES (2,'JEFE JURIDICO',1),(3,'AUXILIAR JURIDICO',0),(4,'SECRETARIO DE GOBIERNO',1),(5,'AUXILIAR DE GOBIERNO',0);
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresolog`
--

DROP TABLE IF EXISTS `ingresolog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingresolog` (
  `IDSESION` bigint(20) NOT NULL AUTO_INCREMENT,
  `INGRSOLOC` datetime NOT NULL,
  `INGRSOSER` datetime NOT NULL,
  `USUARIO` int(11) NOT NULL,
  `ENTIDAD` char(20) DEFAULT NULL,
  PRIMARY KEY (`IDSESION`),
  KEY `INGRESOLOG_USUARIO_FKEY` (`USUARIO`),
  CONSTRAINT `INGRESOLOG_USUARIO_FKEY` FOREIGN KEY (`USUARIO`) REFERENCES `usuarios` (`CODIGO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresolog`
--

LOCK TABLES `ingresolog` WRITE;
/*!40000 ALTER TABLE `ingresolog` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingresolog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configwf`
--

DROP TABLE IF EXISTS `configwf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configwf` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDENTE` int(11) NOT NULL,
  `IDTIPOLOGIA` int(11) NOT NULL,
  `ORDEN` int(11) DEFAULT NULL,
  `DIAS` int(11) NOT NULL,
  `idsubserie` int(11) DEFAULT NULL,
  `idserie` int(11) DEFAULT NULL,
  `idtarea` int(11) DEFAULT NULL,
  `idexpediente` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_CONFIGWF_TIPOLOGIA` (`IDTIPOLOGIA`),
  KEY `FK_CONFIGWF_EXPEDIENTE` (`idexpediente`),
  CONSTRAINT `FK_CONFIGWF_EXPEDIENTE` FOREIGN KEY (`idexpediente`) REFERENCES `expediente` (`id`),
  CONSTRAINT `FK_CONFIGWF_TIPOLOGIA` FOREIGN KEY (`IDTIPOLOGIA`) REFERENCES `tipologia` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configwf`
--

LOCK TABLES `configwf` WRITE;
/*!40000 ALTER TABLE `configwf` DISABLE KEYS */;
INSERT INTO `configwf` VALUES (2,7,1,1,5,2,13,1,NULL);
/*!40000 ALTER TABLE `configwf` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo`
--

DROP TABLE IF EXISTS `tipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) DEFAULT NULL,
  `tipo` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo`
--

LOCK TABLES `tipo` WRITE;
/*!40000 ALTER TABLE `tipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `indicesexpediente`
--

DROP TABLE IF EXISTS `indicesexpediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `indicesexpediente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idserie` int(11) DEFAULT NULL,
  `idsubserie` int(11) DEFAULT NULL,
  `idtipologia` int(11) DEFAULT NULL,
  `idexpediente` int(11) DEFAULT NULL,
  `atributo` varchar(45) DEFAULT NULL,
  `indice` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idserie` (`idserie`),
  KEY `idsubserie` (`idsubserie`),
  KEY `idtipologia` (`idtipologia`),
  KEY `idexpediente` (`idexpediente`),
  KEY `atributo` (`atributo`),
  KEY `indice` (`indice`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `indicesexpediente`
--

LOCK TABLES `indicesexpediente` WRITE;
/*!40000 ALTER TABLE `indicesexpediente` DISABLE KEYS */;
INSERT INTO `indicesexpediente` VALUES (1,13,2,1,6,'FECHA','10/10/2013'),(2,13,2,1,6,'No. Resolución','0526999'),(3,13,2,1,6,'NOMBRE CONTRATISTA','VICTOR ANDRADE'),(4,13,2,1,6,'NOMBRE DEL CONTRATO','DESARROLLO COMUNITARIO');
/*!40000 ALTER TABLE `indicesexpediente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plansidef`
--

DROP TABLE IF EXISTS `plansidef`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plansidef` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cuenta` char(20) DEFAULT NULL,
  `nombre` char(80) DEFAULT NULL,
  `aux` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plansidef`
--

LOCK TABLES `plansidef` WRITE;
/*!40000 ALTER TABLE `plansidef` DISABLE KEYS */;
/*!40000 ALTER TABLE `plansidef` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avaluo`
--

DROP TABLE IF EXISTS `avaluo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `avaluo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `predio` varchar(15) DEFAULT NULL,
  `anno` varchar(4) DEFAULT NULL,
  `avaluo` int(12) DEFAULT NULL,
  `idcontribu` varchar(20) DEFAULT NULL,
  `pago` varchar(100) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `valor` int(15) DEFAULT NULL,
  `porcentaje` int(15) DEFAULT NULL,
  `abonocap` int(15) DEFAULT NULL,
  `abonoint` int(15) DEFAULT NULL,
  `tipopag` varchar(3) DEFAULT NULL,
  `numeropag` int(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaluo`
--

LOCK TABLES `avaluo` WRITE;
/*!40000 ALTER TABLE `avaluo` DISABLE KEYS */;
/*!40000 ALTER TABLE `avaluo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planfut`
--

DROP TABLE IF EXISTS `planfut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `planfut` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cuenta` char(25) DEFAULT NULL,
  `nombre` char(80) DEFAULT NULL,
  `aux` int(1) DEFAULT NULL,
  `transfe` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planfut`
--

LOCK TABLES `planfut` WRITE;
/*!40000 ALTER TABLE `planfut` DISABLE KEYS */;
/*!40000 ALTER TABLE `planfut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `construccion`
--

DROP TABLE IF EXISTS `construccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `construccion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) DEFAULT NULL,
  `codigo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `construccion`
--

LOCK TABLES `construccion` WRITE;
/*!40000 ALTER TABLE `construccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `construccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conceptopr`
--

DROP TABLE IF EXISTS `conceptopr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conceptopr` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` char(80) DEFAULT NULL,
  `porcenta` int(1) DEFAULT NULL,
  `valor` int(1) DEFAULT NULL,
  `tipo` char(1) DEFAULT NULL,
  `annodesde` char(4) DEFAULT NULL,
  `idconcepto` char(20) DEFAULT NULL,
  `descuento` int(1) DEFAULT NULL,
  `postotal` int(1) DEFAULT NULL,
  `interes` int(1) DEFAULT NULL,
  `vigenact` int(1) DEFAULT NULL,
  `vigenant` int(1) DEFAULT NULL,
  `meses` char(2) DEFAULT NULL,
  `pormeses` int(1) DEFAULT NULL,
  `preliquidado` int(1) DEFAULT NULL,
  `desimpues` int(1) DEFAULT NULL,
  `desinteres` int(1) DEFAULT NULL,
  `annohasta` char(4) DEFAULT NULL,
  `predial` int(1) DEFAULT NULL,
  `corporacion` int(1) DEFAULT NULL,
  `sobretasa` int(1) DEFAULT NULL,
  `masinteres` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conceptopr`
--

LOCK TABLES `conceptopr` WRITE;
/*!40000 ALTER TABLE `conceptopr` DISABLE KEYS */;
/*!40000 ALTER TABLE `conceptopr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipologia`
--

DROP TABLE IF EXISTS `tipologia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipologia` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDSUBSERIE` int(11) NOT NULL,
  `TIPOLOGIA` varchar(255) NOT NULL,
  `CODIGO` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_TIPOLOGIA_SUBSERIE` (`IDSUBSERIE`),
  CONSTRAINT `FK_TIPOLOGIA_SUBSERIE` FOREIGN KEY (`IDSUBSERIE`) REFERENCES `subserie` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipologia`
--

LOCK TABLES `tipologia` WRITE;
/*!40000 ALTER TABLE `tipologia` DISABLE KEYS */;
INSERT INTO `tipologia` VALUES (1,2,'de prueba',NULL);
/*!40000 ALTER TABLE `tipologia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departamentos` (
  `CODIGODEP` char(2) NOT NULL,
  `NOMBRE` char(100) NOT NULL,
  PRIMARY KEY (`CODIGODEP`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamentos`
--

LOCK TABLES `departamentos` WRITE;
/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
INSERT INTO `departamentos` VALUES ('68','SANTANDER');
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adjuntos`
--

DROP TABLE IF EXISTS `adjuntos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adjuntos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDCORREO` int(11) NOT NULL,
  `ARCHIVO` char(200) NOT NULL,
  `NEWARCHIVO` char(200) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_ADJUNTOS_CORREOENTRANTE` (`IDCORREO`),
  CONSTRAINT `FK_ADJUNTOS_CORREOENTRANTE` FOREIGN KEY (`IDCORREO`) REFERENCES `correoentrante` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=249 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjuntos`
--

LOCK TABLES `adjuntos` WRITE;
/*!40000 ALTER TABLE `adjuntos` DISABLE KEYS */;
INSERT INTO `adjuntos` VALUES (244,447,'8821263461AVIANCA PLUS.pdf','201306140004_00.pdf'),(245,448,'ruta 52 interfaz actual.pdf','201308020002_00.pdf'),(246,448,'ruta 52 interfaz suya.pdf','201308020002_01.pdf'),(247,448,'RUTA 51 INTERFAZ ACTUAL.pdf','201308020002_02.pdf'),(248,448,'RUTA 51 INTERFAZ SUYA.pdf','201308020002_03.pdf');
/*!40000 ALTER TABLE `adjuntos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `correosaliente`
--

DROP TABLE IF EXISTS `correosaliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `correosaliente` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDEMISOR` int(11) DEFAULT NULL,
  `IDRECEPTOR` int(11) DEFAULT NULL,
  `IDTIPOLOGIA` int(11) NOT NULL,
  `ASUNTO` varchar(200) DEFAULT NULL,
  `TEXTO` varchar(1000) DEFAULT NULL,
  `RADICADO` char(20) NOT NULL,
  `FECHA` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_CORREOSALIENTE_EMISOR` (`IDEMISOR`),
  KEY `FK_CORREOSALIENTE_TIPOLOGIA` (`IDTIPOLOGIA`),
  KEY `FK_CORREOSALIENTE_RECEPTOR` (`IDRECEPTOR`),
  CONSTRAINT `FK_CORREOSALIENTE_EMISOR` FOREIGN KEY (`IDEMISOR`) REFERENCES `emirecep` (`ID`),
  CONSTRAINT `FK_CORREOSALIENTE_RECEPTOR` FOREIGN KEY (`IDRECEPTOR`) REFERENCES `emirecep` (`ID`),
  CONSTRAINT `FK_CORREOSALIENTE_TIPOLOGIA` FOREIGN KEY (`IDTIPOLOGIA`) REFERENCES `tipologia` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `correosaliente`
--

LOCK TABLES `correosaliente` WRITE;
/*!40000 ALTER TABLE `correosaliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `correosaliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conficor`
--

DROP TABLE IF EXISTS `conficor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conficor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EMAIL` char(100) NOT NULL,
  `CONTRASENA` char(100) NOT NULL,
  `SERVPOPSALIENTE` char(100) NOT NULL,
  `SERVPOPENTRANTE` char(100) NOT NULL,
  `CAMINODESCARGA` char(200) NOT NULL,
  `CAMINOSCANNER` varchar(200) DEFAULT NULL,
  `SOFTESCANER` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conficor`
--

LOCK TABLES `conficor` WRITE;
/*!40000 ALTER TABLE `conficor` DISABLE KEYS */;
INSERT INTO `conficor` VALUES (1,'gabrieldiaz248@gmail.com','1234','pop.gmail.com:995','smtp.gmail.com:587','uploadFiles','c:\\escaner',NULL),(2,'servisoftenlinea@gmail.com','servisoft2013','pop.gmail.com:995','smtp.gmail.com:587','uploadFiles','C:/escaner/','\"C:\\Program Files (x86)\\fiScanner\\ScandAll PRO\\ScandAllPro.exe\"'),(3,'juridica@indersantander.gov.co','prueba','pop.gmail.com:995','smtp.gmail.com:587','uploadfiles','c:/escaner/',NULL),(4,'auxJuridico@indersantander.com','ubert','pop.gmail.com:995','smtp.gmail.com:587','uploadFiles','c:/escaner',NULL),(5,'gobierno@indersantander.com','123','pop.gmail.com:995','smtp.gmail.com:587','uploadfiles','c:\\escaner',NULL),(7,'auxgobierno@indersantander.com','5996','pop.gmail.com:995','smtp.gmail.com:587','uploadFiles','c:\\escaner',NULL);
/*!40000 ALTER TABLE `conficor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workflow`
--

DROP TABLE IF EXISTS `workflow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workflow` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FECHA` datetime NOT NULL,
  `RADICADO` char(20) DEFAULT NULL,
  `IDENTEORIGEN` int(11) NOT NULL,
  `IDENTEDESTINO` int(11) NOT NULL,
  `DIAS` int(11) NOT NULL,
  `OBSERVACION` varchar(500) DEFAULT NULL,
  `IDTIPOLOGIA` int(11) NOT NULL,
  `TIPO` char(20) NOT NULL,
  `iddocumento` int(11) DEFAULT NULL,
  `estado` varchar(20) DEFAULT NULL,
  `SEMAFORO` varchar(20) DEFAULT NULL,
  `IDEXPEDIENTE` int(11) DEFAULT NULL,
  `IDEMIRECEP` int(11) DEFAULT NULL,
  `IDEMIDESTINO` int(11) DEFAULT NULL,
  `idtarea` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_WORKFLOW_ENTEORIGEN` (`IDENTEORIGEN`),
  KEY `FK_WORKFLOW_ENTEDESTINO` (`IDENTEDESTINO`),
  KEY `FK_WORKFLOW_TIPOLOGIA` (`IDTIPOLOGIA`),
  KEY `ESTADO` (`estado`,`SEMAFORO`),
  CONSTRAINT `FK_WORKFLOW_ENTEDESTINO` FOREIGN KEY (`IDENTEDESTINO`) REFERENCES `ente` (`IDENTE`),
  CONSTRAINT `FK_WORKFLOW_ENTEORIGEN` FOREIGN KEY (`IDENTEORIGEN`) REFERENCES `ente` (`IDENTE`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflow`
--

LOCK TABLES `workflow` WRITE;
/*!40000 ALTER TABLE `workflow` DISABLE KEYS */;
INSERT INTO `workflow` VALUES (13,'2013-05-11 05:27:26','201305100001',10,7,0,'HABLATE CON EL SECRETARIO DE GOBIERNO',1,'',24,'2. EN PROCESO','1. URGENTE',6,2,3,0),(30,'2013-05-11 05:27:26','201305100001',10,7,0,'HABLATE CON EL SECRETARIO DE GOBIERNO',1,'',24,'2. EN PROCESO','1. URGENTE',6,2,5,0),(31,'2013-05-11 05:28:01','201305100001',7,6,0,'HABLATE CON EL SECRETARIO DE GOBIERNO',0,'',24,'1. PENDIENTE','1. URGENTE',0,2,6,0),(32,'2013-05-11 09:08:58','INT201305110001',10,7,0,'ubert habla con gobierno y encargate de esto',1,'',27,'2. EN PROCESO','1. URGENTE',6,2,3,0),(33,'2013-05-11 09:08:58','INT201305110001',10,7,0,'ubert habla con gobierno y encargate de esto',1,'',27,'2. EN PROCESO','1. URGENTE',6,2,5,0),(34,'2013-05-11 09:08:58','INT201305110001',7,6,0,'Recibo de pago de las exequiones',0,'',27,'1. PENDIENTE','1. URGENTE',0,2,6,0),(35,'2013-05-11 09:50:01','INT201305110002',10,7,0,'Ubert coordina con el secretario este trabajo',1,'',29,'2. EN PROCESO','2. REGULAR',6,2,3,0),(36,'2013-05-11 09:50:01','INT201305110002',10,7,0,'Ubert coordina con el secretario este trabajo',1,'',29,'2. EN PROCESO','2. REGULAR',6,2,5,0),(37,'2013-05-11 09:50:01','INT201305110002',7,6,0,'La hoja dde vida del nuevo asesor',0,'',29,'1. PENDIENTE','2. REGULAR',0,2,6,0),(38,'2013-08-05 12:56:46','INT201305250001',10,7,5,'URGENTE AFILIACION',1,'',32,'2. EN PROCESO','1. URGENTE',6,2,3,0),(39,'2013-08-05 12:56:46','INT201305250001',10,7,5,'URGENTE AFILIACION',1,'',32,'2. EN PROCESO','1. URGENTE',6,2,3,0),(40,'2013-08-05 13:10:25','INT201308050001',10,7,0,'Adjuntar extracto a la soclicitud',1,'',33,'2. EN PROCESO','1. URGENTE',6,2,3,0),(41,'2013-08-05 13:10:54','INT201308050001',10,7,0,'Adjuntar extracto a la soclicitud',1,'',33,'2. EN PROCESO','1. URGENTE',6,2,3,0),(42,'2013-08-05 13:10:54','INT201308050001',10,7,0,'Adjuntar extracto a la soclicitud',1,'',33,'2. EN PROCESO','1. URGENTE',6,2,3,0);
/*!40000 ALTER TABLE `workflow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `centro`
--

DROP TABLE IF EXISTS `centro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `centro` (
  `idcentro` char(20) NOT NULL,
  `nombre` char(80) NOT NULL,
  PRIMARY KEY (`idcentro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `centro`
--

LOCK TABLES `centro` WRITE;
/*!40000 ALTER TABLE `centro` DISABLE KEYS */;
/*!40000 ALTER TABLE `centro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamento`
--

DROP TABLE IF EXISTS `departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departamento` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamento`
--

LOCK TABLES `departamento` WRITE;
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estratos`
--

DROP TABLE IF EXISTS `estratos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estratos` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `numero` char(2) DEFAULT NULL,
  `nombre` char(60) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estratos`
--

LOCK TABLES `estratos` WRITE;
/*!40000 ALTER TABLE `estratos` DISABLE KEYS */;
/*!40000 ALTER TABLE `estratos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `versiones`
--

DROP TABLE IF EXISTS `versiones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `versiones` (
  `idVERSIONES` int(11) NOT NULL AUTO_INCREMENT,
  `IDDOCUMENTOS` int(11) DEFAULT NULL,
  `version` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idVERSIONES`),
  KEY `VERSION` (`version`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `versiones`
--

LOCK TABLES `versiones` WRITE;
/*!40000 ALTER TABLE `versiones` DISABLE KEYS */;
/*!40000 ALTER TABLE `versiones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conpredial`
--

DROP TABLE IF EXISTS `conpredial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conpredial` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `predio` char(15) DEFAULT NULL,
  `idconcepto` char(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conpredial`
--

LOCK TABLES `conpredial` WRITE;
/*!40000 ALTER TABLE `conpredial` DISABLE KEYS */;
/*!40000 ALTER TABLE `conpredial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` char(100) NOT NULL,
  `USUARIO` char(20) NOT NULL,
  `CONTRASENA` char(20) NOT NULL,
  `ACTIVO` varchar(5) DEFAULT 'False',
  PRIMARY KEY (`CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Gabriel Diaz','gabriel','gabriel','False'),(2,'Ventanilla Unica','ventanilla','ventanilla','True'),(3,'VICTOR JULIO ANDRADE','VJA','13240610','True'),(4,'UBERT ANDRADE','UBA','123456','True'),(5,'RODOLFO AICARDI','RAI','RAI','True'),(6,'BRYAN FERNEY ANDRADE','BFA','BFA','True');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `archivolog`
--

DROP TABLE IF EXISTS `archivolog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `archivolog` (
  `idsesion` int(11) NOT NULL AUTO_INCREMENT,
  `ingresoloc` datetime DEFAULT NULL,
  `ingresoser` datetime DEFAULT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  `entidad` varchar(20) DEFAULT NULL,
  `opcion` varchar(100) DEFAULT NULL,
  `idregistro` varchar(20) DEFAULT NULL,
  `estado` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idsesion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `archivolog`
--

LOCK TABLES `archivolog` WRITE;
/*!40000 ALTER TABLE `archivolog` DISABLE KEYS */;
/*!40000 ALTER TABLE `archivolog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoemirec`
--

DROP TABLE IF EXISTS `tipoemirec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoemirec` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoemirec`
--

LOCK TABLES `tipoemirec` WRITE;
/*!40000 ALTER TABLE `tipoemirec` DISABLE KEYS */;
INSERT INTO `tipoemirec` VALUES (1,'Funcionario'),(2,'Proveedor'),(3,'Externo'),(4,'Ventanilla Unica');
/*!40000 ALTER TABLE `tipoemirec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paises`
--

DROP TABLE IF EXISTS `paises`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paises` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paises`
--

LOCK TABLES `paises` WRITE;
/*!40000 ALTER TABLE `paises` DISABLE KEYS */;
INSERT INTO `paises` VALUES (7,'COLOMBIA');
/*!40000 ALTER TABLE `paises` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarifapre2`
--

DROP TABLE IF EXISTS `tarifapre2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tarifapre2` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `estrato` varchar(2) DEFAULT NULL,
  `idconcepto` varchar(20) DEFAULT NULL,
  `anno` varchar(4) DEFAULT NULL,
  `porcentaje` double(10,4) DEFAULT NULL,
  `valor` double(15,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarifapre2`
--

LOCK TABLES `tarifapre2` WRITE;
/*!40000 ALTER TABLE `tarifapre2` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarifapre2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarifapre3`
--

DROP TABLE IF EXISTS `tarifapre3`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tarifapre3` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idconcepto` varchar(20) DEFAULT NULL,
  `anno` varchar(4) DEFAULT NULL,
  `mes` varchar(2) DEFAULT NULL,
  `porcentaje` double(10,4) DEFAULT NULL,
  `valor` double(15,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarifapre3`
--

LOCK TABLES `tarifapre3` WRITE;
/*!40000 ALTER TABLE `tarifapre3` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarifapre3` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entidadter`
--

DROP TABLE IF EXISTS `entidadter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entidadter` (
  `idetra` char(15) NOT NULL,
  `nombre` char(80) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entidadter`
--

LOCK TABLES `entidadter` WRITE;
/*!40000 ALTER TABLE `entidadter` DISABLE KEYS */;
/*!40000 ALTER TABLE `entidadter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarifapre1`
--

DROP TABLE IF EXISTS `tarifapre1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tarifapre1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `anno` varchar(4) DEFAULT NULL,
  `porcentaje` double(10,4) DEFAULT NULL,
  `valor` double(15,2) DEFAULT NULL,
  `idconcepto` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarifapre1`
--

LOCK TABLES `tarifapre1` WRITE;
/*!40000 ALTER TABLE `tarifapre1` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarifapre1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipocomercio`
--

DROP TABLE IF EXISTS `tipocomercio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipocomercio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` char(10) NOT NULL,
  `nombre` char(80) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `CODIGO_UNIQUE` (`codigo`),
  UNIQUE KEY `NOMBRE_UNIQUE` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipocomercio`
--

LOCK TABLES `tipocomercio` WRITE;
/*!40000 ALTER TABLE `tipocomercio` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipocomercio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidades`
--

DROP TABLE IF EXISTS `unidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidades` (
  `idunidades` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idunidades`),
  KEY `indice` (`idunidades`,`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades`
--

LOCK TABLES `unidades` WRITE;
/*!40000 ALTER TABLE `unidades` DISABLE KEYS */;
INSERT INTO `unidades` VALUES (1,'CARPETAS');
/*!40000 ALTER TABLE `unidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `codoei`
--

DROP TABLE IF EXISTS `codoei`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `codoei` (
  `codigo` char(3) DEFAULT NULL,
  `nombre` char(150) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `codoei`
--

LOCK TABLES `codoei` WRITE;
/*!40000 ALTER TABLE `codoei` DISABLE KEYS */;
/*!40000 ALTER TABLE `codoei` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarifapre`
--

DROP TABLE IF EXISTS `tarifapre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tarifapre` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `anno` varchar(4) DEFAULT NULL,
  `idtipo` int(11) DEFAULT NULL,
  `estrato` varchar(2) DEFAULT NULL,
  `construccion` int(11) DEFAULT NULL,
  `porcentaje` double DEFAULT NULL,
  `idconcepto` int(11) DEFAULT NULL,
  `utilizacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarifapre`
--

LOCK TABLES `tarifapre` WRITE;
/*!40000 ALTER TABLE `tarifapre` DISABLE KEYS */;
/*!40000 ALTER TABLE `tarifapre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `atributos`
--

DROP TABLE IF EXISTS `atributos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `atributos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `atributo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `atributo` (`atributo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atributos`
--

LOCK TABLES `atributos` WRITE;
/*!40000 ALTER TABLE `atributos` DISABLE KEYS */;
INSERT INTO `atributos` VALUES (1,'FECHA'),(5,'No. Resolución'),(4,'NOMBRE CONTRATISTA'),(3,'NOMBRE DEL CONTRATO');
/*!40000 ALTER TABLE `atributos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-08-05 16:53:07
