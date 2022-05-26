package com.pstu;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@NoArgsConstructor
public class ProductionList {

    private List<Production> items;

    public ProductionList(List<Production> productions) {
        this.items = productions;
    }
}
