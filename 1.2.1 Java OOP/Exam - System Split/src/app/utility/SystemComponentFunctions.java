package app.utility;

/**
 * Created by Edi on 10-Jul-16.
 */
public class SystemComponentFunctions {
    public static long modifyComponentSpecification(long specificationValue, String modifier, int percentage) {
        long result = 0;

        if (modifier.equals("inc")) {
            result = specificationValue + ((specificationValue * percentage) / 100);
        } else if (modifier.equals("dec")) {
            result = specificationValue - ((specificationValue * percentage) / 100);
        }

        return result;
    }
}
