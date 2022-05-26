package com.pstu;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class Production {

    private String name;
    private String answer;
    private Boolean resolve = null;
    private String reasons;



    public Production(String name, String answer, String reasons){
//        this.id = seqId;
        this.name = name;
        this.answer = answer;
        this.reasons = reasons;

//        seqId++;
    }
}
