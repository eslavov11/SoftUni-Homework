import annotation.BurnableGarbageAnnotation;
import model.garbageDisposalStrategy.BurnableGarbageDisposalStrategy;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import wasteDisposal.Contracts.GarbageDisposalStrategy;
import wasteDisposal.Contracts.StrategyHolder;
import wasteDisposal.DefaultStrategyHolder;

/**
 * Created by Edi on 07-Aug-16.
 */
public class StrategyHolderTests {
    private StrategyHolder strategyHolder;

    @Before
    public void setUp() {
        this.strategyHolder = new DefaultStrategyHolder();
    }

    @Test(expected = UnsupportedOperationException.class)
    public void testGetDisposalStrategies_tryToAddStrategyToReadOnlyMap_ShouldThrow() {
        this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, new BurnableGarbageDisposalStrategy());
        this.strategyHolder.getDisposalStrategies().put(BurnableGarbageAnnotation.class, new BurnableGarbageDisposalStrategy());
    }

    @Test
    public void testGetDisposalStrategies_noStrategies_sizeShouldBeZero() {
        int size = this.strategyHolder.getDisposalStrategies().size();

        Assert.assertEquals("The number of strategies should be zero", 0, size);
    }

    @Test
    public void testGetDisposalStrategies_oneStrategy_sizeShouldBeOne() {
        this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, new BurnableGarbageDisposalStrategy());
        int size = this.strategyHolder.getDisposalStrategies().size();

        Assert.assertEquals("The number of strategies should be one", 1, size);
    }

    @Test
    public void testAddStrategy_validStrategy_shouldReturnTrue() {
        GarbageDisposalStrategy garbageDisposalStrategy = new BurnableGarbageDisposalStrategy();

        boolean added = this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, garbageDisposalStrategy);

        Assert.assertTrue("The strategy should have been added", added);
    }

    @Test
    public void testAddStrategy_validStrategy_strategyShouldBeTheSame() {
        GarbageDisposalStrategy garbageDisposalStrategy = new BurnableGarbageDisposalStrategy();

        this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, garbageDisposalStrategy);
        GarbageDisposalStrategy result = this.strategyHolder.getDisposalStrategies().get(BurnableGarbageAnnotation.class);

        Assert.assertEquals("The strategies should be the same", garbageDisposalStrategy, result);
    }

    @Test
    public void testAddStrategy_duplicatedStrategy_shouldReturnFalse() {
        GarbageDisposalStrategy garbageDisposalStrategy = new BurnableGarbageDisposalStrategy();

        this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, garbageDisposalStrategy);
        boolean added = this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, garbageDisposalStrategy);

        Assert.assertFalse("The strategy should not have been added",added);
    }

    @Test
    public void testRemoveStrategy_strategyPresent_shouldReturnTrue() {
        GarbageDisposalStrategy garbageDisposalStrategy = new BurnableGarbageDisposalStrategy();
        this.strategyHolder.addStrategy(BurnableGarbageAnnotation.class, garbageDisposalStrategy);

        boolean removed = this.strategyHolder.removeStrategy(BurnableGarbageAnnotation.class);
        Assert.assertTrue("The strategy should have been removed because it was present in the collection",
                removed);
    }

    @Test
    public void testRemoveStrategy_strategyNotPresent_shouldReturnFalse() {
        boolean removed = this.strategyHolder.removeStrategy(BurnableGarbageAnnotation.class);
        Assert.assertFalse("The strategy should not have been removed because it was not present in the collection",
                removed);
    }
}
