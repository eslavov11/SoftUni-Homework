package model.waste;

import annotation.StorableGarbageAnnotation;

/**
 * Created by Edi on 07-Aug-16.
 */
@StorableGarbageAnnotation
public class StorableGarbage extends WasteAbstract {
    public StorableGarbage(String name, double weight, double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}
