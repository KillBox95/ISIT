package com.pstu;

import com.google.gson.Gson;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public class Main {

    private static Scanner in = new Scanner(System.in);

    private static List<Production> productions;

    private static Long currentProductionId = 0L;//текущая причина 0. точка из которой начинаем.
    private static Set<Long> resolvedTrueProductionsIds = new HashSet<>();//причины которые подтверждена и имеют значение true
    private static Set<Long> resolvedFalseProductionsIds = new HashSet<>();//причины которые подтверждена и имеют значение false

    public static void main(String[] args) throws FileNotFoundException {

        // module read by json (БЗ)
        Gson gson = new Gson();

        ProductionList productionList = gson.fromJson(new FileReader("db.json"), ProductionList.class);//считали из файла
        productions = productionList.getItems();
        // end module




        ask(currentProductionId);

        loop();

    }

    private static void loop() {
        Production currentProduction = productions.get(Math.toIntExact(currentProductionId));

        if (!(currentProduction.getAnswer() == null)) {        //не найден финальнай


            boolean recurceWhenSearchSuccess = false;

            // === module search new productions (МЛВ)
            for (int i1 = 1, productionsSize = productions.size(); i1 < productionsSize; i1++) {//перебираем продукции
                Production production = productions.get(i1);//текущая продукция

                if (production.getReasons() == null){//подтверждаем логическим выводом только те, у которыйх прописаны правила
                    continue;//пропустили те, которые не из чего вывести
                }

                List<String> reasonsForCheck = Arrays.stream(production.getReasons().split("&")).collect(Collectors.toList());//разбили причины на массив, по символу "&".из приины вида: "1&3&!4" получим List {1,3,!4}
                List<Long> reasonsWithoutSymbols = Arrays.stream(production.getReasons().split("&"))//тоже что и выше. но без "!"
                        .map(i ->
                                i.startsWith("!")
                                ? Long.parseLong(i.substring(1, i.length()))
                                : Long.parseLong(i)
                        )
                        .collect(Collectors.toList());
                boolean value = !reasonsForCheck.get(0).startsWith("!");//в продукциях по 1 причине, можно брать знак из первой

                if (resolvedTrueProductionsIds.containsAll(reasonsForCheck.stream().filter(i -> !i.startsWith("!")).map(Long::parseLong).collect(Collectors.toList()))//success. все причины, которые без знака "!" есть в списке подтвержденных.
                    && resolvedFalseProductionsIds.containsAll(reasonsForCheck.stream().filter(i -> i.startsWith("!")).map(i -> Long.parseLong(i.substring(1, i.length()))
                    ).collect(Collectors.toList()))//not success.  и причины с "!" отрицательны
                        && (
                            production.getResolve() == null
                            //|| production.getResolve().equals(Boolean.FALSE)
                        )
                ) {//есть все условия чтобы утвердить продукцию. положительные причины в значения true/ отрицательные в false
                    production.setResolve(value);//признак что причина подтверждена
                    if (value) {//в массив подтвержденных записываем эту причину
                        resolvedTrueProductionsIds.add(currentProductionId);
                    }else{
                        resolvedFalseProductionsIds.add(currentProductionId);

                    }

                    if (reasonsWithoutSymbols.contains(currentProductionId)){//когда вывели причину из текущей, она становится текущей
                        currentProductionId = (long) i1;//currentProductionId показывает в какой причине сейчас мы находимся
                    }

                    recurceWhenSearchSuccess = true;//флаг что запускаем цикл заного. так как подтвердилать причина. надо прогнать еще раз. может подтвердится еще одна
                }
            }
            // === end module


            if (recurceWhenSearchSuccess) {
                loop();//заного заапускаем если была подтверждена хоть какая-то
//                return;
            } else {
                // === region вопрос

                ask(currentProductionId);//не было подтверждений, задаем вопрос о текущей причине. после которого она станет подтвержденной и будет иметь значение которое ввел пользователь
                loop();
                // === end region
            }




            //System.out.println(productions.stream().map(Production::getName).collect(Collectors.toList()));
        } else {//найден финальный. когда найдет причину у которой пустое поле answer. значит мы нашли конечный вариант. выводим его и конец
            System.out.println("результат работы: ");
            System.out.println(currentProduction.getName());

        }
    }

    // === module заимодействия с ользователем
    private static void ask(Long productionId){
        Production production = productions.get(productionId.intValue());

        System.out.println(production.getName() + production.getAnswer());
        String answer = in.next();
        if (answer.equals("1")){
            production.setResolve(true);
            resolvedTrueProductionsIds.add(productionId);

        } else {
            production.setResolve(false);
            resolvedFalseProductionsIds.add(productionId);

        }
    }
    // === end module

}
