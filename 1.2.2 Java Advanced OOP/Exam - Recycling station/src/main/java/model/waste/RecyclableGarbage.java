package model.waste;

import annotation.RecyclableGarbageAnnotation;
import wasteDisposal.Contracts.Waste;

/**
 * Created by Edi on 07-Aug-16.
 */
@RecyclableGarbageAnnotation
public class RecyclableGarbage extends WasteAbstract {
    public RecyclableGarbage(String name, double weight, double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}
