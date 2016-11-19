package app.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

public class EmailValidator implements ConstraintValidator<Email, String> {

    private int minLength;

    @Override
    public void initialize(Email email) {
        this.minLength = email.minLength();
    }

    @Override
    public boolean isValid(String s, ConstraintValidatorContext constraintValidatorContext) {
        //simple check to see if length of email is less than 5 symbols
        if(s.length() < this.minLength){
            return false;
        }
        return true;
    }
}
