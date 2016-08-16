package wasteDisposal;

import utility.Messages;
import wasteDisposal.annotations.Disposable;
import wasteDisposal.Contracts.*;

import java.lang.annotation.Annotation;

public class DefaultGarbageProcessor implements GarbageProcessor {
    private StrategyHolder strategyHolder;

    public DefaultGarbageProcessor(StrategyHolder strategyHolder){
        this.setStrategyHolder(strategyHolder);
    }

    public DefaultGarbageProcessor(){
        this(new DefaultStrategyHolder());
    }

    @Override
    public StrategyHolder getStrategyHolder() {
        return this.strategyHolder;
    }

    private void setStrategyHolder(StrategyHolder strategyHolder) {
        this.strategyHolder = strategyHolder;
    }


    @Override
    public ProcessingData processWaste(Waste garbage) {
        Class type = garbage.getClass();
        Annotation[] garbageAnnotations = type.getAnnotations();
        Class disposableAnnotation = null;
        for (Annotation annotation : garbageAnnotations) {
            if(annotation.annotationType().isAnnotationPresent(Disposable.class)){
                disposableAnnotation = annotation.annotationType();
                break;
            }
        }

        GarbageDisposalStrategy currentStrategy;
        if (disposableAnnotation == null || !this.getStrategyHolder().getDisposalStrategies().containsKey(disposableAnnotation)) {
            throw new IllegalArgumentException(Messages.DISPOSABLE_ANNOTATION_NOT_FOUND);
        }

        currentStrategy = this.getStrategyHolder().getDisposalStrategies().get(disposableAnnotation);

        return currentStrategy.processGarbage(garbage);
    }
}
