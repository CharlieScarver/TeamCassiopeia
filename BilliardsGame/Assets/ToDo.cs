﻿//// Списък с направеното до момента и какво още трябва да се направи ////
//
// Легенда:
// + добавено
// ! обновено, подобрено
// - премахнато / да се направи

// Направено до момента:
// + добавен базов проект в github на адрес:
//	https://github.com/CharlieScarver/TeamCassiopeia
// + добавен ръчно направен модел на билярдна маса
// + добавен готов модел на билярдна маса
// + добавени текстури за топките
// + добавени бяла и черна топка
// + добавен базов скрипт за движение на бялата топка
// ! завършен ръчно направения модел на билярдната маса
// + добавени всички билярдни топки
// + добавена щека
// + добавено начално меню, от което да може да се минава в режим игра
// - премахната сцената с готовия модел на билярдна маса
// - премахнат готовия модел на билярдна маса
// ! променени имената на сцените за по-голяма прегледност - StartScreen и 
//   PlayMode
// ! променен скрипта за бялата топка:
//      - натискане на лява или десна стрелка, топката се завърта около y 
//      оста си
//      - при задържане на Shift бутона и сътоветно лява или десна стрелка, 
//      топката се завърта по-бавно (по-прецизно)
//      - при задържане и последващо отпускане на клавиша интервал върху топката се 
//      прилага сила, която е пропорционална на времето, в което е бил
//      задържан интервала. Силата не може да бъде над определена
// + направено поведение на щеката - сега щеката изчезва, когато някоя 
//		от топките се движи
// + добавени trigger колайдъри в дупките на билярдната маса и 
//		когато топка напусне някой от тези колайдъри изчезва


// Да се направи:
//
// - да се направи управление и поведение на щеката:
//      - да се добави анимация когато се по времето на натискане и 
//          отпускане на клавиша интервал
// - да се подобри физиката на играта:
// 		- движенията на топките да затихват по-бързо
//		- топките да се разпръзкват по обичайният за билярдна игра 
//			начин, когато първоначално се разбиват; в момента те се 
//			разпръзкват всички в противополжна на удара страна
// - да се направи когато бялата топка достигне един от тези колайдърите 
//		в дупките да се появи в точно определена позиция на масата и
//		потребителяпосредством клавиши да може да я мести и след това да 
//		може да я фиксира
// - когато друга топка достигне един такъв колайдер да се направи 
//		неактивна
// - да се добави в началното меню режим за игра от 1 играч (или режим 
//		на тренировка?) и да може при избор да се преминава в този режим
// - да се направи режим за игра от 1 играч (или режим на тренировка?): 
//		- когато всички топки, освен бялата изчезнат да се показва надпис, 
//			че играта е приключила и след натискането на клавиш да 
//			рестартира играта - или -
//		- когато черната топка изчезне, но има останали други освен бялата
//		да се показва надпис, че играта е приключила и след натискането на 
//		клавиш да рестартира играта
// - да се добави в началното меню режим за игра от 2 играчи и да може при 
//		избор да се преминава в този режим
// - да се направи режим за игра от 2 играчи:
//		- да се разделят топките на два тага (напр. "big" и "small")
//		- да може да се показва на екрана кой играч е в момента
//		- режима на игра да се раздели на 2 под-режима - под-режим 1 - 
//			определяне на кой играч с кои топки ще играе и режим 2 - 
//			всеки играч играе с определения от режим 1 топки
//		- като по-глобално условие, важащо и за двата под-режима - 
//			ако текущ играч вкара бялата топка, то се сменя на другия 
//			играч, топката да се появи в точно определена позиция на 
//			масата и потребителя посредством клавиши да може да я 
//			мести и след това да може да я фиксира (това може да се изведе 
//			като функция и да се вика от 1 място както за режим с  1 играч, 
//			така и за режим с 2 играчи)
//		- първоначално режима на игра да започва с под-режим 1 - започва 
//			играч 1, след като завърши своя ход и ако не е вкарал (или в 
//			случая изчезнала) топка следва игач 2 докато 1 от двамата 
//			вкара топка
//		- в под-режим 1 ако играч вкара черната топка, то да се извежда 
//			надпис, че играта печели другия играч и при натискането на 
//			клавиш да се рестартира играта
//		- ако текущия играч вкара топка от даден вид, да причислим този вид 
//			топки към текущия играч и да сменим на под-режим 2
//		- в под-режим 2 ако играч вкара черната топка, но все още има топки 
//			от своя вид, то да се извежда надпис, че играта печели другия 
//			играч и при натискането на клавиш да се рестартира играта
//		- в под-режим 2 ако играч вкара черната топка, и ако няма топки 
//			от своя вид, то да се извежда надпис, че играта печели текущия 
//			играч и при натискането на клавиш да се рестартира играта
//		- в под-режим 2 ако бялата топка докосне за първи път докосне топка,
//			която не от топките на текущия играч, то се сменя на следващия 
//			играч, то бялата топка се появява в точно определена позиция на
//			масата и потребителя посредством клавиши да може да я мести и след
//			това да може да я фиксира (това може да се изведе като 1 функция,
//			която да се вика и когато бялата топка е вкарана)
//		- (опционно, ако остане време) да се извежда информационно кои топки 
//			са вкарани
// - да се добави чрез допълнително натискане на клавиш потребителя да може 
//		да вижда масата от гледна точка, която да се намира малко над щеката
// - да се доуформят визуалните ефекти - добавяне на текстури, светлини и сенки 
//		на обектите
// - да се направи стая, в която се намира масата
// - да все добави (опционно, ако остане време) да може топката да се удря в 
//      различни части, а не само в центъра й

// - ...
