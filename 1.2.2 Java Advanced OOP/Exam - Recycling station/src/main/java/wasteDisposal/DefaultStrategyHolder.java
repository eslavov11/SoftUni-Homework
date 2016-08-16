package wasteDisposal;

import wasteDisposal.Contracts.GarbageDisposalStrategy;
import wasteDisposal.Contracts.StrategyHolder;

import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

public class DefaultStrategyHolder implements StrategyHolder {
    private LinkedHashMap<Class, GarbageDisposalStrategy> strategies;

    public DefaultStrategyHolder(){
        this.strategies = new LinkedHashMap<>();
    }

    @Override
    public Map<Class, GarbageDisposalStrategy> getDisposalStrategies() {
        return Collections.unmodifiableMap(this.strategies);
    }

    @Override
    public boolean addStrategy(Class annotationClass, GarbageDisposalStrategy strategy) {
        if (this.strategies.get(annotationClass) == null) {
            this.strategies.put(annotationClass,strategy);

            return true;
        }

        return false;
    }

    @Override
    public boolean removeStrategy(Class annotationClass) {
        if (this.strategies.get(annotationClass) == null) {
            return false;
        }

        this.strategies.remove(annotationClass);
        return true;
    }
}
