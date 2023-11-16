// Static il folosim cand clasa respectiva nu are nevoie de o instanta ca sa functioneze 

// design pattern este o solutie la probleme care apar in software development 
// cumva niste retete

// anti-pattern sunt niste chestii pe care oamenii le fac dar nu sunt tocmai bun
// ca niste hackuri in cod care se tot repeta 
// ex: controll freak 

// paternurile au fost grupate in 3 mari categorii (sabloane): 
// 1. Creational
// 2. Structural
// 3. De comportament 

// GANK OF 4 - Design Patterns 
// NU are treaba cu mostenirea!!!! 

using Singleton;

Logger logger = Logger.GetInstance();

logger.Log("This is a log message");
logger.Log(Logger.Count.ToString());
Logger logger2= Logger.GetInstance();

logger.Log("This is a log message from logger2!");
logger.Log(Logger.Count.ToString());

Console.ReadLine(); 

// sa se asigure ca nimeni nu poate sa faca o instanta inafara clasei 
// Singleton - design pattern creational 



