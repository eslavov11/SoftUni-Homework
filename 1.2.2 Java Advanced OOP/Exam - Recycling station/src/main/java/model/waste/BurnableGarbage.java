package model.waste;

import annotation.BurnableGarbageAnnotation;

/**
 * Created by Edi on 07-Aug-16.
 */
@BurnableGarbageAnnotation
public class BurnableGarbage extends WasteAbstract {
    public BurnableGarbage(String name, double weight, double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}
