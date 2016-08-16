package annotation;

import wasteDisposal.annotations.Disposable;

import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;

/**
 * Created by Edi on 07-Aug-16.
 */
@Retention(RetentionPolicy.RUNTIME)
@Disposable
public @interface BurnableGarbageAnnotation {
}
